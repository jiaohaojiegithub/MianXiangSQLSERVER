using Abp.Application.Services;
using MianXiangProject.FileManage.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.FileManage
{
    public interface IFileManageAppService : IApplicationService
    {
        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="File"></param>
        /// <returns></returns>
        CKEditorImageResult UploadFile(IFormFile File);
        /// <summary>
        /// 表单提交上传图片
        /// </summary>
        /// <param name="Request"></param>
        /// <returns></returns>

        CKEditorImageResult UploadFiles(IFormCollection Request);
        /// <summary>
        /// base64img字符串转图片存储
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        CKEditorImageResult UploadImgByBase64(Base64ImgModel base64);

        

    }
}
