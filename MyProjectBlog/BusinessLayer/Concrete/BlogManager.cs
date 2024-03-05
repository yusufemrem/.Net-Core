using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        private Context _context;

      
        public BlogManager(IBlogDal blogDal, Context context)
        {
            _blogDal = blogDal;
            _context = context;
        }

        public List<Blog> Test(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }
        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory();
        }

        public Category GetByIdCategory(int id)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogID == id);
        }
        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }


        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }



        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            _blogDal.Update(t);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetByID(id);
        }

     

        public async Task<List<Blog>> GetUserBlogs(int userId)
        {
            return await _context.Blog.Where(blog => blog.AppUserID == userId).ToListAsync();
        }
    }
}
