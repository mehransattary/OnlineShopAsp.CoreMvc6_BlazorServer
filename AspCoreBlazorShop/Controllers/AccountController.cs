using Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Repository.Interface;
using System.Security.Claims;

namespace AspCoreBlazorShop.Controllers;

public class AccountController : Controller
{
    private IAccountService accountService;
    public AccountController(IAccountService accountService)
    {
        this.accountService=accountService; 
    }
    public IActionResult Register()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Register(User user)
    {
       var res= accountService.RegisterUser(user);
        if (res == true)
            return RedirectToAction("Login"); 
        return View(user);
    }

    public IActionResult Login(bool isShopcart=false)
    {
        ViewBag.isShopcart = isShopcart.ToString();
        return View();
    }
    [HttpPost]
    public IActionResult Login(User user, string isShopcart = "false")
    {
        var res= accountService.IsExistUser(user);
        var roleName = accountService.GetRoleNameByUser(user);
        if (res==true && !string.IsNullOrEmpty(roleName))
        {
            var claims = new List<Claim>();           
            claims.Add(new Claim(ClaimTypes.MobilePhone, user.Mobile.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Mobile.ToString()));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Mobile.ToString()));
            claims.Add(new Claim(ClaimTypes.Role, roleName));

            var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

            var principal = new ClaimsPrincipal(identity);

            HttpContext.SignInAsync(principal);
            if(isShopcart!= "False")
                return Redirect("/ContinueShopCarts");
            return Redirect("/");

        }
        ViewBag.message = " نام کاربری یا رمز عبور اشتباه می باشد.";
        return View(user);
    }



    public IActionResult LogOut()
    {
        HttpContext.SignOutAsync();
        return RedirectToAction("Login");
    }

    public IActionResult AccessDenied()
    {
        return View();
    }
}
