using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        private readonly Context _context;

        public EfAppUserDal(Context context)
        {
            _context = context;
        }
        public List<Blog> GetUserBlogs(int userId)
        {
            return _context.Blog.Where(blog => blog.AppUserID == userId).ToList();
        }
    }
}