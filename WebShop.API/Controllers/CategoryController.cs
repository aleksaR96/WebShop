﻿using System;
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
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        public ActionResult Get()
        {
            CategoryBusiness cb = new CategoryBusiness();
            return Ok(cb.GetAllCategories());
        }
    }
}