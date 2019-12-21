

using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace MianXiangProject.CommandShare.Models
{
    public class PagedAndFilteredInputDto : IPagedResultRequest
    {
        /// <summary>
        /// 总数目条数
        /// </summary>
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// 跳过数
        /// </summary>

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        /// <summary>
        /// 过滤文本
        /// </summary>
        public string FilterText { get; set; }


		 
		 
         


        public PagedAndFilteredInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}