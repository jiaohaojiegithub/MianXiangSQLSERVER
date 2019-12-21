﻿using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using MianXiangProject.Controllers;

namespace MianXiangProject.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : MianXiangProjectControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
