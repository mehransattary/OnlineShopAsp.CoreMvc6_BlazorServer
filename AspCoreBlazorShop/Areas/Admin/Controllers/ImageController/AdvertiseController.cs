using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.ImageController;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AdvertiseController : Controller
{
    private readonly AppDbContext context;
    private readonly IAdvertiseService AdvertiseService;
    public AdvertiseController(AppDbContext context, IAdvertiseService AdvertiseService)
    {
        this.context = context;
        this.AdvertiseService = AdvertiseService;

    }


    public async Task<IActionResult> Index()
    {
        return View(await context.Advertises.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Advertise Advertise, IFormFile AdvertiseImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await AdvertiseService.AddAdvertiseAsync(Advertise, AdvertiseImageFile, "Advertise");
            if (res)
                return RedirectToAction("Index");
        }
        return View(Advertise);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Advertise = await context.Advertises.FindAsync(id);

        return View(Advertise);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Advertise Advertise, IFormFile? AdvertiseImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await AdvertiseService.UpdateAdvertiseAsync(Advertise, AdvertiseImageFile, "Advertise");
            if (res)
                return RedirectToAction("Index");
        }
        return View(Advertise);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Advertise = await context.Advertises.FindAsync(id);
        return View(Advertise);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Advertise = await context.Advertises.FindAsync(id);
            if (Advertise != null)
            {
                context.Advertises.Remove(Advertise);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Advertise);



        }
        return NotFound();

    }

}
