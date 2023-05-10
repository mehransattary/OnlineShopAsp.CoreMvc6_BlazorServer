using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System.Data;
using System.Drawing;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.ImageController;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class SliderController : Controller
{
    private readonly AppDbContext context;
    private readonly ISliderService sliderService;
    public SliderController(AppDbContext context, ISliderService sliderService)
    {
        this.context = context;
        this.sliderService = sliderService;

    }


    public async Task<IActionResult> Index()
    {
        return View(await context.Sliders.ToListAsync());
    }

    public async Task<IActionResult> Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Slider Slider, IFormFile SliderImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await sliderService.AddSliderAsync(Slider, SliderImageFile, "slider");
            if (res)
                return RedirectToAction("Index");
        }
        return View(Slider);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Slider = await context.Sliders.FindAsync(id);

        return View(Slider);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Slider Slider, IFormFile? SliderImageFile)
    {
        if (ModelState.IsValid)
        {
            var res = await sliderService.UpdateSliderAsync(Slider, SliderImageFile, "slider");
            if (res)
                return RedirectToAction("Index");
        }
        return View(Slider);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Slider = await context.Sliders.FindAsync(id);
        return View(Slider);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Slider = await context.Sliders.FindAsync(id);
            if (Slider != null)
            {
                context.Sliders.Remove(Slider);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Slider);



        }
        return NotFound();

    }

}
