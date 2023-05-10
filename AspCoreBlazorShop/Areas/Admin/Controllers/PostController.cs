using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class PostController : Controller
{
    private readonly AppDbContext context;
    public  PostController(AppDbContext context)
    {
        this.context = context;
    }


    public async Task<IActionResult> Index()
    {
        return View(await context.Posts.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create( Post  Post)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await context.Posts.AddAsync( Post);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View( Post);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var  Post = await context.Posts.FindAsync(id);
        return View( Post);
    }
    [HttpPost]
    public async Task<IActionResult> Edit( Post  Post)
    {
        if (ModelState.IsValid)
        {
            context. Posts.Update( Post);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View( Post);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var  Post = await context.Posts.FindAsync(id);
        return View( Post);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var  Post = await context.Posts.FindAsync(id);
            if ( Post != null)
            {
                context. Posts.Remove( Post);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View( Post);



        }
        return NotFound();

    }
}
