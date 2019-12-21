using AutoMapper;
using MianXiangProject.DataTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MianXiangProject.DataTableOption.WxAppletUserOption.Dtos
{
   public class WXAppletUserMapProfile:Profile
    {
        public WXAppletUserMapProfile()
        {
            CreateMap<WXAppletUserDto, WxAppletUser>();
            CreateMap<WXAppletUserDto, WxAppletUser>().ForMember(x => x.CreationTime, option => option.Ignore());


            CreateMap<CreateWXAppletUserDto, WxAppletUser>();
            CreateMap<CreateWXAppletUserDto, WxAppletUser>().ForMember(x => x.CreationTime, opt => opt.Ignore());
        }
    }
}
