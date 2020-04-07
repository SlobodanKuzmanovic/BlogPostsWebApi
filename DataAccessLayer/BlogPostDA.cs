using CommonLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    internal class BlogPostDA : IBlogPostDA
    {
        public rm_SingleBlogPost Get_SingleBlogPost(string slug)
        {
            throw new NotImplementedException();
        }

        public rm_MultipleBlogPosts Get_MultipleBlogPosts(string tag)
        {
            throw new NotImplementedException();
        }
    }
}
