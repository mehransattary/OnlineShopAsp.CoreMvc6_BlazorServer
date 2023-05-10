using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.User;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class RoleController : Controller
{
    private readonly AppDbContext context;
    public RoleController(AppDbContext context)
    {
        this.context = context;
    }


    public async Task<IActionResult> Index()
    {
        return View(await context.Roles.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Role Role)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await context.Roles.AddAsync(Role);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(Role);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Role = await context.Roles.FindAsync(id);
        return View(Role);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Role Role)
    {
        if (ModelState.IsValid)
        {
            context.Roles.Update(Role);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(Role);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Role = await context.Roles.FindAsync(id);
        return View(Role);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Role = await context.Roles.FindAsync(id);
            if (Role != null)
            {
                context.Roles.Remove(Role);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Role);



        }
        return NotFound();

    }

}
