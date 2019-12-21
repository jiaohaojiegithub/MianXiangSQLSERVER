

using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace MianXiangProject.CommandShare.Models
{
    public class PagedInputDto : IPagedResultRequest
    {
        /// <summary>
        /// ����������
        /// </summary>
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// ������Ŀ
        /// </summary>
        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }



		 
		 
         


        public PagedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}