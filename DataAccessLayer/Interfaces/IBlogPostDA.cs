using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Interfaces
{
    public interface IBlogPostDA
    {
        rm_SingleBlogPost Get_SingleBlogPost(string slug);
        rm_MultipleBlogPosts Get_MultipleBlogPosts(string tag);
        rm_SingleBlogPost Create_BlogPost(rm_SingleBlogPost blogPost);
    }
}
