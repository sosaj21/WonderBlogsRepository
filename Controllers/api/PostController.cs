using Dao;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using WonderBlogs.Models;

namespace WonderBlogs.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {

        //1=jack, 4 jessica (writers)
        //2= editor
        private const int USUARIO = 2;


        #region properties
        private readonly IPostDao _ipostDao;
        public PostController(IPostDao post)
        {
            _ipostDao = post;
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<List<Post>> Get()
        {
            try
            {               
                //1=jack, 4 jessica (writers)
                //2=editor
                List<Post> posts = _ipostDao.GetPostsByUser(USUARIO);
                return posts;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        #endregion

        #region save
        [Route("save")]
        [HttpPost()]
        public IActionResult Save(Post post)
        {
            try
            {
                if (post.Id == 0)
                {
                    post.Author = new User();                    
                    post.Author.Id = USUARIO;// HttpContext.Session.GetString(LincolnUser.USER_NAME_KEY_SESSION);
                    _ipostDao.InsertPost(post);
                }
                else
                {
                    _ipostDao.UpdatePost(post);
                }

                return Ok();
            }
            catch (Exception ex)
            {                
                return BadRequest();
            }
        }
        #endregion

        #region ValidateSendToReview                
        [HttpGet("validateToReview/{id:int}")]
        public ActionResult<byte> ValidateSendToReview(int id)
        {
            try
            {                
                Post post = _ipostDao.GetPostById(id);

                //Se debe agregar una validacion para el usuario logeado
                if (!Global.IsStateValidToSend(post.State.Id))
                {
                    return Global.postStateNotValid;
                }
                else
                {
                    return Global.allOk;
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion

        #region validateToReview                
        [HttpGet("validateToCheck/{id:int}")]
        public ActionResult<byte> ValidateToReview(int id)
        {
            try
            {
                Post post = _ipostDao.GetPostById(id);

                //Se debe agregar una validacion para el usuario logeado
                if (!Global.IsStateValidToReview(post.State.Id))
                {
                    return Global.postStateNotValid;
                }
                else
                {
                    return Global.allOk;
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion

        #region ValidateToEdit                
        [HttpGet("validateToEdit/{id:int}")]
        public ActionResult<byte> ValidateToEdit(int id)
        {
            try
            {
                Post post = _ipostDao.GetPostById(id);
                //Se debe agregar una validacion para el usuario logeado
                if (!Global.IsStateValidToEdit(post.State.Id))
                {
                    return Global.postStateNotValid;
                }
                else
                {
                    return Global.allOk;
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion

        #region ValidateToDelete                
        [HttpGet("validateToDelete/{id:int}")]
        public ActionResult<byte> ValidateToDelete(int id)
        {
            try
            {
                Post post = _ipostDao.GetPostById(id);
                //Se debe agregar una validacion para el usuario logeado
                if (!Global.IsStateValidToEdit(post.State.Id))
                {
                    return Global.postStateNotValid;
                }
                else
                {
                    return Global.allOk;
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }


        #endregion

        #region sendToReview
        [Route("send/{id}")]
        [HttpPost()]
        public IActionResult sendToReview(int id)
        {
            try
            {
                _ipostDao.UpdatePostToInReview(id);            

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        #endregion

    }
}
