

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MianXiangProject.CommandShare.Models;

namespace MianXiangProject.DataTableOption.MXJobOption.Dtos
{
    public class MXJobListDto : MXEntityDto 
    {

        
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




    }
}