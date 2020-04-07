using BusinessLayer.Interfaces;
using CommonLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace BusinessLayer
{
    internal class BlogPost : IBlogPost
    {
        private IBlogPostDA _blogPostDA;
        private ITagBL _tagBL;

        public BlogPost()
        {
            _blogPostDA = DataAccessLayer.Scope.Factory.GetBlogPostDA();
            _tagBL = BusinessLayer.Scope.Factory.GetTagBL();
        }

        public rm_SingleBlogPost Get_SingleBlogPost(string slug)
        {
            return _blogPostDA.Get_SingleBlogPost(slug);
        }

        public rm_MultipleBlogPosts Get_MultipleBlogPosts(string tag)
        {
            return _blogPostDA.Get_MultipleBlogPosts(tag);
        }


        public rm_SingleBlogPost Create_BlogPost(rm_SingleBlogPost blogPost)
        {
            rm_SingleBlogPost rm_SingleBlogPost = null;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var tagList = _tagBL.Create_Tags_IfNotExist(blogPost.blogPost.tagList);

                    //blogPost.blogPost.createdAt = DateTime.Now;

                    rm_SingleBlogPost = _blogPostDA.Create_BlogPost(blogPost);


                    foreach (var item in tagList)
                    {
                        _blogPostDA.Create_AddTagToPost(item.PkTagId, rm_SingleBlogPost.blogPost.PkBlogPostId);
                    }

                    transaction.Complete();
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }
            return rm_SingleBlogPost;
        }

        public rm_SingleBlogPost Update_BlogPost(rm_SingleBlogPost blogPost)
        {
            return _blogPostDA.Update_BlogPost(blogPost);
        }
    }
}
