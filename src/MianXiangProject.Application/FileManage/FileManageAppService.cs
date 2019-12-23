using Abp.Application.Services;
using Abp.Web.Models;
using MianXiangProject.CommandShare;
using MianXiangProject.FileManage.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace MianXiangProject.FileManage
{
    /// <summary>
    /// 文件上传处理
    /// </summary>
    public class FileManageAppService : ApplicationService, IFileManageAppService
    {
        private readonly IConfiguration _configuration;



        public FileManageAppService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        /// <summary>
        /// 获取站点网址
        /// </summary>
        /// <returns></returns>
        private string GetAppString()
        {

            return _configuration["App:ServerUrl"];
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        [DontWrapResult, HttpPost]
        public CKEditorImageResult UploadFile(IFormFile File)
        {
            var files = File;
            if (files == null)
            {
                var rError = new CKEditorImageResult
                {
                    uploaded = false,
                    url = string.Empty
                };
                return rError;
            }
            var formFile = files;
            var upFileName = formFile.FileName;
            //大小，格式校验....
            var fileName = Guid.NewGuid() + Path.GetExtension(upFileName);
            var saveDir = @".\wwwroot\upload\";
            var savePath = saveDir + fileName;
            var previewPath = GetAppString()+ "/upload/" + fileName;

            bool result = true;
            try
            {
                if (!Directory.Exists(saveDir))
                {
                    Directory.CreateDirectory(saveDir);
                }
                using (FileStream fs = System.IO.File.Create(savePath))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            var rUpload = new CKEditorImageResult
            {
                uploaded = result,
                url = result ? previewPath : string.Empty
            };
            return rUpload;
        }
        /// <summary>
        /// 表单提交
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [DontWrapResult, HttpPost]
        public CKEditorImageResult UploadFiles(IFormCollection Request)
        {
            var files = Request.Files;
            if (files == null)
            {
                var rError = new CKEditorImageResult
                {
                    uploaded = false,
                    url = string.Empty,
                    error=new Error { 
                    message="未获取到文件数据"
                    }
                };
                return rError;
            }
            var formFile = files[0];
            var upFileName = formFile.FileName;
            //大小，格式校验....
            var fileName = Guid.NewGuid() + Path.GetExtension(upFileName);
            var saveDir = $@".\wwwroot\upload\{DateTime.Now.Year.ToString()}\{DateTime.Now.Month.ToString()}\{DateTime.Now.Day.ToString()}\";
            var savePath = saveDir + fileName;
            var previewPath = $"{GetAppString()}/upload/{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/" + fileName;

            bool result = true;
            string errormessage = string.Empty;
            try
            {
                if (!Directory.Exists(saveDir))
                {
                    Directory.CreateDirectory(saveDir);
                }
                using (FileStream fs = System.IO.File.Create(savePath))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }
            }
            catch (Exception ex)
            {
                result = false;
                errormessage = ex.Message;
            }
            var rUpload = new CKEditorImageResult
            {
                uploaded = result,
                url = result ? previewPath : string.Empty,
                 error = new Error
                 {
                     message = errormessage
                 }
            };
            return rUpload;
        }

        /// <summary>
        /// 添加base64图片数据接口
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        [DontWrapResult, HttpPost]
        public CKEditorImageResult UploadImgByBase64(Base64ImgModel base64)
        {
            try
            {
                if (base64.base64Img != "")
                {

                    string utf8String = String.Empty;
                    switch (base64.EncodingType)
                    {
                        case "UTF8": { utf8String = System.Web.HttpUtility.UrlDecode(base64.base64Img, System.Text.Encoding.UTF8); break; }
                        case "Unicode": { utf8String = System.Web.HttpUtility.UrlDecode(base64.base64Img, System.Text.Encoding.Unicode); break; }
                        default: { utf8String = System.Web.HttpUtility.UrlDecode(base64.base64Img, System.Text.Encoding.GetEncoding($"{base64.EncodingType.Trim()}")); break; }
                    }
                    //data:image/jpeg;base64,
                    string datatype = default(string);
                    string imgstr = default(string);
                    Match match = Regex.Match(utf8String, @"data:");
                    if (match.Success)
                    {
                        match = Regex.Match(utf8String, @"data:([\w/]{1,});");
                        if (match.Success)
                        {
                            datatype = match.Groups[1].Value;
                        }
                        match = Regex.Match(utf8String, @"base64,([\s\S]{1,})");
                        if (match.Success)
                        {
                            imgstr = match.Groups[1].Value;
                        }
                    }
                    else
                    {
                        imgstr = utf8String;
                    }
                    imgstr = imgstr.Replace(" ", "+");
                    var bitmap = ConvertImgHelp.Base64StringToImage(imgstr);
                    var upFileName = base64.FileName;
                    //大小，格式校验....
                    var fileName = Guid.NewGuid() + Path.GetExtension(upFileName);
                    var saveDir = @".\wwwroot\upload\";
                    var savePath = saveDir + fileName;
                    var previewPath =  GetAppString() + "/upload/" + fileName;

                    bool result = true;
                    try
                    {
                        if (!Directory.Exists(saveDir))
                        {
                            Directory.CreateDirectory(saveDir);
                        }
                        switch (datatype)
                        {
                            case "image/gif": { bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Gif); break; }
                            default: { bitmap.Save(savePath, System.Drawing.Imaging.ImageFormat.Jpeg); break; }
                        }
                    }
                    catch (Exception ex)
                    {
                        result = false;
                    }
                    return new CKEditorImageResult
                    {
                        uploaded = result,
                        url = result ? previewPath : string.Empty
                    };
                }
                else
                {
                    return new CKEditorImageResult
                    {
                        uploaded = false,
                        url = string.Empty
                    };
                   
                }
            }
            catch (Exception ex)
            {
                return new CKEditorImageResult
                {
                    uploaded = false,
                    url = string.Empty
                };
               
            }
        }
        /// <summary>
        /// CKEditor4返回图片链接
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [DontWrapResult, HttpPost]
        public string UploadFilesByCK4(IFormCollection Request)
        {
            var files = Request.Files;
            if (files == null)
            {              
                return string.Empty;
            }
            var formFile = files[0];
            var upFileName = formFile.FileName;
            //大小，格式校验....
            var fileName = Guid.NewGuid() + Path.GetExtension(upFileName);
            var saveDir = $@".\wwwroot\upload\{DateTime.Now.Year.ToString()}\{DateTime.Now.Month.ToString()}\{DateTime.Now.Day.ToString()}\";
            var savePath = saveDir + fileName;
            var previewPath = $"{GetAppString()}/upload/{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/" + fileName;

            bool result = true;
            try
            {
                if (!Directory.Exists(saveDir))
                {
                    Directory.CreateDirectory(saveDir);
                }
                using (FileStream fs = System.IO.File.Create(savePath))
                {
                    formFile.CopyTo(fs);
                    fs.Flush();
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
          
            return result ? previewPath : string.Empty;
        }
    }
}
