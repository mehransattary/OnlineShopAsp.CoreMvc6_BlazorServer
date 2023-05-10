using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.SettingControllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class AbouteUsController : Controller
{

    private readonly AppDbContext context;
    public AbouteUsController(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await context.AbouteUs.FirstOrDefaultAsync());
    }


    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(AbouteUs abouteUs)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await context.AbouteUs.AddAsync(abouteUs);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(abouteUs);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var abouteus = await context.AbouteUs.FindAsync(id);
        return View(abouteus);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(AbouteUs abouteUs)
    {
        if (ModelState.IsValid)
        {
            try
            {
                context.AbouteUs.Update(abouteUs);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(abouteUs);
    }



    public async Task<IActionResult> Delete(int id)
    {
        var abouteus = await context.AbouteUs.FindAsync(id);
        return View(abouteus);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var abouteus = await context.AbouteUs.FindAsync(id);
            if (abouteus != null)
            {
                context.AbouteUs.Remove(abouteus);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(abouteus);
        }
        return NotFound();
    }
}
