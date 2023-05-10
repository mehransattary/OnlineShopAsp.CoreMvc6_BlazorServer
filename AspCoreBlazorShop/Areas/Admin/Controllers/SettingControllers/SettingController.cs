using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.SettingControllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class SettingController : Controller
{
    private readonly ISettingService SettingService;
    private readonly AppDbContext context;

    public SettingController(ISettingService SettingService, AppDbContext context)
    {
        this.SettingService = SettingService;
        this.context = context; 
    }


    public async Task<IActionResult> Index()
    {
        return View(await context.Settings.FirstOrDefaultAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Setting Setting,IFormFile? SettingLogoFile)
    {
        if (ModelState.IsValid)
        {
            try
            {
               var res= await SettingService.AddSettingAsync(Setting, SettingLogoFile,"setting");

                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(Setting);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Setting = await context.Settings.FindAsync(id);
        return View(Setting);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Setting Setting, IFormFile? SettingLogoFile)
    {
        if (ModelState.IsValid)
        {
           var res= await SettingService.UpdateSettingAsync(Setting, SettingLogoFile, "setting");
            if (res)
                return RedirectToAction("Index");
          
        }
        return View(Setting);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Setting = await context.Settings.FindAsync(id);
        return View(Setting);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Setting = await context.Settings.FindAsync(id);
            if (Setting != null)
            {
                context.Settings.Remove(Setting);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Setting);



        }
        return NotFound();

    }
}
