using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using Repository.Services;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class CategoryController : Controller
{

    private readonly AppDbContext context;
    private readonly ICategoryService categoryService;
    public CategoryController(ICategoryService categoryService, AppDbContext context)
    {
        this.categoryService = categoryService;
        this.context = context;

    }

    public async Task<IActionResult> Index()
    {
        return View(await context.Categories.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category Category, IFormFile? CategoryImageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await categoryService.AddCategoryAsync(Category, CategoryImageFile, "category");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(Category);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Category = await context.Categories.FindAsync(id);
        return View(Category);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Category Category, IFormFile? CategoryImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await categoryService.UpdateCategoryAsync(Category, CategoryImageFile, "category");
            if (res)
                return RedirectToAction("Index");
        }
        return View(Category);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Category = await context.Categories.FindAsync(id);
        return View(Category);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Category = await context.Categories.FindAsync(id);
            if (Category != null)
            {
                context.Categories.Remove(Category);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Category);



        }
        return NotFound();

    }
}
