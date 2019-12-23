using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Abp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MianXiangProject.Web.Controllers
{
    public class FileOptionController : Controller
    {
        /// <summary>
        /// 表单提交
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>
        [DontWrapResult, HttpPost]
        public IActionResult UploadFiles(IFormCollection Request)
        {
            var files = Request.Files;
            if (files == null)
            {
                var rError = new
                {
                    uploaded = false,
                    url = string.Empty
                };
                return Json(rError);
            }
            var formFile = files[0];
            var upFileName = formFile.FileName;
            //大小，格式校验....
            var fileName = Guid.NewGuid() + Path.GetExtension(upFileName);
            var saveDir = $@".\wwwroot\upload\{DateTime.Now.Year.ToString()}\{DateTime.Now.Month.ToString()}\{DateTime.Now.Day.ToString()}\";
            var savePath = saveDir + fileName;
            var previewPath = $"/upload/{DateTime.Now.Year.ToString()}/{DateTime.Now.Month.ToString()}/{DateTime.Now.Day.ToString()}/" + fileName;

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
            var rUpload = new
            {
                uploaded = result,
                url = result ? previewPath : string.Empty
            };
            return Json(rUpload);
        }
    }
}