using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppMVC.Models.Blogs
{
   [Table("PostCategory")]
    public class PostCategory
    {
        public int PostID {set; get;}

        public int CategoryID {set; get;}

        [ForeignKey("PostID")]
        public Post Post {set; get;}

        [ForeignKey("CategoryID")]
        public Category Category {set; get;}
    }
}