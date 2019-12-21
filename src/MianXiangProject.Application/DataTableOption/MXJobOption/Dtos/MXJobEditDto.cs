
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace  MianXiangProject.DataTableOption.MXJobOption.Dtos
{
    public class MXJobEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// JobName
		/// </summary>
		[MaxLength(100, ErrorMessage="JobName超出最大长度")]
		[MinLength(1, ErrorMessage="JobName小于最小长度")]
		[Required(ErrorMessage="JobName不能为空")]
		public string JobName { get; set; }



		/// <summary>
		/// JobType
		/// </summary>
		[MaxLength(100, ErrorMessage="JobType超出最大长度")]
		[MinLength(1, ErrorMessage="JobType小于最小长度")]
		[Required(ErrorMessage="JobType不能为空")]
		public string JobType { get; set; }



		/// <summary>
		/// Description
		/// </summary>
		[MaxLength(500, ErrorMessage="Description超出最大长度")]
		[MinLength(0, ErrorMessage="Description小于最小长度")]
		public string Description { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int Sort { get; set; }


	}
}