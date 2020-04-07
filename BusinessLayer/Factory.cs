using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class Factory : IFactory
    {
        public IBlogPost GetBlogPost()
        {
            return new BlogPost();
        }
    }
}
