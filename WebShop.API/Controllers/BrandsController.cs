using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Business;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        public ActionResult Get()
        {
            BrandsBusiness bb = new BrandsBusiness();
            return Ok(bb.GetAllBrands());
        }
    }
}