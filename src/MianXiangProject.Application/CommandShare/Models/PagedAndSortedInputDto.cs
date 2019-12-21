

using Abp.Application.Services.Dto;

namespace MianXiangProject.CommandShare.Models
{
    public class PagedAndSortedInputDto : PagedInputDto, ISortedResultRequest
    {
        /// <summary>
        /// ÅÅÐò×Ö¶Î
        /// </summary>
        public string Sorting { get; set; }


		 
		 
         

        public PagedAndSortedInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}