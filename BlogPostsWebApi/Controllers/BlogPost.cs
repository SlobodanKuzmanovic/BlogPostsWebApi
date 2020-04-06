using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogPostsWebApi.Controllers
{
    [ApiController]
    [Route("api/posts")]
    public class BlogPost
    {


        [HttpGet]
        [Route("~/api/posts")]
        public JsonResult Get()
        {
            return new JsonResult("Get");
        }

        [HttpGet]
        [Route("~/api/posts/:slug")]
        public JsonResult Get(string slug)
        {
            return new JsonResult("Get with slug: " + slug);
        }


        [HttpGet]
        [Route("welcome")]
        public JsonResult Welcome()
        {
            return new JsonResult("Welcome");
        }
    }
}
