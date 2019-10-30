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
    public class PropertiesController : ControllerBase
    {
        [HttpGet("{id}")]
        [Produces("application/json")]
        public ActionResult Get(int id)
        {
            PropertyListBusiness plb = new PropertyListBusiness();
            return Ok(plb.GetAllPropertyListByPropertyGroup(new PropertyGroupsModel(id)));
        }
    }
}