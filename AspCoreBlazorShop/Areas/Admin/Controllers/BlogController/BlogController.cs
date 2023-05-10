using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Data;
using X.PagedList;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BlogController : Controller
{
    private readonly AppDbContext context;
    private readonly IBlogService BlogService;
    public BlogController(IBlogService BlogService, AppDbContext context)
    {
        this.BlogService = BlogService;
        this.context = context;

    }

    public async Task<IActionResult> Index(int currentpage = 1)
    {
        return View(await context.Blogs.Select(x => new Blog()
        {
            Id = x.Id,
            BlogName = x.BlogName,
            BlogImageSmall = x.BlogImageSmall,
            BlogOrder = x.BlogOrder,
            BlogIsEnableForMainPage = x.BlogIsEnableForMainPage

        }).ToPagedListAsync(currentpage, 1));
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.BlogGroupId = new SelectList(await context.BlogGroups.ToListAsync(), "Id", "BlogGroupName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Blog Blog, IFormFile? BlogImageMainFile, IFormFile? BlogImageSmallFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await BlogService.AddBlogAsync(Blog, BlogImageMainFile, BlogImageSmallFile, "Blog");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        ViewBag.BlogGroupId = new SelectList(await context.BlogGroups.ToListAsync(), "Id", "BlogGroupName");
        return View(Blog);
    }
    public async Task<IActionResult> Edit(int id)
    {

        var Blog = await context.Blogs.FindAsync(id);


        ViewBag.BlogGroupId = new SelectList(await context.BlogGroups.ToListAsync(), "Id", "BlogGroupName", Blog.BlogGroupId);
        return View(Blog);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Blog Blog, IFormFile? BlogImageMainFile, IFormFile? BlogImageSmallFile)
    {
        if (ModelState.IsValid)
        {
            var res = await BlogService.UpdateBlogAsync(Blog, BlogImageMainFile, BlogImageSmallFile, "Blog");
            if (res)
                return RedirectToAction("Index");
        }
        ViewBag.BlogGroupId = new SelectList(await context.BlogGroups.ToListAsync(), "Id", "BlogGroupName");
        return View(Blog);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Blog = await context.Blogs.FindAsync(id);
        return View(Blog);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Blog = await context.Blogs.FindAsync(id);
            if (Blog != null)
            {
                context.Blogs.Remove(Blog);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Blog);



        }
        return NotFound();

    }
}
