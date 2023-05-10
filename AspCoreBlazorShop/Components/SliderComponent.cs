using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreBlazorShop.Components;

public class SliderComponent : ViewComponent
{
    private readonly AppDbContext context;
    public SliderComponent(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var sliders =await context.Sliders.ToListAsync();
        return View("/Views/Components/SliderComponent.cshtml", sliders);
    }
}
