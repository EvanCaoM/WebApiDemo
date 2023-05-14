using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Abc()
        {
            return Content("ApiGateway");
        }

        [Authorize]
        public IActionResult Cookie()
        {
            return Content("bank account");
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Jwt()
        {
            return Content(User.FindFirst("Name").Value);
        }

        /// <summary>
        /// Cookie和Header都支持，使用Authorize认证失败时会自动将请求重定向到配置的登录页面，默认的登录页面路径是"/Account/Login"
        /// </summary>
        /// <returns></returns>
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme + "," + CookieAuthenticationDefaults.AuthenticationScheme)]
        public IActionResult AnyOne()
        {
            return Content(User.FindFirst("Name").Value);
        }
    }
}
