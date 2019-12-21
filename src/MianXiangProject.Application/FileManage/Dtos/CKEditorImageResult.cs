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
    }
}
