using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IBlogPost
    {
        rm_SingleBlogPost Get_SingleBlogPost(string slug);
        rm_MultipleBlogPosts Get_MultipleBlogPosts(string tag);
        rm_SingleBlogPost Create_BlogPost(rm_SingleBlogPost blogPost);
        rm_SingleBlogPost Update_BlogPost(rm_SingleBlogPost blogPost);
    }
}
