

using Abp.Application.Services.Dto;

namespace MianXiangProject.CommandShare.Models
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        /// <summary>
        /// �����ֶ�
        /// </summary>
        public string Sorting { get; set; }


		 
		 
         

        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}