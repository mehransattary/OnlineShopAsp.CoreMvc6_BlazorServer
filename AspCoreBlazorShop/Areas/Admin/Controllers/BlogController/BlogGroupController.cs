using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BlogGroupController : Controller
{
    private readonly AppDbContext context;
    private readonly IBlogGroupService BlogGroupService;
    public BlogGroupController(IBlogGroupService BlogGroupService, AppDbContext context)
    {
        this.BlogGroupService = BlogGroupService;
        this.context = context;

    }

    public async Task<IActionResult> Index()
    {
        return View(await context.BlogGroups.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.BlogCategoryId = new SelectList(await context.BlogCategories.ToListAsync(), "Id", "BlogCategoryName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(BlogGroup BlogGroup, IFormFile? BlogGroupImageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await BlogGroupService.AddBlogGroupAsync(BlogGroup, BlogGroupImageFile, "BlogGroup");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        ViewBag.BlogCategoryId = new SelectList(await context.BlogCategories.ToListAsync(), "Id", "BlogCategoryName");
        return View(BlogGroup);
    }
    public async Task<IActionResult> Edit(int id)
    {

        var BlogGroup = await context.BlogGroups.FindAsync(id);


        ViewBag.BlogCategoryId = new SelectList(await context.BlogCategories.ToListAsync(), "Id", "BlogCategoryName", BlogGroup.BlogCategoryId);
        return View(BlogGroup);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(BlogGroup BlogGroup, IFormFile? BlogGroupImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await BlogGroupService.UpdateBlogGroupAsync(BlogGroup, BlogGroupImageFile, "BlogGroup");
            if (res)
                return RedirectToAction("Index");
        }
        ViewBag.BlogCategoryId = new SelectList(await context.BlogCategories.ToListAsync(), "Id", "BlogCategoryName");
        return View(BlogGroup);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var BlogGroup = await context.BlogGroups.FindAsync(id);
        return View(BlogGroup);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var BlogGroup = await context.BlogGroups.FindAsync(id);
            if (BlogGroup != null)
            {
                context.BlogGroups.Remove(BlogGroup);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(BlogGroup);



        }
        return NotFound();

    }
}
