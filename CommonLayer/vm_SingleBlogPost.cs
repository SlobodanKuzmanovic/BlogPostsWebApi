using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class vm_SingleBlogPost
    {
        public vmi_SingleBlogPost blogPost { get; set; }
        public vm_SingleBlogPost()
        {
            blogPost = new vmi_SingleBlogPost();
        }
    }
}
