using BusinessLayer.Interfaces;
using CommonLayer;
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
        private IBlogPost _blogPost;

        public BlogPost()
        {
            if (BusinessLayer.Scope.Factory == null)
            {
                BusinessLayer.Scope.Factory = new BusinessLayer.Factory();
            }
            _blogPost = BusinessLayer.Scope.Factory.GetBlogPost();
        }

        [HttpGet]
        [Route("~/api/posts/{slug}")]
        public rm_SingleBlogPost SingleBlogPost(string slug)
        {
            return new rm_SingleBlogPost();
        }

        [HttpGet]
        [Route("~/api/posts")]
        public rm_MultipleBlogPosts MultipleBlogPosts(string tag = "")
        {
            return new rm_MultipleBlogPosts();
        }


        [HttpGet]
        [Route("welcome")]
        public JsonResult Welcome()
        {
            return new JsonResult("Welcome");
        }
    }
}
