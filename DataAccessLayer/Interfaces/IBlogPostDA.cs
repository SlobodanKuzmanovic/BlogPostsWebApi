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
        db_SingleBlogPost Create_BlogPost(db_SingleBlogPost blogPost);
        rm_SingleBlogPost Update_BlogPost(rm_SingleBlogPost blogPost);
        void Create_AddTagToPost(long PkTagId, long PkPostId);
    }
}
