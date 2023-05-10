using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.Facotors;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class FactorsController : Controller
{
    private readonly AppDbContext context;
    public FactorsController(AppDbContext context)
    {
        this.context = context;
    }
    public IActionResult Index(int currentpage = 1)
    {
        var factors = context.FactorMain.Where(x=>x.FactorMainIsPay).Select(x=>new FactorMain()
        {
            FactorMainNumber=x.FactorMainNumber,
            FactorMainPayNumber=x.FactorMainPayNumber,
            FactorMainIsPay=x.FactorMainIsPay,
            FactorMainBuyerMobile=x.FactorMainBuyerMobile,
            FactorMainDate=x.FactorMainDate,
            Id=x.Id
            
        }).ToPagedList(currentpage,10);
        return View(factors);
    }

    public IActionResult Details(int id)
    {
        var factorDetail = context.FactorDetails.Where(x => x.FactorMainId == id).ToList();
        ViewBag.FactorNumber = context.FactorMain.FirstOrDefault(x=>x.Id==id).FactorMainNumber;
        return View(factorDetail);

    }
    public IActionResult Print(int id)
    {
        var factor = context.FactorMain.FirstOrDefault(x => x.Id == id);
        ViewBag.Factor = factor;
        var factorDetail = context.FactorDetails.Where(x => x.Id == id).ToList();
        return View(factorDetail);

    }
}
