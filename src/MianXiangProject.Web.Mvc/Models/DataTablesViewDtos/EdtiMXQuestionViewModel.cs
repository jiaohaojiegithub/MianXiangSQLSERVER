using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;
using MianXiangProject.DataTableOption.MXJobOption.Dtos;
using MianXiangProject.DataTableOption.MXQuestionOption.Dtos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MianXiangProject.Web.Models.DataTablesViewDtos
{
    public class EdtiMXQuestionViewModel
    {
        public MXQuestionListDto MXQuestionInfo { get;  set; }
        public IReadOnlyList<MXCompanyListDto> MXCompanyList { get; internal set; }
        public IReadOnlyList<MXJobListDto> MXJobList { get; internal set; }

        /// <summary>
        /// 选项
        /// </summary>
        /// <param name="Options"></param>
        /// <returns></returns>
        public Dictionary<string, string> GetOptions(string Options)
        {
            if (string.IsNullOrEmpty(Options))
            {
                return null;
            }
            else
            {
                return JsonConvert.DeserializeObject<Dictionary<string, string>>(Options);
            }
        }
    }
}
