using System;
using System.Net;
using App.Services.IServices;
using App.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace App.Services.Services
{
    public class FileUploadFTP: IFileUploadFTP
    {
        private readonly FTPSettings _fTPSettings;
        public FileUploadFTP(IOptions<FTPSettings> fTPSettings)
        {
            _fTPSettings = fTPSettings.Value;
        }

        public async Task<ResponseUpload> DeleteFileFTP(string path, string filename)
        {
            try
            {
                if (string.IsNullOrEmpty(filename))
                {
                    return new ResponseUpload { Ok = false };
                }

                var path_ftp = string.Concat(_fTPSettings.FtpURL, _fTPSettings.FTPDirectoryFiles, path, filename);
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(path_ftp);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                request.Credentials = new NetworkCredential(_fTPSettings.FtpUser, _fTPSettings.FtpPassword);

                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    return new ResponseUpload { Ok = true, FileName = filename };
                }

            }
            catch (WebException wex)
            {
                FtpWebResponse response = (FtpWebResponse)wex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return new ResponseUpload { Ok = false };
                }
                return new ResponseUpload { Ok = false };
            }

            catch (Exception ex)
            {
                return new ResponseUpload { Ok = false };
            }
        }

        public async Task<ResponseUpload> UploadFileFTP(IFormFile file, string path)
        {
            try
            {
                if (file is null)
                {
                    return new ResponseUpload { Ok = false };
                }

                var fileNameguid = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string uploadUrl = $"{_fTPSettings.FtpURL}{_fTPSettings.FTPDirectoryFiles}{path}{fileNameguid}";
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(uploadUrl);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                request.Credentials = new NetworkCredential(_fTPSettings.FtpUser, _fTPSettings.FtpPassword);
                byte[] buffer = new byte[1024];
                var stream = file.OpenReadStream();
                byte[] fileContents;
                using (var ms = new MemoryStream())
                {
                    int read;
                    while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                    {
                        await ms.WriteAsync(buffer, 0, read);
                    }
                    fileContents = ms.ToArray();
                }
                using (Stream requestStream = request.GetRequestStream())
                {
                    await requestStream.WriteAsync(fileContents, 0, fileContents.Length);
                }
                //FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return new ResponseUpload { Ok = true, FileName = fileNameguid.ToString() };
            }
            catch (WebException wex)
            {
                return new ResponseUpload { Ok = false };
            }
            catch (Exception ex)
            {
                return new ResponseUpload { Ok = false };
            }
        }
    }
}

