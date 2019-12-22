using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MianXiangProject.Web.Models.SharedDropDownList
{
    public class EnumToList<TEnum> where TEnum:Enum
    {
        /// <summary>
        /// 获取枚举下拉数据
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> EnumToDropDownList()
        {
            var result = (from int value in Enum.GetValues(typeof(TEnum))
                                        select new SelectListItem
                                        {
                                            Value = value.ToString(),
                                            Text = Enum.GetName(typeof(TEnum), value)
                                        }).ToList();
            return result;
        }
        /// <summary>
        /// 编辑选中
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> EnumToDropDownList(TEnum input)
        {
            var result = (from int value in Enum.GetValues(typeof(TEnum))
                          select new SelectListItem
                          {
                              Value = value.ToString(),
                              Text = Enum.GetName(typeof(TEnum), value),
                              Selected = Enum.GetName(typeof(TEnum),input)== Enum.GetName(typeof(TEnum), value)
                          }).ToList();
            return result;
        }
    }
}
