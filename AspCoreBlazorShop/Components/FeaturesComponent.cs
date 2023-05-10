using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreBlazorShop.Components;

public class FeaturesComponent : ViewComponent
{
    private readonly AppDbContext context;
    public FeaturesComponent(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var imageAdvertise =await context.Advertises.Skip(0).Take(3).ToListAsync();
        return View("/Views/Components/FeaturesComponent.cshtml", imageAdvertise);
    }
}
