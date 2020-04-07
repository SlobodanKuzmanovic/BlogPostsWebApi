using BusinessLayer.Interfaces;
using CommonLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    internal class BlogPost : IBlogPost
    {
        private IBlogPostDA _blogPostDA;

        public BlogPost()
        {
            _blogPostDA = DataAccessLayer.Scope.Factory.GetBlogPostDA();
        }

        public rm_SingleBlogPost Get_SingleBlogPost(string slug)
        {
            return _blogPostDA.Get_SingleBlogPost(slug);
        }

        public rm_MultipleBlogPosts Get_MultipleBlogPosts(string tag)
        {
            return _blogPostDA.Get_MultipleBlogPosts(tag);
        }

        public rm_SingleBlogPost Create_BlogPost(rm_SingleBlogPost blogPost)
        {
            return _blogPostDA.Create_BlogPost(blogPost);
        }
    }
}
