using Data.Context;
using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Protocol;

namespace AspCoreBlazorShop.Controllers;

public class ShopCartController : Controller
{
    private readonly AppDbContext context;
    public ShopCartController(AppDbContext context)
    {
        this.context = context;
    }
    [HttpPost]
    public IActionResult AddShopCart(ShopCartViewModel shopCartViewModel)
    {
        // ProductId=5 , Count=4 + 2
   
        if (ModelState.IsValid)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == shopCartViewModel.ProductId);
            List<ShopCartViewModel> carts = new List<ShopCartViewModel>();

            

            //Repeat Edit Shop cart
            var myShopcart_json = HttpContext.Request.Cookies["ShopCartCookies"];
            if (myShopcart_json!=null)
            {              
                var myShopcart = JsonConvert.DeserializeObject<List<ShopCartViewModel>>(myShopcart_json);

                var res = myShopcart.FirstOrDefault(x => x.ProductId == shopCartViewModel.ProductId);
                if(res != null)
                {
                    res.Count += shopCartViewModel.Count;
                    HttpContext.Response.Cookies.Delete("ShopCartCookies");

                    HttpContext.Response.Cookies.Append("ShopCartCookies", myShopcart.ToJson());
                }
                else
                {
                    myShopcart.Add(shopCartViewModel);
                    HttpContext.Response.Cookies.Delete("ShopCartCookies");
                    HttpContext.Response.Cookies.Append("ShopCartCookies", myShopcart.ToJson());
                }
                  
              
                return Redirect($"/Product/{product.ProductEnglishName}");

            }
            //New Add ShopCart
            else
            {
                shopCartViewModel.ProductName = product.ProductName;
                shopCartViewModel.ProductEnglishName = product.ProductEnglishName;
                shopCartViewModel.ProductPrice = (product.ProductPriceOffer != 0 ? product.ProductPriceOffer : product.ProductPrice);
                shopCartViewModel.ProductSumPrice = shopCartViewModel.ProductPrice * shopCartViewModel.Count;
                shopCartViewModel.ProductImage = product.ProductImageSmall;

                carts.Add(shopCartViewModel);  
                
                HttpContext.Response.Cookies.Append("ShopCartCookies", carts.ToJson());
                return Redirect($"/Product/{product.ProductEnglishName}");
            }
          
        
        }
        return NotFound();
    }
    [Route("/ShopCarts")]
    public IActionResult ShowShopCart()
    {
        //نمایش سبد خرید
        return View();
    }
    [Route("/ContinueShopCarts")]
    public IActionResult ContinueShopCarts()
    {
        if(User.Identity.IsAuthenticated)
        {
            var myShopcart_json = HttpContext.Request.Cookies["ShopCartCookies"];
            if (myShopcart_json != null)
            {
                var myShopcart = JsonConvert.DeserializeObject<List<ShopCartViewModel>>(myShopcart_json);
                ViewBag.SumAllPriceForPay = myShopcart.Sum(x=>x.ProductSumPrice);
                ViewBag.CoustShopCarts = myShopcart.Count();
            }
            var _user = context.Users.FirstOrDefault(x => x.Mobile == User.Identity.Name);
            return View(_user);
        }
        else        
            return RedirectToAction("Login", "Account", new { isShopcart=true});
        

    }

    [HttpPost("/ContinueShopCarts")]
    public IActionResult ContinueShopCarts(User user)
    {
        if(!string.IsNullOrEmpty(user.Address)&&  !string.IsNullOrEmpty(user.FullName) && !string.IsNullOrEmpty(user.City) )
        {
            var _user = context.Users.FirstOrDefault(x=>x.Mobile== User.Identity.Name);
            _user.Address = user.Address;
            _user.CodePosti = user.CodePosti;
            _user.City = user.City;
            _user.State = user.State;
            _user.FullName = user.FullName;
            context.Users.Update(_user);
            context.SaveChanges();
            return View();
        }

        return View();
    }
}
