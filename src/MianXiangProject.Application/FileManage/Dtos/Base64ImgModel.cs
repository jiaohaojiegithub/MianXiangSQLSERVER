using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.FileManage.Dtos
{
    /// <summary>
    /// base64Img 图片上传
    /// </summary>
   public class Base64ImgModel
    {
        public Base64ImgModel()
        {
            EncodingType = "UTF8";//默认使用utf8编码
        }
        /// <summary>
        /// Base64图片码
        /// </summary>
        public string base64Img { get; set; }
        /// <summary>
        /// 编码方式 默认"UTF8"
        /// </summary>
        public string EncodingType { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
    }
}
