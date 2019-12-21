

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using MianXiangProject.CommandShare.Models;

namespace  MianXiangProject.DataTableOption.MXAttributeOption.Dtos
{
    public class MXAttributeListDto : MXEntityDto 
    {

        
		/// <summary>
		/// AttributeName
		/// </summary>
		[MaxLength(100, ErrorMessage="AttributeName超出最大长度")]
		[MinLength(1, ErrorMessage="AttributeName小于最小长度")]
		[Required(ErrorMessage="AttributeName不能为空")]
		public string AttributeName { get; set; }



		/// <summary>
		/// AttributeValue
		/// </summary>
		[MaxLength(100, ErrorMessage="AttributeValue超出最大长度")]
		[MinLength(1, ErrorMessage="AttributeValue小于最小长度")]
		[Required(ErrorMessage="AttributeValue不能为空")]
		public string AttributeValue { get; set; }



		/// <summary>
		/// AttributeType
		/// </summary>
		[MaxLength(100, ErrorMessage="AttributeType超出最大长度")]
		[MinLength(1, ErrorMessage="AttributeType小于最小长度")]
		[Required(ErrorMessage="AttributeType不能为空")]
		public string AttributeType { get; set; }



		/// <summary>
		/// Description
		/// </summary>
		public string Description { get; set; }




    }
}