using System;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using System.Configuration;

namespace PhotoUploader
{
    public class FTPState
    {
        private ManualResetEvent wait;
        private FtpWebRequest request;
        private string fileName;
        private Exception operationException = null;
        string status;
        private Stream requestStream;

        public FTPState()
        {
            wait = new ManualResetEvent(false);
        }

        ~FTPState()
        {
            wait.Dispose();
            requestStream.Dispose();
            request.Abort();
            request = null;
        }

        public Stream RequestStream
        {
            set { requestStream = value; }
        }
        
        public ManualResetEvent OperationComplete
        {
            get { return wait; }
        }

        public FtpWebRequest Request
        {
            get { return request; }
            set { request = value; }
        }

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public Exception OperationException
        {
            get { return operationException; }
            set { operationException = value; }
        }
        public string StatusDescription
        {
            get { return status; }
            set { status = value; }
        }
    }

    public class FTPHelper
    {
        protected static String remotePath = "";

        public static String RemotePath
        {
            get
            {
                if (String.IsNullOrEmpty(remotePath))
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append("ftp://");
                    sb.Append(ConfigurationManager.AppSettings["FTPHostname"]);
                    sb.Append("/");
                    sb.Append(ConfigurationManager.AppSettings["FTPRemotePath"]);
                    remotePath = sb.ToString();
                }

                return remotePath;
            }
        }

        public static String BuildRemoteFQPath(String photoFileName)
        {
            return RemotePath + "/" + photoFileName;
        }

        public static void UploadFileToServer(string targetURI, string filename)
        {
            //TODO: Check that the file doesn't already exist before uploading
            // See: http://stackoverflow.com/questions/347897/how-to-check-if-file-exists-on-ftp-before-ftpwebrequest

            // Create a Uri instance with the specified URI string.
            // If the URI is not correctly formed, the Uri constructor
            // will throw an exception.
            ManualResetEvent waitObject;

            Uri target = new Uri(targetURI);
            string fileName = filename;
            FTPState state = new FTPState();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(target);
            request.Method = WebRequestMethods.Ftp.UploadFile;

            // Enable SSL
            request.EnableSsl = true;

            // Set credentials
            request.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["FTPAccount"], ConfigurationManager.AppSettings["FTPPassword"]);

            request.KeepAlive = false;

            // Store the request in the object that we pass into the
            // asynchronous operations.
            state.Request = request;
            state.FileName = fileName;

            // Get the event to wait on.
            waitObject = state.OperationComplete;

            // Asynchronously get the stream for the file contents.
            request.BeginGetRequestStream(
                new AsyncCallback(EndGetStreamCallback),
                state
            );

            // Block the current thread until all operations are complete.
            waitObject.WaitOne();

            // The operations either completed or threw an exception.
            if (state.OperationException != null)
            {
                throw state.OperationException;
            }
            else
            {
                Console.WriteLine("The operation completed - {0}", state.StatusDescription);
            }
        }
        private static void EndGetStreamCallback(IAsyncResult ar)
        {
            FTPState state = (FTPState)ar.AsyncState;

            Stream requestStream = null;
            // End the asynchronous call to get the request stream.
            try
            {
                requestStream = state.Request.EndGetRequestStream(ar);
                state.RequestStream = requestStream;
                // Copy the file contents to the request stream.
                const int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];
                int count = 0;
                int readBytes = 0;
                FileStream stream = File.OpenRead(state.FileName);
                do
                {
                    readBytes = stream.Read(buffer, 0, bufferLength);
                    requestStream.Write(buffer, 0, readBytes);
                    count += readBytes;
                }
                while (readBytes != 0);
                Console.WriteLine("Writing {0} bytes to the stream.", count);
                // IMPORTANT: Close the request stream before sending the request.
                requestStream.Close();
                stream.Dispose();
                // Asynchronously get the response to the upload request.
                state.Request.BeginGetResponse(
                    new AsyncCallback(EndGetResponseCallback),
                    state
                );
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine("Could not get the request stream.");
                state.OperationException = e;
                state.OperationComplete.Set();
                return;
            }

        }

        // The EndGetResponseCallback method  
        // completes a call to BeginGetResponse.
        private static void EndGetResponseCallback(IAsyncResult ar)
        {
            FTPState state = (FTPState)ar.AsyncState;
            FtpWebResponse response = null;
            try
            {
                response = (FtpWebResponse)state.Request.EndGetResponse(ar);
                response.Close();
                state.StatusDescription = response.StatusDescription;
                response.Dispose();
                // Signal the main application thread that 
                // the operation is complete.
                state.OperationComplete.Set();
            }
            // Return exceptions to the main application thread.
            catch (Exception e)
            {
                Console.WriteLine("Error getting response.");
                state.OperationException = e;
                state.OperationComplete.Set();
            }
        }
    }
}
