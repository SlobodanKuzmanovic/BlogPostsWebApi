using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IBlogPostDA
    {
        rm_SingleBlogPost Get_SingleBlogPost();
        rm_MultipleBlogPosts Get_MultipleBlogPosts();
    }
}
