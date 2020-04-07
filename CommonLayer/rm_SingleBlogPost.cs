using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class rm_SingleBlogPost
    {
        public SingleBlogPost blogPost { get; set; }

        public rm_SingleBlogPost()
        {
            blogPost = new SingleBlogPost();
        }
    }
}
