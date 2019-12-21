using Microsoft.AspNetCore.Antiforgery;
using MianXiangProject.Controllers;

namespace MianXiangProject.Web.Host.Controllers
{
    public class AntiForgeryController : MianXiangProjectControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
