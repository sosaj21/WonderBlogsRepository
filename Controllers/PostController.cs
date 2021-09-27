using Dao;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WonderBlogs.Models;

namespace WonderBlogs.Controllers
{
    public class PostController : Controller
    {

        #region properties
        private readonly IPostDao _ipostDao;
        public PostController(IPostDao post)
        {
            _ipostDao = post;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        #region PostForm
        //get: Ipad/New        
        public IActionResult PostForm(int id)
        {
            try
            {
                Post post = new Post();
                if (id != 0)
                {
                    post = _ipostDao.GetPostById(id);
                }
                else
                {
                    post.Id = id;
                }

                return View(post);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        #endregion
    }
}
