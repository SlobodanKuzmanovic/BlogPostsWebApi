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
        [Route("{slug}")]
        public rm_SingleBlogPost SingleBlogPost(string slug)
        {
            return _blogPost.Get_SingleBlogPost(slug);
        }

        [HttpGet]
        public rm_MultipleBlogPosts MultipleBlogPosts(string tag)
        {
            return _blogPost.Get_MultipleBlogPosts(tag);
        }

        [HttpPost]
        public rm_SingleBlogPost CreateBlogPost(rm_SingleBlogPost blogPost)
        {
            return _blogPost.Create_BlogPost(blogPost);
        }

        [HttpPut]
        [Route("{slug}")]
        public rm_SingleBlogPost UpdateBlogPost(string slug, vm_SingleBlogPost blogPost)
        {
            return _blogPost.Update_BlogPost(slug, blogPost);
        }

        [HttpDelete]
        [Route("{slug}")]
        public bool DeleteBlogPost(string slug)
        {
            return _blogPost.Delete_BlogPost(slug);
        }


        [HttpGet]
        [Route("welcome")]
        public JsonResult Welcome()
        {
            return new JsonResult("Welcome to API for managing Blog");
        }
    }
}
