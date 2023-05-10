using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreBlazorShop.Areas.Admin.Controllers.SettingControllers;

[Area("Admin")]
[Authorize(Roles ="Admin")]

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
