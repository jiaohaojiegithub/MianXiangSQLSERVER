using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.SharedCommand
{
    /// <summary>
    /// 题目类型
    /// </summary>
    public enum QuestionsTypeEnum : int
    {
        /// <summary>
        /// 单选题
        /// </summary>
        单选题 = 1,
        /// <summary>
        /// 多选题
        /// </summary>
        多选题 = 2,
        /// <summary>
        /// 简答题
        /// </summary>
        简答题 = 3,
        /// <summary>
        /// 判断题
        /// </summary>
        判断题 = 4,
        /// <summary>
        /// 填空题
        /// </summary>
        填空题 = 5
    }
}
