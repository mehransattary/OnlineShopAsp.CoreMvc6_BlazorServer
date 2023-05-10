using Data.Context;
using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;

namespace AspCoreBlazorShop.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = "Admin")]
public class ProductController : Controller
{
    private readonly AppDbContext context;
    private readonly IProductService ProductService;
    public ProductController(IProductService ProductService, AppDbContext context)
    {
        this.ProductService = ProductService;
        this.context = context;

    }

    public async Task<IActionResult> Index()
    {
        var result = await context.Products.Include(x => x.Brand).Include(x => x.Group).Select(x =>
        new ProductAdminIndexViewModel()
        {
            ProductName = x.ProductName,
            ProductImageSmall = x.ProductImageSmall,
            ProductId = x.Id,
            ProductOrder = x.ProductOrder,
            BrandName = x.Brand.BrandName,
            GroupName = x.Group.GroupName,
            ProductPrice=x.ProductPrice,
            ProductPriceOffer=x.ProductPriceOffer


        }).ToListAsync();

        //var result = await context.Products.Include(x => x.Brand).Include(x => x.Group).ToListAsync();
        return View(result);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.GroupId = new SelectList(await context.Groups.ToListAsync(), "Id", "GroupName");
        ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "BrandName");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product Product, IFormFile? ProductImageMainFile, IFormFile? ProductImageSmallFile)
    {
        if (ModelState.IsValid)
        {
            try
            {

                var res = await ProductService.AddProductAsync(Product, ProductImageMainFile, ProductImageSmallFile, "Product");
                if (res)
                    return RedirectToAction("Index");

            }
            catch (Exception)
            {

                throw;
            }
        }
        ViewBag.GroupId = new SelectList(await context.Groups.ToListAsync(), "Id", "GroupName");
        ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "BrandName");
        return View(Product);
    }
    public async Task<IActionResult> Edit(int id)
    {
        var Product = await context.Products.FindAsync(id);
        ViewBag.GroupId = new SelectList(await context.Groups.ToListAsync(), "Id", "GroupName", Product.GroupId);
        ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "BrandName", Product.BrandId);

        return View(Product);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Product Product, IFormFile? ProductImageMainFile, IFormFile? ProductImageSmallFile)
    {
        if (ModelState.IsValid)
        {
            var res = await ProductService.UpdateProductAsync(Product, ProductImageMainFile, ProductImageSmallFile, "Product");
            if (res)
                return RedirectToAction("Index");
        }
        ViewBag.GroupId = new SelectList(await context.Groups.ToListAsync(), "Id", "GroupName");
        ViewBag.BrandId = new SelectList(await context.Brands.ToListAsync(), "Id", "BrandName");
        return View(Product);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var Product = await context.Products.FindAsync(id);
        return View(Product);

    }
    [HttpPost]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        if (id != 0)
        {
            var Product = await context.Products.FindAsync(id);
            if (Product != null)
            {
                context.Products.Remove(Product);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
                return View(Product);



        }
        return NotFound();

    }
}
