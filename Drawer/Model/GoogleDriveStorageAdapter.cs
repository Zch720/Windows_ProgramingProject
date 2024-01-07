using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Drawer.Model
{
    public class GoogleDriveStorageAdapter : IStorage
    {
        private static readonly string FILE_NAME = "ntut_112_1_windows_datas.txt";
        private static readonly string CONTENT_TYPE = "application/json";
        private static readonly string[] SCOPES = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };
        private DriveService _service;
        private const int KB = 0x400;
        private const int DOWNLOAD_CHUNK_SIZE = 256 * KB;
        private int _timeStamp;
        private string _applicationName;
        private string _clientSecretFileName;
        private UserCredential _credential;
        private bool _serviceCreated;

        private int UNIXNowTimeStamp
        {
            get
            {
                const int UNIX_START_YEAR = 1970;
                DateTime unixStartTime = new DateTime(UNIX_START_YEAR, 1, 1);
                return Convert.ToInt32((DateTime.Now.Subtract(unixStartTime).TotalSeconds));
            }
        }

        public GoogleDriveStorageAdapter(string applicationName, string clientSecretFileName)
        {
            _applicationName = applicationName;
            _clientSecretFileName = clientSecretFileName;
            _serviceCreated = false;
        }
        private void CreateNewService(string applicationName, string clientSecretFileName)
        {
            const string USER = "user";
            const string CREDENTIAL_FOLDER = ".credential/";
            UserCredential credential;

            using (FileStream stream = new FileStream("../../" + clientSecretFileName, FileMode.Open, FileAccess.Read))
            {
                string credentialPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                credentialPath = Path.Combine(credentialPath, CREDENTIAL_FOLDER + applicationName);
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(GoogleClientSecrets.Load(stream).Secrets, SCOPES, USER, CancellationToken.None, new FileDataStore(credentialPath, true)).Result;
            }

            DriveService service = new DriveService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = applicationName
            });

            _credential = credential;
            DateTime now = DateTime.Now;
            _timeStamp = UNIXNowTimeStamp;
            _service = service;
        }

        public string Load()
        {
            if (!_serviceCreated)
            {
                CreateNewService(_applicationName, _clientSecretFileName);
                _serviceCreated = true;
            }

            List<Google.Apis.Drive.v2.Data.File> files = ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File fileToDownload = files.Find(file => file.Title == FILE_NAME);
            if (fileToDownload == null)
                return "";

            CheckCredentialTimeStamp();
            if (!String.IsNullOrEmpty(fileToDownload.DownloadUrl))
            {
                try
                {
                    Task<byte[]> downloadByte = _service.HttpClient.GetByteArrayAsync(fileToDownload.DownloadUrl);
                    return System.Text.Encoding.Default.GetString(downloadByte.Result);
                }
                catch (Exception exception)
                {
                    throw exception;
                }
            }
            return "";
        }

        public void Save(string data)
        {
            if (!_serviceCreated)
            {
                CreateNewService(_applicationName, _clientSecretFileName);
                _serviceCreated = true;
            }

            List<Google.Apis.Drive.v2.Data.File> files = ListRootFileAndFolder();
            Google.Apis.Drive.v2.Data.File fileToDownload = files.Find(file => file.Title == FILE_NAME);
            if (fileToDownload == null)
                UploadFile(data);
            else
                UpdateFile(fileToDownload.Id, data);
            Thread.Sleep(10000);
        }

        public List<Google.Apis.Drive.v2.Data.File> ListRootFileAndFolder()
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            const string ROOT_QUERY_STRING = "'root' in parents";

            try
            {
                returnList = ListFileAndFolderWithQueryString(ROOT_QUERY_STRING);
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return returnList;
        }

        private List<Google.Apis.Drive.v2.Data.File> ListFileAndFolderWithQueryString(string queryString)
        {
            List<Google.Apis.Drive.v2.Data.File> returnList = new List<Google.Apis.Drive.v2.Data.File>();
            this.CheckCredentialTimeStamp();
            FilesResource.ListRequest listRequest = _service.Files.List();
            listRequest.Q = queryString;
            do
            {
                try
                {
                    FileList fileList = listRequest.Execute();
                    returnList.AddRange(fileList.Items);
                    listRequest.PageToken = fileList.NextPageToken;
                }
                catch (Exception exception)
                {
                    listRequest.PageToken = null;
                    throw exception;
                }
            } while (!String.IsNullOrEmpty(listRequest.PageToken));

            return returnList;
        }

        private void CheckCredentialTimeStamp()
        {
            const int ONE_HOUR_SECOND = 3600;
            int nowTimeStamp = UNIXNowTimeStamp;

            if ((nowTimeStamp - _timeStamp) > ONE_HOUR_SECOND)
                this.CreateNewService(_applicationName, _clientSecretFileName);
        }

        private void UploadFile(string data)
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(data);
            MemoryStream uploadStream = new MemoryStream(byteArray);

            this.CheckCredentialTimeStamp();

            Google.Apis.Drive.v2.Data.File fileToInsert = new Google.Apis.Drive.v2.Data.File { Title = FILE_NAME };
            FilesResource.InsertMediaUpload insertRequest = _service.Files.Insert(fileToInsert, uploadStream, CONTENT_TYPE);
            insertRequest.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * 2;

            try
            {
                insertRequest.Upload();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                uploadStream.Close();
            }
        }

        private void UpdateFile(string fileId, string data)
        {
            CheckCredentialTimeStamp();
            try
            {
                Google.Apis.Drive.v2.Data.File file = _service.Files.Get(fileId).Execute();
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(data);
                MemoryStream stream = new MemoryStream(byteArray);
                FilesResource.UpdateMediaUpload request = _service.Files.Update(file, fileId, stream, CONTENT_TYPE);
                request.NewRevision = true;
                request.Upload();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
