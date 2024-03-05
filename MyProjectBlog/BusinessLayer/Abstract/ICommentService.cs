using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        //void CommentAdd(Comment comment);
        //// void CategoryDelete(Category category);
        //// void CategoryUpdate(Category category);
        //List<Comment> GetList(int id);
        //// Category GetByIdCategory(int id);
        List<Comment> GetCommentwithBlog();
        List<Comment> GetByList(int id);


    }
}
