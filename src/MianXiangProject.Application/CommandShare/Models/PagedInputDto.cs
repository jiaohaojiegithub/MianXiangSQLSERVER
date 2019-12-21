

using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace MianXiangProject.CommandShare.Models
{
    public class PagedInputDto : IPagedResultRequest
    {
        /// <summary>
        /// 数据总条数
        /// </summary>
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// 跳过数目
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }



		 
		 
         


        public PagedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}