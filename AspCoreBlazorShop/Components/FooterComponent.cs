using Data.Context;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreBlazorShop.Components;

public class FooterComponent:ViewComponent
{
	private readonly AppDbContext context;
	public FooterComponent(AppDbContext context)
	{
		this.context = context;

    }
	public async Task<IViewComponentResult>InvokeAsync()
	{
		var categories =await context.Categories.Select(x=>new Category()
		{
		  CategoryName=x.CategoryName,
		  CategoryEnglishName=x.CategoryEnglishName,
		  CategoryOrder=x.CategoryOrder
		}).OrderBy(x=>x.CategoryOrder).Skip(0).Take(6).ToListAsync();

		var setting = context.Settings.FirstOrDefault();
		ViewBag.setting = setting;

		var socials =await context.Socials.ToListAsync();
        ViewBag.socials = socials;
        return View("/Views/Components/FooterComponent.cshtml", categories);

    }
}
