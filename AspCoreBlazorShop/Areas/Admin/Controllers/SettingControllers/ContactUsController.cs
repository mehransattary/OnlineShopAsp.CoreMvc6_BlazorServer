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
public class ContactUsController : Controller
{

    private readonly AppDbContext context;
    public ContactUsController(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IActionResult> Index()
    {
        return View(await context.ContactUs.FirstOrDefaultAsync());
    }


    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(ContactUs ContactUs)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await context.ContactUs.AddAsync(ContactUs);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(ContactUs);
    }


    public async Task<IActionResult> Edit(int id)
    {
        var ContactUs = await context.ContactUs.FindAsync(id);
        return View(ContactUs);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(ContactUs ContactUs)
    {
        if (ModelState.IsValid)
        {
            try
            {
                context.ContactUs.Update(ContactUs);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(ContactUs);
    }



    public async Task<IActionResult> Delete(int id)
    {
        var ContactUs = await context.ContactUs.FindAsync(id);
        return View(ContactUs);
    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var ContactUs = await context.ContactUs.FindAsync(id);
            if (ContactUs != null)
            {
                context.ContactUs.Remove(ContactUs);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ContactUs);
        }
        return NotFound();
    }
}
