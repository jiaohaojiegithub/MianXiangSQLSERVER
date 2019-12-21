using MianXiangProject.SharedCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MianXiangProject.DataTables
{
    /// <summary>
    /// 题目表 Mysql 小写模式
    /// </summary>
    public class MXQuestion : MXEntity
    {
        /// <summary>
        /// 题目内容
        /// </summary>
        public string Question { get; set; }
        /// <summary>
        /// 题目类型
        /// </summary>
        public QuestionsTypeEnum QuestionType { get; set; }
        /// <summary>
        /// 题目种类
        /// </summary>
        [StringLength(50)]
        public string QuestionCate { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// 岗位ID
        /// </summary>
        public int JobId { get; set; }
        /// <summary>
        /// 所属知识点1
        /// </summary>
        [StringLength(255)]
        public string Knowledge1 { get; set; }
        /// <summary>
        /// 所属知识点2
        /// </summary>
        [StringLength(255)]
        public string Knowledge2 { get; set; }
        /// <summary>
        /// 所属知识点3
        /// </summary>
        [StringLength(255)]
        public string Knowledge3 { get; set; }
        /// <summary>
        /// 公司公司id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// 选项Json
        /// </summary>
        [StringLength(500)]
        public string Options { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [StringLength(500)]
        public string Tags { get; set; }       

    }
}
