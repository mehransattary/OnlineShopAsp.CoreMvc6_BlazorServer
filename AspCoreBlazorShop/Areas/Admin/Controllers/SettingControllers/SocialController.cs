using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.SettingControllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class SocialController : Controller
{
    private readonly AppDbContext context;
    public SocialController(AppDbContext context)
    {
        this.context = context;
    }


    public async Task<IActionResult> Index()
    {
        return View(await context.Socials.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Social social)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await context.Socials.AddAsync(social);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(social);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var social = await context.Socials.FindAsync(id);
        return View(social);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Social social)
    {
        if (ModelState.IsValid)
        {
            context.Socials.Update(social);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(social);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var social = await context.Socials.FindAsync(id);
        return View(social);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var social = await context.Socials.FindAsync(id);
            if (social != null)
            {
                context.Socials.Remove(social);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(social);



        }
        return NotFound();

    }

}
