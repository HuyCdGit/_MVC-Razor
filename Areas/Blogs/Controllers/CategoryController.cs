using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMVC.Models;
using AppMVC.Models.Blogs;

namespace AppMVC.Areas.Blogs.Controllers
{
    [Area("Blogs")]
    [Route("/Areas/Blogs/Category/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Blogs/Category
        public async Task<IActionResult> Index()
        {
            // var appDbContext = _context.category.Include(c => c.ParentCategory);
            
            var qr = (from c in _context.category select c)
                        .Include(c => c.CategoryChildren)
                        .Include(c => c.ParentCategory);
            
            var categories = (await qr.ToListAsync()).Where(c => c.ParentCategory == null).ToList();
            return View(categories);
        }

        // GET: Blogs/Category/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.category
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        private void SelectLstItem(List<Category> source, List<Category> des, int level)
        {
            var prefix = string.Concat(Enumerable.Repeat("**", level));
            foreach (var item in source)
            {
                item.Title = prefix + item.Title;
                des.Add(item);
                if(item.CategoryChildren?.Count > 0)
                {
                    SelectLstItem(item.CategoryChildren.ToList(), des, level + 1);
                }
            }
        }
        // GET: Blogs/Category/Create
        public async Task<IActionResult> Create()
        {
            // ViewData["ParentCategoryId"] = new SelectList(_context.category, "Id", "Slug");
            var qr = (from c in _context.category select c)
                    .Include(c => c.CategoryChildren)
                    .Include(c => c.ParentCategory);
            var categories = (await qr.ToListAsync()).Where(c => c.ParentCategory == null).ToList();

            categories.Insert(0, new Category(){
                Id = -1,
                Title = "None"
            });

            var items = new List<Category>();

            SelectLstItem(categories, items, 0);

            var selectLst = new SelectList(items, "Id", "Title");
            ViewData["ParentCategoryId"] = selectLst;
            return View();
        }

        // POST: Blogs/Category/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParentCategoryId,Title,Content,Slug")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            // ViewData["ParentCategoryId"] = new SelectList(_context.category, "Id", "Slug", category.ParentCategoryId);
            var qr = (from c in _context.category select c)
                    .Include(c => c.CategoryChildren)
                    .Include(c => c.ParentCategory);
            var categories = (await qr.ToListAsync()).Where(c => c.ParentCategory == null).ToList();

            categories.Insert(0, new Category(){
                Id = -1,
                Title = "None"
            });

            var items = new List<Category>();

            SelectLstItem(categories, items, 0);

            var selectLst = new SelectList(items, "Id", "Title");
            ViewData["ParentCategoryId"] = selectLst;
            return View(category);
        }

        // GET: Blogs/Category/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.category, "Id", "Slug", category.ParentCategoryId);
            return View(category);
        }

        // POST: Blogs/Category/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParentCategoryId,Title,Content,Slug")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentCategoryId"] = new SelectList(_context.category, "Id", "Slug", category.ParentCategoryId);
            return View(category);
        }

        // GET: Blogs/Category/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.category
                .Include(c => c.ParentCategory)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Blogs/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {        
            // var category = await _context.category.FindAsync(id);

            var category = await _context.category
                        .Include(c => c.CategoryChildren).FirstOrDefaultAsync(c => c.Id == id);
            
            if(category == null)
            {
                NotFound();
            }

            foreach (var cCategory in category.CategoryChildren)
            {
                cCategory.ParentCategoryId = category.ParentCategoryId;
            }

            _context.category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.category.Any(e => e.Id == id);
        }
    }
}
