using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class rm_MultipleBlogPosts
    {
        public List<SingleBlogPost> blogPosts { get; set; }

        public rm_MultipleBlogPosts()
        {
            blogPosts = new List<SingleBlogPost>();
        }
    }
}
