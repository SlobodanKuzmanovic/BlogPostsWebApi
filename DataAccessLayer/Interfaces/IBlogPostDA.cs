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
        db_SingleBlogPost Update_BlogPost(string slug, db_SingleBlogPost blogPost);
        void Create_AddTagToPost(long PkTagId, long PkPostId);
        bool Delete_BlogPost(string slug);
        void Delete_TagsFromPost(string slug);
    }
}
