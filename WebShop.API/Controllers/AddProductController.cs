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
    public class AddProductController : ControllerBase
    {
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult Get(int id)
        {
            if(id == 1)
            {
                CategoryBusiness cb = new CategoryBusiness();
                return Ok(cb.GetAllCategories());
            }
            else if (id == 2)
            {
                BrandsBusiness bb = new BrandsBusiness();
                return Ok(bb.GetAllBrands());
            }
            
            return NotFound();
        }
    }
}