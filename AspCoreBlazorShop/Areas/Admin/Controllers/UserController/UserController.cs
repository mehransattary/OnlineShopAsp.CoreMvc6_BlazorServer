using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.User;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class UserController : Controller
{
    private readonly AppDbContext context;
    public UserController(AppDbContext context)
    {
        this.context = context;
    }


    public async Task<IActionResult> Index()
    {
        return View(await context.Users.Include(x=>x.Role).ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Roles = new SelectList(await context.Roles.ToListAsync(), "Id", "RoleTitle");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Data.Models.User User)
    {
        if (ModelState.IsValid)
        {
            try
            {
                User.CreateDate = DateTime.Now;
                User.UpdateDate = DateTime.Now;
                await context.Users.AddAsync(User);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        ViewBag.Roles = new SelectList(await context.Roles.ToListAsync(), "Id", "RoleTitle");
        return View(User);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var User = await context.Users.FindAsync(id);
        ViewBag.Roles = new SelectList(await context.Roles.ToListAsync(), "Id", "RoleTitle");

        return View(User);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Data.Models.User User)
    {
        if (ModelState.IsValid)
        {
            User.UpdateDate = DateTime.Now;
            context.Users.Update(User);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(User);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var User = await context.Users.FindAsync(id);
        return View(User);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var User = await context.Users.FindAsync(id);
            if (User != null)
            {
                context.Users.Remove(User);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(User);



        }
        return NotFound();

    }

}
