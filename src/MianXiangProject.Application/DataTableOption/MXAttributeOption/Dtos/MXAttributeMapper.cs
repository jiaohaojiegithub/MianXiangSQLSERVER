using AutoMapper;
using MianXiangProject.DataTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTableOption.MXAttributeOption.Dtos
{
    /// <summary>
    /// 配置MXAttribute的AutoMapper
    /// </summary>
    public class  MXAttributeMapper : Profile
    {
        public MXAttributeMapper()
        {
            CreateMap<MXAttribute, MXAttributeListDto>();
            CreateMap<MXAttributeListDto, MXAttribute>();

            CreateMap<MXAttributeEditDto, MXAttribute>();
            CreateMap<MXAttribute, MXAttributeEditDto>();

        }
    }
}
