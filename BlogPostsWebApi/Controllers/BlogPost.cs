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
        [Route("~/api/posts/{slug}")]
        public JsonResult SingleBlogPost(string slug)
        {
            return new JsonResult("Get with slug: " + slug);
        }

        [HttpGet]
        [Route("~/api/posts")]
        public JsonResult MultipleBlogPosts(string tag = "")
        {
            return new JsonResult("Get");
        }


        [HttpGet]
        [Route("welcome")]
        public JsonResult Welcome()
        {
            return new JsonResult("Welcome");
        }
    }
}
