using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Business;
using WebShop.Model;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyGroupsController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        public ActionResult Get()
        {
            PropertyGroupsBusiness pgb = new PropertyGroupsBusiness();
            return Ok(pgb.GetAllPropertyGroups());
        }

        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult Get(int id)
        {
            PropertyGroupsBusiness pgb = new PropertyGroupsBusiness();
            return Ok(pgb.GetPropertyGroupsByCategoryID(new CategoryModel(id)));
        }
    }
}