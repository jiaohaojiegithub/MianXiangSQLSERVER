using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using MianXiangProject.Controllers;
using MianXiangProject.DataTableOption.MXCompanyOption;
using MianXiangProject.DataTableOption.MXCompanyOption.Dtos;
using MianXiangProject.Web.Models.DataTablesViewDtos;
using Microsoft.AspNetCore.Mvc;

namespace MianXiangProject.Web.Controllers
{
    public class MXCompanyController : MianXiangProjectControllerBase
    {
        private readonly IMXCompanyAppService _MXCompanyAppService;

        public MXCompanyController(IMXCompanyAppService MXCompanyAppService)
        {
            _MXCompanyAppService = MXCompanyAppService;
        }

        public async Task<IActionResult> Index()
        {
            var modelDto = (await _MXCompanyAppService.GetPaged(new GetMXCompanysInput())).Items;
            var viewModel = new MXCompanyViewModel
            {
                MXCompanyList = modelDto
            };
            return View(viewModel);
        }

        public async Task<IActionResult> EditMXCompanyModal(int Id)
        {
            var modelDto = await _MXCompanyAppService.GetById(new EntityDto<int> { Id = Id });
            var editViewModel = new EdtiMXCompanyViewModel
            {
                MXCompanyInfo = modelDto
            };
            return View("_EditMXCompanyModal", editViewModel);
        }
    }
}