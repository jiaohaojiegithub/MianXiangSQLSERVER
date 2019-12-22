
using AutoMapper;
using MianXiangProject.DataTables;
using  MianXiangProject.DataTableOption.MXQuestionOption.Dtos;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MianXiangProject.DataTableOption.MXQuestionOption.Dtos
{

    /// <summary>
    /// 配置MXQuestion的AutoMapper
    /// </summary>
    public class MXQuestionMapper : Profile
    {
        public MXQuestionMapper()
        {
            CreateMap<MXQuestion, MXQuestionListDto>()
               ;
            CreateMap<MXQuestionListDto, MXQuestion>()
                 ; 

            CreateMap<MXQuestionEditDto, MXQuestion>()
                 .ForMember(x => x.Options, o => o.MapFrom(input => JsonConvert.SerializeObject(input.Options)));
            CreateMap<MXQuestion, MXQuestionEditDto>()
                  .ForMember(x => x.Options, o => o.MapFrom(input => JsonConvert.DeserializeObject<Dictionary<string, string>>(input.Options)));

             CreateMap<MXQuestion, CreateOrUpdateMXQuestionInputTow>()
               ;
            CreateMap<CreateOrUpdateMXQuestionInputTow, MXQuestion>()
                 ; 

        }
    }
}
