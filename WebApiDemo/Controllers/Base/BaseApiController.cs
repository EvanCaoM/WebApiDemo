using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApiDemo.Controllers.Base
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseApiController : BaseController
    {
    }
}
