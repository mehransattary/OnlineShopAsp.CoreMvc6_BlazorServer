using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BlogCategoryController : Controller
{
    private readonly AppDbContext context;
    private readonly IBlogCategoryService BlogCategoryService;
    public BlogCategoryController(IBlogCategoryService BlogCategoryService, AppDbContext context)
    {
        this.BlogCategoryService = BlogCategoryService;
        this.context = context;

    }

    public async Task<IActionResult> Index()
    {
        return View(await context.BlogCategories.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BlogCategory BlogCategory, IFormFile? BlogCategoryImageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await BlogCategoryService.AddBlogCategoryAsync(BlogCategory, BlogCategoryImageFile, "BlogCategory");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(BlogCategory);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var BlogCategory = await context.BlogCategories.FindAsync(id);
        return View(BlogCategory);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(BlogCategory BlogCategory, IFormFile? BlogCategoryImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await BlogCategoryService.UpdateBlogCategoryAsync(BlogCategory, BlogCategoryImageFile, "BlogCategory");
            if (res)
                return RedirectToAction("Index");
        }
        return View(BlogCategory);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var BlogCategory = await context.BlogCategories.FindAsync(id);
        return View(BlogCategory);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var BlogCategory = await context.BlogCategories.FindAsync(id);
            if (BlogCategory != null)
            {
                context.BlogCategories.Remove(BlogCategory);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(BlogCategory);



        }
        return NotFound();

    }
}
