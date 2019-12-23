using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.FileManage.Dtos
{
    /// <summary>
    /// CKEditor5 图片上传返回参数
    /// </summary>
    public class CKEditorImageResult
    {
        /// <summary>
        /// 上传状态
        /// </summary>
        public bool uploaded { get; set; }
        /// <summary>
        /// 返回存储的相对路径
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// CKEditor4返回参数 文件名
        /// </summary>
        public string fileName { get; set; }
        /// <summary>
        /// CKEditor4返回参数 错误
        /// </summary>
        public Error error { get; set; }
    }
    public class Error
    {
        /// <summary>
        /// CKEditor4返回参数 消息
        /// </summary>
        public string message { get; set; }
    }
}
