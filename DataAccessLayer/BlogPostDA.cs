﻿using CommonLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    internal class BlogPostDA : IBlogPostDA
    {
        public rm_SingleBlogPost Get_SingleBlogPost(string slug)
        {
            throw new NotImplementedException();
        }

        public rm_MultipleBlogPosts Get_MultipleBlogPosts(string tag)
        {
            throw new NotImplementedException();
        }

        public db_SingleBlogPost Create_BlogPost(db_SingleBlogPost blogPost)
        {
            string queryString = "dbo.st_Create_BlogPost";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@slug", blogPost.slug);
                    command.Parameters.AddWithValue("@title", blogPost.title);
                    command.Parameters.AddWithValue("@description", blogPost.description);
                    command.Parameters.AddWithValue("@body", blogPost.body);
                    command.Parameters.AddWithValue("@createdAt", blogPost.createdAt);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                blogPost.PkBlogPostId = Convert.ToInt64(reader["PkPostId"]);
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }

                    return blogPost;
                }
            }
        }

        public rm_SingleBlogPost Update_BlogPost(rm_SingleBlogPost blogPost)
        {
            throw new NotImplementedException();
        }

        public void Create_AddTagToPost(long PkTagId, long PkPostId)
        {
            string queryString = "dbo.st_Create_AddTagToPost";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@PkPostId", PkPostId);
                    command.Parameters.AddWithValue("@PkTagId", PkTagId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }
                }
            }
        }
    }
}
