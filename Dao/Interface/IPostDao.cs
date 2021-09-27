using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WonderBlogs.Models;

namespace Dao
{
    public interface IPostDao
    {
        List<Post> GetPostsByUser(int idUser);
        void InsertPost(Post post);
        void UpdatePost(Post post);
        Post GetPostById(int id);

        void UpdatePostToInReview(int Id);

    }
}
