using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class BrandController : Controller
{
    private readonly AppDbContext context;
    private readonly IBrandService BrandService;
    public BrandController(IBrandService BrandService, AppDbContext context)
    {
        this.BrandService = BrandService;
        this.context = context;

    }

    public async Task<IActionResult> Index()
    {
        return View(await context.Brands.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Brand Brand, IFormFile? BrandImageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await BrandService.AddBrandAsync(Brand, BrandImageFile, "Brand");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(Brand);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Brand = await context.Brands.FindAsync(id);
        return View(Brand);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Brand Brand, IFormFile? BrandImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await BrandService.UpdateBrandAsync(Brand, BrandImageFile, "Brand");
            if (res)
                return RedirectToAction("Index");
        }
        return View(Brand);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Brand = await context.Brands.FindAsync(id);
        return View(Brand);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Brand = await context.Brands.FindAsync(id);
            if (Brand != null)
            {
                context.Brands.Remove(Brand);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Brand);



        }
        return NotFound();

    }
}
