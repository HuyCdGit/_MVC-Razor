using System.ComponentModel.DataAnnotations;
using AppMVC.Models.Blogs;

namespace AppMVC.Areas.Blogs.Models
{
    public class CreatePostModel : Post {
        [Display(Name = "Chuyên mục")]
        public int[]? CategoriesIDs {get; set;}
    }
}