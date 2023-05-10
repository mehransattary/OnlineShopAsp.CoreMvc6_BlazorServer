using Data.Context;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreBlazorShop.Controllers;

public class PanelUserController : Controller
{
    private readonly AppDbContext context;
    public PanelUserController(AppDbContext context)
    {
        this.context = context;
    }
    public IActionResult ShowInformation()
    {
        var user = context.Users.FirstOrDefault(x=>x.Mobile==User.Identity.Name);
        return View(user);
    }
    public IActionResult ShowFactors()
    {
        var factors = context.FactorMain.Where(x => x.FactorMainBuyerMobile == User.Identity.Name&& x.FactorMainIsPay).OrderByDescending(x=>x.FactorMainDate);
        return View(factors);
    }
    public IActionResult ShowDetailFactor(int factorId)
    {
        ViewBag.FactorNumber = context.FactorMain.FirstOrDefault(x=>x.Id== factorId).FactorMainNumber;
        var factorDetails = context.FactorDetails.Where(x=>x.FactorMainId==factorId).ToList();
        return View(factorDetails);
    }
}
