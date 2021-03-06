﻿using BusinessLayer.Interfaces;
using CommonLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace BusinessLayer
{
    internal class BlogPostBL : IBlogPost
    {
        private IBlogPostDA _blogPostDA;
        private ITagBL _tagBL;

        public BlogPostBL()
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
            using (var transaction = new TransactionScope())
            {
                try
                {
                    var tagList = _tagBL.Create_Tags_IfNotExist(blogPost.blogPost.tagList);


                    db_SingleBlogPost db_SingleBlogPost = new db_SingleBlogPost()
                    {
                        slug = Get_SlugForPost(blogPost.blogPost.title),
                        title = blogPost.blogPost.title,
                        description = blogPost.blogPost.description,
                        body = blogPost.blogPost.body,
                        createdAt = DateTime.Now
                    };

                    //blogPost.blogPost.createdAt = DateTime.Now;

                    var created_SingleBlogPost = _blogPostDA.Create_BlogPost(db_SingleBlogPost);

                    blogPost.blogPost.slug = created_SingleBlogPost.slug;
                    blogPost.blogPost.createdAt = CommonLayer.Helpers.BlogPostH.dateTimeParserFromString(created_SingleBlogPost.createdAt.ToString());
                    blogPost.blogPost.updatedAt = "";
                    foreach (var item in tagList)
                    {
                        _blogPostDA.Create_AddTagToPost(item.PkTagId, (long)created_SingleBlogPost.PkBlogPostId);
                    }

                    transaction.Complete();
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }
            return blogPost;
        }

        public rm_SingleBlogPost Update_BlogPost(string slug, vm_SingleBlogPost blogPost)
        {
            rm_SingleBlogPost rm_SingleBlogPost = null;

            string newSlug = slug;
            if (!String.IsNullOrEmpty(blogPost.blogPost.title))
            {
                newSlug = Get_SlugForPost(blogPost.blogPost.title);
            }

            db_SingleBlogPost db_SingleBlogPost = new db_SingleBlogPost()
            {
                slug = newSlug,
                title = blogPost.blogPost.title,
                description = blogPost.blogPost.description,
                body = blogPost.blogPost.body,
                updatedAt = DateTime.Now
            };

            var updated_SingleBlogPost = _blogPostDA.Update_BlogPost(slug, db_SingleBlogPost);

            rm_SingleBlogPost = _blogPostDA.Get_SingleBlogPost(updated_SingleBlogPost.slug);

            return rm_SingleBlogPost;
        }

        public string Get_SlugForPost(string title)
        {
            string r_string = Regex.Replace(title, @"[^\w\d\s]", "");
            r_string = r_string.ToLower().Replace(" ", "-");
            byte[] tempBytes;
            tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-1").GetBytes(r_string);
            r_string = System.Text.Encoding.UTF8.GetString(tempBytes);

            var postIfSlugExist = _blogPostDA.Get_SingleBlogPost(r_string);

            if (postIfSlugExist != null)
            {
                return Get_SlugForPost(postIfSlugExist.blogPost.title + "-" + CommonLayer.Helpers.BlogPostH.GenerateRandomNoForSlug());
            }
            return r_string;
        }

        public bool Delete_BlogPost(string slug)
        {
            bool deleted = false;
            using (var transaction = new TransactionScope())
            {
                try
                {
                    _blogPostDA.Delete_TagsFromPost(slug);
                    deleted = _blogPostDA.Delete_BlogPost(slug);

                    transaction.Complete();
                }
                catch (Exception exc)
                {
                    transaction.Dispose();
                    throw exc;
                }
            }

            return deleted;
        }
    }
}
