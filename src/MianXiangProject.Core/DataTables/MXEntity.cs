using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using MianXiangProject.SharedCommand;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTables
{
    public class MXEntity : Entity, IHasCreationTime
    {
        public MXEntity()
        {
            CreationTime = Clock.Now;
            Sort = 1;
            State = DataState.启用;
        }
        /// <summary>
        /// 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public DataState State { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
    }
}
