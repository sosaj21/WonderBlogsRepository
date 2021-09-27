using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WonderBlogs.Models;

namespace Dao
{
    public class PostDao : IPostDao
    {

        #region property
        ConnectionFactory connectionFactory = ConnectionFactory.Instance;
        #endregion

        #region constructor
        public PostDao(IConfiguration config)
        {
            connectionFactory.Config = config;
        }
        #endregion


        #region GetPostsByUser
        public List<Post> GetPostsByUser(int idUser)
        {
            try
            {
                using (IDbConnection conn = connectionFactory.Connection)
                {
                    conn.Open();          
                    var post = conn.Query<Post, User, PostState, Post>("dbo.spGetPostsByUser", 
                        (post, user, state) =>
                        {
                            post.Author = user;
                            post.State = state;
                            return post;
                        },
                        new { pIdUser = idUser },
                        commandType: CommandType.StoredProcedure,
                        splitOn: "Id")
                        .ToList();

                    return post;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region GetPostById
        public Post GetPostById(int id)
        {
            try
            {
                using (IDbConnection conn = connectionFactory.Connection)
                {
                    conn.Open();
                    var post = conn.Query<Post, User, PostState, Post>("dbo.spGetPostById",
                        (post, user, state) =>
                        {
                            post.Author = user;
                            post.State = state;
                            return post;
                        },
                        new { pId = id },
                        commandType: CommandType.StoredProcedure,
                        splitOn: "Id")
                        .FirstOrDefault();

                    return post;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region InsertPost
        public void InsertPost(Post post)
        {
            try
            {

                using (IDbConnection conn = connectionFactory.Connection)
                {
                    conn.Open();
                    conn.Execute("dbo.spInsertPost",
                     new
                     {
                         pTitle = post.Title,
                         pBody = post.Body,
                         pAuthor = post.Author.Id                        
                     },
                     commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdatePostToInReview
        public void UpdatePostToInReview(int Id)
        {
            try
            {
                using (IDbConnection conn = connectionFactory.Connection)
                {
                    conn.Open();
                    conn.Execute("dbo.spUpdatePostToInReview",
                     new
                     {                        
                         pId = Id
                     },
                     commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region UpdatePost
        public void UpdatePost(Post post)
        {
            try
            {
                using (IDbConnection conn = connectionFactory.Connection)
                {
                    conn.Open();
                    conn.Execute("dbo.spUpdatePost",
                     new
                     {
                         pId = post.Id,
                         pTitle = post.Title,
                         pBody = post.Body
                     },
                     commandType: CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


    }
}
