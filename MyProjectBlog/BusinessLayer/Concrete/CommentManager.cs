using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private ICommentDal _comment;

        public CommentManager(ICommentDal comment)
        {
            _comment = comment;
        }
        public void CommentAdd(Comment comment)
        {
            _comment.Insert(comment);
        }

        public List<Comment> GetCommentwithBlog()
        {
            return _comment.GetListWithBlog();
        }

        public List<Comment> GetByList(int id)
        {
            return _comment.GetListAll(x => x.ByBlog == id);
        }

        public List<Comment> GetList()
        {
            return _comment.GetListAll();
        }

        public void TAdd(Comment t)
        {
            _comment.Insert(t);
        }

        public void TDelete(Comment t)
        {
           _comment.Delete(t);
        }

        public Comment TGetById(int id)
        {
         return _comment.GetByID(id);
        }

        public void TUpdate(Comment t)
        {
            _comment.Update(t);
        }
    }
}
