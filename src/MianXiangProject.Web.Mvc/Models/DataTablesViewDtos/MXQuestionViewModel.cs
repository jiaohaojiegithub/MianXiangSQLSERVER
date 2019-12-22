using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;
using MianXiangProject.DataTableOption.MXJobOption.Dtos;
using MianXiangProject.DataTableOption.MXQuestionOption.Dtos;
using MianXiangProject.SharedCommand;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MianXiangProject.Web.Models.DataTablesViewDtos
{
    public class MXQuestionViewModel
    {
        public IReadOnlyList<MXQuestionListDto> MXQuestionList { get;  set; }
        public IReadOnlyList<MXCompanyListDto> MXCompanyList { get;  set; }
        public IReadOnlyList<MXJobListDto> MXJobList { get;  set; }

        public Dictionary<string, string> GetOption(string Options)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(Options);
        }
        /// <summary>
        /// 获取关联岗位
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetTestQuestions_MXJob(int Id)
        {
            return MXJobList.Where(x => x.Id == Id).Select(x => x.JobName).FirstOrDefault();
        }
        /// <summary>
        /// 获取公司
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string GetTestQuestions_MXCompany(int Id)
        {
            return MXCompanyList.Where(x => x.Id == Id).Select(x => x.CompanyName).FirstOrDefault();
        }
        /// <summary>
        ///获取我的状态
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public string GetStateColor(DataState state)
        {
            switch (state)
            {
                case DataState.启用:
                    return "green";
                case DataState.禁用:
                    return "red";
                default: return "";
            }
        }
    }
}
