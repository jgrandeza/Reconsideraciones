using System;
using App.ViewModels;
using Microsoft.AspNetCore.Http;

namespace App.Services.IServices
{
    public interface IFileUploadFTP
    {
        Task<ResponseUpload> UploadFileFTP(IFormFile file, string path);
        Task<ResponseUpload> DeleteFileFTP(string path, string filename);
    }
}

