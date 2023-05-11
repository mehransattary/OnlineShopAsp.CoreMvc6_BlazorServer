using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreBlazorShop.Components;

public class LastBlogsComponent : ViewComponent
{
    private readonly AppDbContext context;
    public LastBlogsComponent(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var lastBlogs =await context.Blogs.OrderByDescending(x=>x.CreateDate).Select(x=>
            new Blog() 
            {
                BlogName=x.BlogName,
                UpdateDate=x.UpdateDate,
                Id=x.Id,
                BlogImageSmall=x.BlogImageSmall
                
            }).Skip(0).Take(4).ToListAsync();
        return View("/Views/Components/LastBlogsComponent.cshtml", lastBlogs);
    }
}
