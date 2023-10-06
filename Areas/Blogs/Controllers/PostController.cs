using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMVC.Models;
using AppMVC.Models.Blogs;
using Microsoft.AspNetCore.Identity;
using AppMVC.Areas.Blogs.Models;
using AppMVC.Utilities;

namespace AppMVC.Areas.Blogs.Controllers
{
    [Area("Blogs")]
    [Route("/Areas/Blogs/Post/[action]/{id?}")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PostController> _logger;
        private readonly UserManager<AppUser> _usermanger;

        [TempData]
        public string StatusMessage {get; set;}

        public PostController(ILogger<PostController> logger ,AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _logger = logger;
            _usermanger = userManager;
        }

        int ITEMS_PER_PAGE = 10;
        // GET: Blogs/Post
        public async Task<IActionResult> Index([FromQuery(Name = "p")] int currentpage, int pagesize)
        {
            var listPosts = _context.posts
                .Include (p => p.Author)
                .Include (p => p.PostCategories)
                .ThenInclude (c => c.Category)
                .OrderByDescending (p => p.DateCreated);

            _logger.LogInformation (currentpage.ToString ());
            // Lấy tổng số dòng dữ liệu
            var totalItems = listPosts.Count ();
            // Tính số trang hiện thị (mỗi trang hiện thị ITEMS_PER_PAGE mục)
            int totalPages = (int) Math.Ceiling ((double) totalItems / ITEMS_PER_PAGE);
            //Current page
            if(currentpage > totalPages) currentpage = totalPages;
            if(currentpage < 1) currentpage = 1;

            if (currentpage > totalPages)
                return RedirectToAction (nameof (Index), new { page = totalPages });
            var pagingModel = new PagingModel()
            {
                countpages = totalPages,
                currentpage = currentpage,
                generateUrl = (pagenum) => Url.Action("Index", new {
                    p = pagenum,
                    pagesize = pagesize 
                })
            };

            var posts = await listPosts
                .Skip (ITEMS_PER_PAGE * (currentpage - 1))
                .Take (ITEMS_PER_PAGE)
                .ToListAsync ();

            // return View (await listPosts.ToListAsync());
            ViewBag.pageIndex = (currentpage - 1) * totalPages;
            ViewBag.pagingModel = pagingModel;
            ViewBag.totalItems = totalItems;

            // ViewData["pageNumber"] = pageNumber;
            // ViewData["totalPages"] = totalPages;

            return View(posts);
        }

        // GET: Blogs/Post/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: Blogs/Post/Create
        public async Task<IActionResult> Create()
        {
            // ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id");
            var categories = await _context.category.ToListAsync();
            ViewData["Category"] = new MultiSelectList(categories, "Id", "Title");
            return View();
        }

        // POST: Blogs/Post/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Slug,Content,Published,CategoriesIDs")] CreatePostModel post)
        {
            var categories = await _context.category.ToListAsync();
            ViewData["Category"] = new MultiSelectList(categories, "Id", "Title");

            if(await _context.posts.AnyAsync(c => c.Slug == post.Slug))
            {
                ModelState.AddModelError("Slug", "Slug was Exist");
                return View(post);
            }

            if(post.Slug == null)
            {
                post.Slug = AppUtilities.GenerateSlug(post.Title);
            }
            // if (ModelState.IsValid)
            // {
                var user = await _usermanger.GetUserAsync(this.User);
                post.DateCreated = post.DateUpdated = DateTime.Now;
                post.AuthorId = user?.Id == null ? "f5748365-d8e8-40ee-847d-b32ade8de7bf" : user.Id;
                _context.Add(post);

                if(post.CategoriesIDs != null)
                {
                    foreach (var cateId in post.CategoriesIDs)
                    {
                        _context.Add(new PostCategory(){
                            CategoryID = cateId,
                            Post = post
                        });
                    }
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", post.AuthorId);
            //return View(post);
        }

        // GET: Blogs/Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var post = await _context.posts.FindAsync(id);
            var post = await _context.posts.Include(p => p.PostCategories).FirstOrDefaultAsync (p => p.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            
            var postEdit = new CreatePostModel()
            {
                PostId = post.PostId,
                Title = post.Title,
                Content = post.Content,
                Slug = post.Slug,
                Description = post.Description,
                CategoriesIDs = post.PostCategories.Select(pc => pc.CategoryID).ToArray()
            };

            var categories = await _context.category.ToListAsync();
            ViewData["Category"] = new MultiSelectList(categories,"Id", "Title");
            return View(postEdit);
        }

        // POST: Blogs/Post/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,Description,Slug,Content,Published,CategoriesIDs")] CreatePostModel post)
        {
            var postUpdate = await _context.posts.Include(p => p.PostCategories).FirstOrDefaultAsync(p => p.PostId == id);
            if (postUpdate == null)
            {
                return NotFound();
            }
            if(post.Slug == null)
            {
                post.Slug = AppUtilities.GenerateSlug(post.Title);
            }

            if(await _context.category.AnyAsync(p => p.Slug == post.Slug && p.Id != id))
            {
                ModelState.AddModelError("Slug", "Slug was Exist");
                return View(post);
            }

            // if (ModelState.IsValid)
            // {
                try
                {
                    if(postUpdate == null)
                    {
                        return NotFound();
                    }

                    postUpdate.Title = post.Title;
                    postUpdate.Description = post.Description;
                    postUpdate.Content = post.Content;
                    postUpdate.Slug = post.Slug;
                    postUpdate.Published = post.Published;
                    postUpdate.DateUpdated = DateTime.Now;

                    if(post.CategoriesIDs == null) post.CategoriesIDs = new int[] {};

                    var oldCateIds = postUpdate.PostCategories.Select(p => p.CategoryID).ToArray();
                    var newCateIds = post.CategoriesIDs;

                    var removeCatePosts = from postCate in postUpdate.PostCategories
                                            where(!newCateIds.Contains(postCate.CategoryID))
                                            select postCate;
                    _context.postCategories.RemoveRange(removeCatePosts); 

                    var addCateIds = from newCate in newCateIds
                                    where(!oldCateIds.Contains(newCate))
                                    select newCate;
                    foreach (var cateId in addCateIds)
                    {
                        _context.postCategories.Add(new PostCategory(){
                            PostID = id,
                            CategoryID = cateId
                        });
                    }

                    _context.Update(post);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostExists(post.PostId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
           // }
            StatusMessage = "Update Successfully";
            ViewData["AuthorId"] = new SelectList(_context.Users, "Id", "Id", post.AuthorId);
            return View(post);
        }

        // GET: Blogs/Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = await _context.posts
                .Include(p => p.Author)
                .FirstOrDefaultAsync(m => m.PostId == id);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Blogs/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = await _context.posts.FindAsync(id);
            _context.posts.Remove(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostExists(int id)
        {
            return _context.posts.Any(e => e.PostId == id);
        }
    }
}
