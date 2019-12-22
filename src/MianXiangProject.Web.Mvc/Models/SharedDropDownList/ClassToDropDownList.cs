
using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;
using MianXiangProject.DataTableOption.MXJobOption.Dtos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MianXiangProject.Web.Models.SharedDropDownList
{
    public class ClassToDropDownList
    {
      /// <summary>
      /// 获取公司下拉数据
      /// </summary>
      /// <param name="companyDtos"></param>
      /// <param name="Id"></param>
      /// <returns></returns>
        public static IEnumerable<SelectListItem> MXCompanyToDropDownList(IReadOnlyList<MXCompanyListDto> companyDtos,int Id=0)
        {
            var result = new List<SelectListItem> {
            new SelectListItem{
            Value="0",
            Text="取消绑定",
            Selected=Id==0
            }
            };
            result.AddRange(companyDtos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.CompanyName,
                Selected=x.Id==Id
            }).ToList()) ;
            return result;
        }
        /// <summary>
        /// 获取岗位下拉数据
        /// </summary>
        /// <param name="jobDtos"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> MXJobToDropDownList(IReadOnlyList<MXJobListDto> jobDtos, int Id = 0)
        {
            var result = new List<SelectListItem> {
            new SelectListItem{
            Value="0",
            Text="取消绑定",
            Selected=Id==0
            }
            };
            result.AddRange(jobDtos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.JobName,
                Selected = x.Id == Id
            }).ToList());
            return result;
        }

    }
}
