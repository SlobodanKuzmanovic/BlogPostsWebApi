using CommonLayer;
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
            string queryString = "dbo.st_Get_SingleBlogPost";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@slug", slug);

                rm_SingleBlogPost postModel = null;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            postModel = new rm_SingleBlogPost()
                            {
                                blogPost = new SingleBlogPost()
                                {
                                    slug = reader["slug"].ToString(),
                                    title = reader["title"].ToString(),
                                    description = reader["description"].ToString(),
                                    body = reader["body"].ToString(),
                                    createdAt = CommonLayer.Helpers.BlogPostH.dateTimeParserFromString(reader["createdAt"].ToString()),
                                    updatedAt = CommonLayer.Helpers.BlogPostH.dateTimeParserFromString(reader["updatedAt"].ToString())
                                }
                            };
                            var tags = reader["tags"].ToString();
                            postModel.blogPost.tagList = CommonLayer.Helpers.BlogPostH.fixTagsFromDB(tags);
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }

                return postModel;
            }
        }

        public rm_MultipleBlogPosts Get_MultipleBlogPosts(string tag)
        {
            string queryString = "dbo.st_Get_MultipleBlogPosts";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tag", tag);

                rm_MultipleBlogPosts rmModel = new rm_MultipleBlogPosts();

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SingleBlogPost single = new SingleBlogPost()
                            {
                                slug = reader["slug"].ToString(),
                                title = reader["title"].ToString(),
                                description = reader["description"].ToString(),
                                body = reader["body"].ToString(),
                                createdAt = CommonLayer.Helpers.BlogPostH.dateTimeParserFromString(reader["createdAt"].ToString()),
                                updatedAt = CommonLayer.Helpers.BlogPostH.dateTimeParserFromString(reader["updatedAt"].ToString())
                            };
                            var tags = reader["tags"].ToString();
                            single.tagList = CommonLayer.Helpers.BlogPostH.fixTagsFromDB(tags);
                            rmModel.blogPosts.Add(single);
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }

                return rmModel;
            }
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

        public db_SingleBlogPost Update_BlogPost(string slug, db_SingleBlogPost blogPost)
        {
            string queryString = "dbo.st_Update_BlogPost";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@oldSlug", slug);
                    command.Parameters.AddWithValue("@slug", blogPost.slug);
                    command.Parameters.AddWithValue("@title", blogPost.title);
                    command.Parameters.AddWithValue("@description", blogPost.description);
                    command.Parameters.AddWithValue("@body", blogPost.body);
                    command.Parameters.AddWithValue("@updatedAt", blogPost.updatedAt);

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
