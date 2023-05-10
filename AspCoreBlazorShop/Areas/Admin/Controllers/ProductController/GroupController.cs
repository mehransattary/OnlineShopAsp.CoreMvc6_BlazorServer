using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = "Admin")]
public class GroupController : Controller
{
    private readonly AppDbContext context;
    private readonly IGroupService GroupService;
    public GroupController(IGroupService GroupService, AppDbContext context)
    {
        this.GroupService = GroupService;
        this.context = context;

    }

    public async Task<IActionResult> Index()
    {
        return View(await context.Groups.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "CategoryName");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Group Group, IFormFile? GroupImageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await GroupService.AddGroupAsync(Group, GroupImageFile, "Group");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "CategoryName");
        return View(Group);
    }
    public async Task<IActionResult> Edit(int id)
    {

        var Group = await context.Groups.FindAsync(id);

        ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "CategoryName", Group.CategoryId);

        return View(Group);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Group Group, IFormFile? GroupImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await GroupService.UpdateGroupAsync(Group, GroupImageFile, "Group");
            if (res)
                return RedirectToAction("Index");
        }
        ViewBag.CategoryId = new SelectList(await context.Categories.ToListAsync(), "Id", "CategoryName");
        return View(Group);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Group = await context.Groups.FindAsync(id);
        return View(Group);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Group = await context.Groups.FindAsync(id);
            if (Group != null)
            {
                context.Groups.Remove(Group);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Group);



        }
        return NotFound();

    }
}
