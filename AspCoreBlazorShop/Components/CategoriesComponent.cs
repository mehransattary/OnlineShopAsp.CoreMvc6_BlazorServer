using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreBlazorShop.Components;

public class CategoriesComponent : ViewComponent
{
    private readonly AppDbContext context;
    public CategoriesComponent(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var categories =await context.Categories.Where(x=>x.CategoryIsEnableForMainPage==true).Skip(0).Take(6).Select(x=>
        new Category() 
        {
            CategoryImage= x.CategoryImage, 
            CategoryIsEnableForMainPage=x.CategoryIsEnableForMainPage,
            CategoryName=x.CategoryName,
            CategoryEnglishName=x.CategoryEnglishName
        }).ToListAsync();

        return View("/Views/Components/CategoriesComponent.cshtml", categories);
    }
}
