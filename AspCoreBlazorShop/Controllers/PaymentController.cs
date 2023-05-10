using Data.Context;
using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repository.Interface;
using System.Reflection;

namespace AspCoreBlazorShop.Controllers;

public class PaymentController : Controller
{
    private readonly AppDbContext context;
    private readonly IZarinPalService ZarinPalService;

    public PaymentController(AppDbContext context, IZarinPalService ZarinPalService)
    {
        this.context = context;
        this.ZarinPalService = ZarinPalService;
    }
    [Route("/ConnectToPayment/{sumPriceAll}")]
    public IActionResult ConnectToPayment(string sumPriceAll)
    {
        if(User.Identity.IsAuthenticated)
        {
            var user = context.Users.FirstOrDefault(x=>x.Mobile==User.Identity.Name);
            //====>>>>>Add FactorMain
            var factor = new FactorMain()
            {
                FactorMainIsPay = false,
                FactorMainSellerFullName = "فروشگاه",
                FactorMainSellerPhoneNumber = "09369944780",
                FactorMainSellerAddress = "تبریز آبرسان",
                FactorMainBuyerCodePosti = user.CodePosti,
                FactorMainBuyerAddress = user.Address,
                FactorMainBuyerFullName = user.FullName,
                FactorMainBuyerMobile = user.Mobile,
                CreateDate = DateTime.Now,
                UpdateDate=DateTime.Now,
                FactorMainDate=DateTime.Now,
                FactorMainSumPriceAll= Convert.ToDouble(sumPriceAll),
                FactorMainNumber="0",
                FactorMainPayNumber="0",                

            };
            context.Add(factor);
            context.SaveChanges();

            //====>>>>>Add FactorDetails
            //Read Cookies
            var shopcarts = HttpContext.Request.Cookies["ShopCartCookies"];
            List<ShopCartViewModel> carts = new List<ShopCartViewModel>();
            if (shopcarts != null)
            {
                var shopcartsViewModels = JsonConvert.DeserializeObject<List<ShopCartViewModel>>(shopcarts);
                foreach (var item in shopcartsViewModels)
                {               

                    var factorDatail = new FactorDetails()
                    {
                        FactorDetailsNameProduct = item.ProductName,
                        FactorDetailsCountProduct = item.Count,
                        FactorDetailsPriceProduct = item.ProductPrice,
                        FactorMainId = factor.Id,
                        UpdateDate = DateTime.Now,
                        CreateDate = DateTime.Now,
                        FactorDetailsSumPriceProduct = item.ProductSumPrice
                    };
                    context.Add(factorDatail);
                    context.SaveChanges();
                }
                         
               
            }

           
            return RedirectToAction("ConnectToZarinpal",new { mobile= user.Mobile, amount= sumPriceAll, factorId= factor.Id});
        }
     
        return View();
    }
    public IActionResult ConnectToZarinpal(string mobile,string amount,int factorId)
    {

        string callback = "https://localhost:7022/BackIsPayment/"+ @factorId;
       var linktoZarinPal=  ZarinPalService.PaymentZarinPal(mobile, amount, callback);
        if (!string.IsNullOrEmpty(linktoZarinPal))
            return Redirect(linktoZarinPal);
        else
            return Redirect("/ShopCarts");

    }

    [Route("/BackIsPayment/{factorId}")]
    public IActionResult BackIsPayment(int factorId)
    {
        var factor = context.FactorMain.FirstOrDefault(x => x.Id == factorId);
        var authority = Request.Query["Authority"].ToString();
        var status = Request.Query["Status"].ToString();

        var resultRefId= ZarinPalService.VerifyPay(factor.FactorMainSumPriceAll.ToString(), authority);
        if(status.ToLower()=="ok" && !string.IsNullOrEmpty(resultRefId))
        {
            int factorNumber = 100;
            factor.UpdateDate = DateTime.Now;
            factor.FactorMainIsPay = true;
            if(context.FactorMain.Any(x=>x.FactorMainNumber!="0"))
            {
                var lastFactorIsPay = context.FactorMain.Where(x=> x.FactorMainNumber != "0").OrderByDescending(x=>x.Id).FirstOrDefault();
                factor.FactorMainNumber = ((Convert.ToInt32(lastFactorIsPay.FactorMainNumber))+1).ToString();
            }
            else
            {
                factor.FactorMainNumber = factorNumber.ToString();
            }
            factor.FactorMainPayNumber= resultRefId;
            context.SaveChanges();
            HttpContext.Response.Cookies.Delete("ShopCartCookies");
            ViewBag.Message = "پرداخت با موفقیت انجام شد";
            ViewBag.RefId = resultRefId;
            return View();
        }
        ViewBag.Message = "خطا در پرداخت";
        ViewBag.RefId = 0;
        return View();
    }
}
