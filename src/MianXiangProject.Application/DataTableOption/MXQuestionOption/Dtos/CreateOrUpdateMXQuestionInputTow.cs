﻿using MianXiangProject.SharedCommand;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MianXiangProject.DataTableOption.MXQuestionOption.Dtos
{
	/// <summary>
	/// 
	/// </summary>
   public class CreateOrUpdateMXQuestionInputTow
    {

		/// <summary>
		/// Id
		/// </summary>
		public int? Id { get; set; }



		/// <summary>
		/// Question
		/// </summary>
		[MaxLength(1000, ErrorMessage = "Question超出最大长度")]
		[MinLength(1, ErrorMessage = "Question小于最小长度")]
		public string Question { get; set; }



		/// <summary>
		/// QuestionType
		/// </summary>
		public QuestionsTypeEnum QuestionType { get; set; }



		/// <summary>
		/// QuestionCate
		/// </summary>
		public string QuestionCate { get; set; }



		/// <summary>
		/// Answer
		/// </summary>
		[MinLength(1, ErrorMessage = "Answer小于最小长度")]
		public string Answer { get; set; }



		/// <summary>
		/// JobId
		/// </summary>
		[Required(ErrorMessage = "JobId不能为空")]
		public int JobId { get; set; }



		/// <summary>
		/// Knowledge1
		/// </summary>
		public string Knowledge1 { get; set; }



		/// <summary>
		/// Knowledge2
		/// </summary>
		public string Knowledge2 { get; set; }



		/// <summary>
		/// Knowledge3
		/// </summary>
		public string Knowledge3 { get; set; }



		/// <summary>
		/// CompanyId
		/// </summary>
		[Required(ErrorMessage = "CompanyId不能为空")]
		public int CompanyId { get; set; }



		/// <summary>
		/// Options
		/// </summary>
		public string Options { get; set; }



		/// <summary>
		/// Tags
		/// </summary>
		public string Tags { get; set; }

	}
}