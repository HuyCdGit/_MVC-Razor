using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppMVC.Models;
using AppMVC.Models.Blogs;
using Bogus;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppMVC.Areas.Database.Controllers
{
    [Area("Database")]
    [Route("/Database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _AppMVCDbContext;
        private readonly UserManager<AppUser> _usermanager;

        [TempData]
        public string StatusMess {get; set;}

        public DbManageController(UserManager<AppUser> userManager ,AppDbContext AppMVCDbContext)
        {
            _AppMVCDbContext = AppMVCDbContext;
            _usermanager = userManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DeleteDB()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteDBAsync()
        {
            var success = await _AppMVCDbContext.Database.EnsureDeletedAsync();

            StatusMess = success ? "Delete DB Successfully" : "Cant Delete DB";

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Migrate()
        {
            await _AppMVCDbContext.Database.MigrateAsync();

            StatusMess = "Update migrate successfully";
            
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> SeedData()
        {
            StatusMess = "vua cap nhat seed post category";
            SeedPostCategory();
            return RedirectToAction(nameof(Index));
        }


        private bool RemoveSeed()
        {
            try
            {
                _AppMVCDbContext.category.RemoveRange(_AppMVCDbContext.category.Where(c => c.Content.Contains("[fakerData]")));
                _AppMVCDbContext.posts.RemoveRange(_AppMVCDbContext.posts.Where(c => c.Content.Contains("[fakerData]")));
                _AppMVCDbContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                StatusMess = "Error" + e.Message;
            }
        }
        private void SeedPostCategory()
        {
            if (RemoveSeed())
            {
                Randomizer.Seed = new Random(8675309);
                var fakercategory = new Faker<Category>();
                int cm = 1;
                fakercategory.RuleFor(c => c.Title, f =>  $"CM{cm++}" + f.Lorem.Sentence(1,2).Trim('.'));
                fakercategory.RuleFor(c => c.Content, f => f.Lorem.Sentences(5)+"[fakerData]");
                fakercategory.RuleFor(c => c.Slug, f => f.Lorem.Slug());

                var cate1 = fakercategory.Generate();
                    var cate11 = fakercategory.Generate();
                    var cate12 = fakercategory.Generate();
                var cate2 = fakercategory.Generate();
                    var cate21 = fakercategory.Generate();
                        var cate211 = fakercategory.Generate();

                cate11.ParentCategory = cate1;
                cate12.ParentCategory = cate1;
                cate211.ParentCategory = cate21;
                cate21.ParentCategory = cate2;

                var categories = new Category[]{cate1, cate2, cate11, cate12, cate21, cate211};

                _AppMVCDbContext.category.AddRange(categories);

                var rcateIndx = new Random();
                int bv = 1;
                var user = _usermanager.GetUserAsync(this.User).Result;
                
                var fakerpost = new Faker<Post>();

                fakerpost.RuleFor(a => a.AuthorId, f => (user == null) ? "f5748365-d8e8-40ee-847d-b32ade8de7bf" : user.Id);
                fakerpost.RuleFor(a => a.Content, f => f.Lorem.Paragraphs(7)+"[fakeData]");
                fakerpost.RuleFor(a => a.DateCreated, f => f.Date.Between(new DateTime(2023,1,1), new DateTime(2023,12,30)));
                fakerpost.RuleFor(a => a.Description, f => f.Lorem.Sentences(3));
                fakerpost.RuleFor(a => a.Published, f => true);
                fakerpost.RuleFor(a => a.Slug, f => f.Lorem.Slug());
                fakerpost.RuleFor(c => c.Title, f =>  $"BV{bv++}" + f.Lorem.Sentence(1,2).Trim('.'));

                List<Post> posts = new List<Post>();
                List<PostCategory> postCategories = new List<PostCategory>();

                for (var i = 1; i < 40; i++)
                {
                    var post = fakerpost.Generate();
                    post.DateUpdated = post.DateCreated;
                    posts.Add(post);
                    postCategories.Add(new PostCategory(){
                        Post = post,
                        Category = categories[rcateIndx.Next(5)]
                    });
                }
                _AppMVCDbContext.AddRange(posts);
                _AppMVCDbContext.AddRange(postCategories);
                _AppMVCDbContext.SaveChanges();
            }
        }
    }
}