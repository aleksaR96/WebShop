using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Business;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddProductController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            CategoryBusiness cb = new CategoryBusiness();
            return Ok(cb.GetAllCategories());
        }
    }
}