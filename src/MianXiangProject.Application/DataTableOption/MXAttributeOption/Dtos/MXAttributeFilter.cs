using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTableOption.MXAttributeOption.Dtos
{
	/// <summary>
	/// 查询条件
	/// </summary>
    public class MXAttributeFilter
    {
		/// <summary>
		/// Id
		/// </summary>
		public int? Id { get; set; }



		/// <summary>
		/// 属性名
		/// </summary>
		public string AttributeName { get; set; }



		/// <summary>
		/// 属性值
		/// </summary>
		public string AttributeValue { get; set; }



		/// <summary>
		/// 属性类型
		/// </summary>
		public string AttributeType { get; set; }
	}
}
