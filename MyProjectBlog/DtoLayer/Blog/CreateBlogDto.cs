using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Blog
{
    public class CreateBlogDto
    {
        public int BlogID { get; set; }
        public string Blo1Title { get; set; }
        public string BlogContent { get; set; }
        public string BlogThumbnailImage { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogCreateDate { get; set; }
        public bool BlogStatus { get; set; }
        public int CategoryBy { get; set; }
        public virtual Category Category { get; set; }
        public int WriterBy { get; set; }
        public int WriterID { get; set; }
        public string WriterName { get; set; }
        public EntityLayer.Writer Writer { get; set; }
    }
}
