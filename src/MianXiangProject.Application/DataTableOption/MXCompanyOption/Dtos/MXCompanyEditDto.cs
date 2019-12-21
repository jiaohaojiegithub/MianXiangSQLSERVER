
using System;
using System.ComponentModel.DataAnnotations;
using Abp.Domain.Entities.Auditing;

namespace  MianXiangProject.DataTableOption.MXCompanyOption.Dtos
{
    public class MXCompanyEditDto
    {

        /// <summary>
        /// Id
        /// </summary>
        public int? Id { get; set; }         


        
		/// <summary>
		/// CompanyName
		/// </summary>
		[MaxLength(100, ErrorMessage="CompanyName超出最大长度")]
		[MinLength(1, ErrorMessage="CompanyName小于最小长度")]
		[Required(ErrorMessage="CompanyName不能为空")]
		public string CompanyName { get; set; }



		/// <summary>
		/// CompanyType
		/// </summary>
		[MaxLength(100, ErrorMessage="CompanyType超出最大长度")]
		[MinLength(1, ErrorMessage="CompanyType小于最小长度")]
		[Required(ErrorMessage="CompanyType不能为空")]
		public string CompanyType { get; set; }



		/// <summary>
		/// Description
		/// </summary>
		public string Description { get; set; }




    }
}