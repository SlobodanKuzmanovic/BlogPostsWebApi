using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBlogPost
    {
        rm_SingleBlogPost Get_SingleBlogPost();
        rm_MultipleBlogPosts Get_MultipleBlogPosts();
    }
}
