﻿using MianXiangProject.DataTableOption.MXAttributeOption.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MianXiangProject.Web.Models.MXAttributeViewDtos
{
    public class MXAttributeViewModel
    {
        public IReadOnlyList<MXAttributeListDto> MXAttributeList { get; internal set; }
    }
}
