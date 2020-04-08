using CommonLayer;
using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DataAccessLayer
{
    internal class TagDA : ITagDA
    {
        public Tag Create_Tag(string tag)
        {
            string queryString = "dbo.st_Create_Tag";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@tag", tag);

                    Tag tagModel = null;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tagModel = new Tag();
                                tagModel.PkTagId = Convert.ToInt64(reader["PkTagId"]);
                                tagModel.tag = tag;
                            }
                        }
                    }
                    catch (Exception exception)
                    {
                        throw new Exception(exception.Message);
                    }

                    return tagModel;
                }
            }
        }

        public Tag Get_Tag(string tag)
        {
            string queryString = "dbo.st_Get_Tag";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@tag", tag);

                Tag tagModel = null;

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tagModel = new Tag();
                            tagModel.PkTagId = Convert.ToInt32(reader["PkTagId"]);
                            tagModel.tag = reader["tag"].ToString();
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }

                return tagModel;
            }
        }

        public rm_Tag Get_Tags()
        {
            string queryString = "dbo.st_Get_Tags";

            using (SqlConnection connection = new SqlConnection(ConnectionString.ConStr))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                rm_Tag rm_tagModel = new rm_Tag();

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            rm_tagModel.tags.Add(reader["tag"].ToString());
                            //tagModel.tag = reader["tag"].ToString();
                        }
                    }
                }
                catch (Exception exception)
                {
                    throw new Exception(exception.Message);
                }

                return rm_tagModel;
            }
        }
    }
}