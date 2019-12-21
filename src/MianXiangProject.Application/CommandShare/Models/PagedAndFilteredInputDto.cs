

using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace MianXiangProject.CommandShare.Models
{
    public class PagedAndFilteredInputDto : IPagedResultRequest
    {
        /// <summary>
        /// ����Ŀ����
        /// </summary>
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }
        /// <summary>
        /// ������
        /// </summary>

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }
        /// <summary>
        /// �����ı�
        /// </summary>
        public string FilterText { get; set; }


		 
		 
         


        public PagedAndFilteredInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}