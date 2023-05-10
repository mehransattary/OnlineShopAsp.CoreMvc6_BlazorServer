using Microsoft.AspNetCore.Mvc;

namespace AspCoreBlazorShop.Components;

public class MenuComponent:ViewComponent
{
	public MenuComponent()
	{

	}
	public async Task<IViewComponentResult> InvokeAsync()
	{
		return View("/Views/Components/MenuComponent.cshtml");
	}
}
