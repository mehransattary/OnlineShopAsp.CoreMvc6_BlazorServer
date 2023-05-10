using Data.Context;
using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace AspCoreBlazorShop.Components;

public class ShopCartComponent:ViewComponent
{
    private readonly AppDbContext context;
    public ShopCartComponent(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<IViewComponentResult>InvokeAsync()
    {
        //Read Cookies
        var shopcarts = HttpContext.Request.Cookies["ShopCartCookies"];
        List<ShopCartViewModel> carts = new List<ShopCartViewModel>();

        if (shopcarts != null)
        {
            var shopcartsViewModels = JsonConvert.DeserializeObject<List<ShopCartViewModel>>(shopcarts);

            foreach (var item in shopcartsViewModels)
            {
                var product = await context.Products.FirstOrDefaultAsync(x => x.Id == item.ProductId);

                item.ProductName = product.ProductName;
                item.ProductEnglishName = product.ProductEnglishName;
                item.ProductPrice = (product.ProductPriceOffer != 0 ? product.ProductPriceOffer : product.ProductPrice);
                item.ProductSumPrice = item.ProductPrice * item.Count;
                item.ProductImage = product.ProductImageSmall;
                carts.Add(item);
            }
            ViewBag.SumAllprice = shopcartsViewModels.Sum(x=>x.ProductSumPrice).ToString("#,0 تومان");
            return View("/Views/Components/ShopCartComponent.cshtml", carts);


        }
        return View("/Views/Components/ShopCartComponent.cshtml", carts);

    }
}
