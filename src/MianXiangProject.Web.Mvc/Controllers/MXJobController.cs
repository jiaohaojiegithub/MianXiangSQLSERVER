using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MianXiangProject.Controllers;
using MianXiangProject.DataTableOption.MXJobOption;
using MianXiangProject.DataTableOption.MXJobOption.Dtos;
using MianXiangProject.Web.Models.DataTablesViewDtos;
using Microsoft.AspNetCore.Mvc;

namespace MianXiangProject.Web.Controllers
{
    public class MXJobController : MianXiangProjectControllerBase
    {
        private readonly IMXJobAppService _MXJobAppService;

        public MXJobController(IMXJobAppService MXJobAppService)
        {
            _MXJobAppService = MXJobAppService;
        }

        public async Task<IActionResult> Index()
        {
            var modelDto = (await _MXJobAppService.GetPaged(new GetMXJobsInput())).Items;
            var viewModel = new MXJobViewModel
            {
                MXJobList = modelDto
            };
            return View(viewModel);
        }

        public async Task<IActionResult> EditMXJobModal(int Id)
        {
            var modelDto = await _MXJobAppService.GetById(new EntityDto<int> { Id = Id });
            var editViewModel = new EdtiMXJobViewModel
            {
                MXJobInfo = modelDto
            };
            return View("_EditMXJobModal", editViewModel);
        }
    }
}