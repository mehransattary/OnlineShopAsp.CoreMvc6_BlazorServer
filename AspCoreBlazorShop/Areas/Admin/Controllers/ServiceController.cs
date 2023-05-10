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
public class ServiceController : Controller
{
    private readonly AppDbContext context;
    private readonly IServiceService ServiceService;
    public ServiceController(IServiceService ServiceService, AppDbContext context)
    {
        this.ServiceService = ServiceService;
        this.context = context;

    }

    public async Task<IActionResult> Index()
    {
        return View(await context.Services.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Service Service, IFormFile? ServiceImageFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await ServiceService.AddServiceAsync(Service, ServiceImageFile, "Service");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        return View(Service);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Service = await context.Services.FindAsync(id);
        return View(Service);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Service Service, IFormFile? ServiceImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await ServiceService.UpdateServiceAsync(Service, ServiceImageFile, "Service");
            if (res)
                return RedirectToAction("Index");
        }
        return View(Service);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Service = await context.Services.FindAsync(id);
        return View(Service);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Service = await context.Services.FindAsync(id);
            if (Service != null)
            {
                context.Services.Remove(Service);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Service);



        }
        return NotFound();

    }
}
