using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreBlazorShop.Components;

public class LastProductsComponent : ViewComponent
{
    private readonly AppDbContext context;
    public LastProductsComponent(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var lastProducts =await context.Products.OrderByDescending(x=>x.CreateDate).Select(x=>
            new Product() 
            {
                ProductName=x.ProductName,
                ProductEnglishName=x.ProductEnglishName,
                ProductImageSmall=x.ProductImageSmall,
                ProductPrice=x.ProductPrice,
                ProductPriceOffer=x.ProductPriceOffer
                
            }).Skip(0).Take(4).ToListAsync();
        return View("/Views/Components/LastProductsComponent.cshtml", lastProducts);
    }
}
