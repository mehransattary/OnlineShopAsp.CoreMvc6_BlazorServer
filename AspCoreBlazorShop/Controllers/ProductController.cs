using Data.Context;
using Data.Models;
using Data.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace AspCoreBlazorShop.Controllers;

public class ProductController : Controller
{
    private readonly AppDbContext context;
    public ProductController(AppDbContext context)
    {
        this.context = context;
    }
    [Route("/Product/{englishNameProduct}")]
    public IActionResult ShowProduct(string englishNameProduct)
    {
        var product = context.Products.FirstOrDefault(x=>x.ProductEnglishName== englishNameProduct);

        var relatedproducts = context.Products.Where(x => x.GroupId == product.GroupId).ToList();
        ViewData["relatedproducts"] = relatedproducts;
        return View(product);
    }

    [Route("/ShowProducts")]
    [Route("/ShowProductsGroup/{groupEnglishName}")]
    [Route("/ShowProductsCategory/{categoryEnglishName}")]
    [Route("/ShowProductsBrand/{brandEnglishName}")]
    public IActionResult ShowProducts(StatusSearchProductEnum? statusSearch,string? groupEnglishName,string? categoryEnglishName ,string? brandEnglishName,int currentpage = 1 )
    {

        //----------Categories-----------------//
        ViewData["Categories"] = context.Categories.Select(x => new Category()
        {
            CategoryName = x.CategoryName,
            CategoryEnglishName = x.CategoryEnglishName
        }).ToList();

        //----------Last Products-----------------//
        var lastProducts = context.Products.Select(x => new Product()
        {
            Id = x.Id,
            ProductEnglishName = x.ProductEnglishName,
            ProductName = x.ProductName,
            ProductImageSmall = x.ProductImageSmall,
            ProductPriceOffer = x.ProductPriceOffer,
            ProductPrice = x.ProductPrice,
            UpdateDate = x.UpdateDate
        }).OrderByDescending(x => x.UpdateDate).Skip(0).Take(6).ToList();
        ViewData["lastProducts"] = lastProducts;
        int pageSize = 12;

        if (statusSearch!=null)
        {
            switch (statusSearch)
            {
                case StatusSearchProductEnum.News:
                    //----------Group-----------------//
                    if (!string.IsNullOrEmpty(groupEnglishName))
                    {
                        var group = context.Groups.FirstOrDefault(x => x.GroupEnglishName == groupEnglishName);
                        ViewBag.GroupName = group.GroupName;

                        var products1 = context.Products.Where(x => x.GroupId == group.Id).Select(x => new Product()
                        {
                            Id = x.Id,
                            ProductEnglishName = x.ProductEnglishName,
                            ProductName = x.ProductName,
                            ProductImageSmall = x.ProductImageSmall,
                            ProductPriceOffer = x.ProductPriceOffer,
                            ProductPrice = x.ProductPrice,
                            UpdateDate = x.UpdateDate
                        }).OrderByDescending(x => x.UpdateDate).ToList();
                        return View(products1.ToPagedList(currentpage, pageSize));

                    }
                    //----------Category-----------------//
                    if (!string.IsNullOrEmpty(categoryEnglishName))
                    {
                        var productsByCategory = new List<Product>();


                        var _category = context.Categories.Where(x => x.CategoryEnglishName == categoryEnglishName);
                        ViewBag.CategoryName = context.Categories.FirstOrDefault(x => x.CategoryEnglishName == categoryEnglishName).CategoryName;
                        var res = from cat in _category
                                  join
                                  grou in context.Groups
                                  on
                                  cat.Id equals grou.CategoryId
                                  join
                                  product in context.Products
                                  on
                                  grou.Id equals product.GroupId
                                  select new ProductByCategoryVm
                                  {
                                      Id = product.Id,
                                      ProductEnglishName = product.ProductEnglishName,
                                      ProductName = product.ProductName,
                                      ProductImageSmall = product.ProductImageSmall,
                                      ProductPriceOffer = product.ProductPriceOffer,
                                      ProductPrice = product.ProductPrice,
                                      UpdateDate = product.UpdateDate
                                  };

                        foreach (var product in res)
                        {
                            var _product = new Product()
                            {
                                Id = product.Id,
                                ProductEnglishName = product.ProductEnglishName,
                                ProductName = product.ProductName,
                                ProductImageSmall = product.ProductImageSmall,
                                ProductPriceOffer = product.ProductPriceOffer,
                                ProductPrice = product.ProductPrice,
                                UpdateDate = product.UpdateDate
                            };
                            productsByCategory.Add(_product);
                        }
                        return View(productsByCategory.OrderByDescending(x => x.UpdateDate).ToPagedList(currentpage, pageSize));


                    }
                    //----------Brand-----------------//
                    if (!string.IsNullOrEmpty(brandEnglishName))
                    {
                        var brand = context.Brands.Include(x => x.Products).FirstOrDefault(x => x.BrandEnglishName == brandEnglishName);
                        ViewBag.BrandName = brand.BrandName;



                        var products3 = context.Products.Where(x => x.BrandId == brand.Id).Select(x => new Product()
                        {
                            Id = x.Id,
                            ProductEnglishName = x.ProductEnglishName,
                            ProductName = x.ProductName,
                            ProductImageSmall = x.ProductImageSmall,
                            ProductPriceOffer = x.ProductPriceOffer,
                            ProductPrice = x.ProductPrice
                        }).OrderByDescending(x => x.UpdateDate).ToPagedList(currentpage, pageSize);
                        return View(products3);

                    }
                    //----------AllProducts-----------------//
                    var products5 = context.Products.Select(x => new Product()
                    {
                        Id = x.Id,
                        ProductEnglishName = x.ProductEnglishName,
                        ProductName = x.ProductName,
                        ProductImageSmall = x.ProductImageSmall,
                        ProductPriceOffer = x.ProductPriceOffer,
                        ProductPrice = x.ProductPrice,
                        UpdateDate = x.UpdateDate
                    }).OrderByDescending(x => x.UpdateDate).ToPagedList(currentpage, pageSize);

                    return View(products5);
                    break;
                case StatusSearchProductEnum.Expensive:
                    //----------Group-----------------//
                    if (!string.IsNullOrEmpty(groupEnglishName))
                    {
                        var group = context.Groups.FirstOrDefault(x => x.GroupEnglishName == groupEnglishName);
                        ViewBag.GroupName = group.GroupName;

                        var products1 = context.Products.Where(x => x.GroupId == group.Id).Select(x => new Product()
                        {
                            Id = x.Id,
                            ProductEnglishName = x.ProductEnglishName,
                            ProductName = x.ProductName,
                            ProductImageSmall = x.ProductImageSmall,
                            ProductPriceOffer = x.ProductPriceOffer,
                            ProductPrice = x.ProductPrice,
                            UpdateDate = x.UpdateDate
                        }).OrderByDescending(x => x.ProductPrice).ToList();
                        return View(products1.ToPagedList(currentpage, pageSize));

                    }
                    //----------Category-----------------//
                    if (!string.IsNullOrEmpty(categoryEnglishName))
                    {
                        var productsByCategory = new List<Product>();


                        var _category = context.Categories.Where(x => x.CategoryEnglishName == categoryEnglishName);
                        ViewBag.CategoryName = context.Categories.FirstOrDefault(x => x.CategoryEnglishName == categoryEnglishName).CategoryName;
                        var res = from cat in _category
                                  join
                                  grou in context.Groups
                                  on
                                  cat.Id equals grou.CategoryId
                                  join
                                  product in context.Products
                                  on
                                  grou.Id equals product.GroupId
                                  select new ProductByCategoryVm
                                  {
                                      Id = product.Id,
                                      ProductEnglishName = product.ProductEnglishName,
                                      ProductName = product.ProductName,
                                      ProductImageSmall = product.ProductImageSmall,
                                      ProductPriceOffer = product.ProductPriceOffer,
                                      ProductPrice = product.ProductPrice,
                                      UpdateDate = product.UpdateDate
                                  };

                        foreach (var product in res)
                        {
                            var _product = new Product()
                            {
                                Id = product.Id,
                                ProductEnglishName = product.ProductEnglishName,
                                ProductName = product.ProductName,
                                ProductImageSmall = product.ProductImageSmall,
                                ProductPriceOffer = product.ProductPriceOffer,
                                ProductPrice = product.ProductPrice,
                                UpdateDate = product.UpdateDate
                            };
                            productsByCategory.Add(_product);
                        }
                        return View(productsByCategory.OrderByDescending(x => x.ProductPrice).ToPagedList(currentpage, pageSize));


                    }
                    //----------Brand-----------------//
                    if (!string.IsNullOrEmpty(brandEnglishName))
                    {
                        var brand = context.Brands.Include(x => x.Products).FirstOrDefault(x => x.BrandEnglishName == brandEnglishName);
                        ViewBag.BrandName = brand.BrandName;



                        var products3 = context.Products.Where(x => x.BrandId == brand.Id).Select(x => new Product()
                        {
                            Id = x.Id,
                            ProductEnglishName = x.ProductEnglishName,
                            ProductName = x.ProductName,
                            ProductImageSmall = x.ProductImageSmall,
                            ProductPriceOffer = x.ProductPriceOffer,
                            ProductPrice = x.ProductPrice
                        }).OrderByDescending(x => x.ProductPrice).ToPagedList(currentpage, pageSize);
                        return View(products3);

                    }
                    //----------AllProducts-----------------//
                    var products2 = context.Products.Select(x => new Product()
                    {
                        Id = x.Id,
                        ProductEnglishName = x.ProductEnglishName,
                        ProductName = x.ProductName,
                        ProductImageSmall = x.ProductImageSmall,
                        ProductPriceOffer = x.ProductPriceOffer,
                        ProductPrice = x.ProductPrice,
                        UpdateDate = x.UpdateDate
                    }).OrderByDescending(x => x.ProductPrice).ToPagedList(currentpage, pageSize);

                    return View(products2);
                    break;

                case StatusSearchProductEnum.cheap:
                    //----------Group-----------------//
                    if (!string.IsNullOrEmpty(groupEnglishName))
                    {
                        var group = context.Groups.FirstOrDefault(x => x.GroupEnglishName == groupEnglishName);
                        ViewBag.GroupName = group.GroupName;

                        var products1 = context.Products.Where(x => x.GroupId == group.Id).Select(x => new Product()
                        {
                            Id = x.Id,
                            ProductEnglishName = x.ProductEnglishName,
                            ProductName = x.ProductName,
                            ProductImageSmall = x.ProductImageSmall,
                            ProductPriceOffer = x.ProductPriceOffer,
                            ProductPrice = x.ProductPrice,
                            UpdateDate = x.UpdateDate
                        }).OrderBy(x => x.ProductPrice).ToList();
                        return View(products1.ToPagedList(currentpage, pageSize));

                    }
                    //----------Category-----------------//
                    if (!string.IsNullOrEmpty(categoryEnglishName))
                    {
                        var productsByCategory = new List<Product>();


                        var _category = context.Categories.Where(x => x.CategoryEnglishName == categoryEnglishName);
                        ViewBag.CategoryName = context.Categories.FirstOrDefault(x => x.CategoryEnglishName == categoryEnglishName).CategoryName;
                        var res = from cat in _category
                                  join
                                  grou in context.Groups
                                  on
                                  cat.Id equals grou.CategoryId
                                  join
                                  product in context.Products
                                  on
                                  grou.Id equals product.GroupId
                                  select new ProductByCategoryVm
                                  {
                                      Id = product.Id,
                                      ProductEnglishName = product.ProductEnglishName,
                                      ProductName = product.ProductName,
                                      ProductImageSmall = product.ProductImageSmall,
                                      ProductPriceOffer = product.ProductPriceOffer,
                                      ProductPrice = product.ProductPrice,
                                      UpdateDate = product.UpdateDate
                                  };

                        foreach (var product in res)
                        {
                            var _product = new Product()
                            {
                                Id = product.Id,
                                ProductEnglishName = product.ProductEnglishName,
                                ProductName = product.ProductName,
                                ProductImageSmall = product.ProductImageSmall,
                                ProductPriceOffer = product.ProductPriceOffer,
                                ProductPrice = product.ProductPrice,
                                UpdateDate = product.UpdateDate
                            };
                            productsByCategory.Add(_product);
                        }
                        return View(productsByCategory.OrderBy(x => x.ProductPrice).ToPagedList(currentpage, pageSize));


                    }
                    //----------Brand-----------------//
                    if (!string.IsNullOrEmpty(brandEnglishName))
                    {
                        var brand = context.Brands.Include(x => x.Products).FirstOrDefault(x => x.BrandEnglishName == brandEnglishName);
                        ViewBag.BrandName = brand.BrandName;



                        var products3= context.Products.Where(x => x.BrandId == brand.Id).Select(x => new Product()
                        {
                            Id = x.Id,
                            ProductEnglishName = x.ProductEnglishName,
                            ProductName = x.ProductName,
                            ProductImageSmall = x.ProductImageSmall,
                            ProductPriceOffer = x.ProductPriceOffer,
                            ProductPrice = x.ProductPrice
                        }).OrderBy(x => x.ProductPrice).ToPagedList(currentpage, pageSize);
                        return View(products3);

                    }
                    //----------AllProducts-----------------//
                    var products4 = context.Products.Select(x => new Product()
                    {
                        Id = x.Id,
                        ProductEnglishName = x.ProductEnglishName,
                        ProductName = x.ProductName,
                        ProductImageSmall = x.ProductImageSmall,
                        ProductPriceOffer = x.ProductPriceOffer,
                        ProductPrice = x.ProductPrice,
                        UpdateDate = x.UpdateDate
                    }).OrderBy(x => x.ProductPrice).ToPagedList(currentpage, pageSize);
                    return View(products4);
                    break;

                default:

                    break;
            }
        }
        //----------Group-----------------//
        if (!string.IsNullOrEmpty(groupEnglishName))
        {
            var group = context.Groups.FirstOrDefault(x => x.GroupEnglishName == groupEnglishName);
            ViewBag.GroupName = group.GroupName;

            var products1 = context.Products.Where(x => x.GroupId == group.Id).Select(x => new Product()
            {
                Id = x.Id,
                ProductEnglishName = x.ProductEnglishName,
                ProductName = x.ProductName,
                ProductImageSmall = x.ProductImageSmall,
                ProductPriceOffer = x.ProductPriceOffer,
                ProductPrice = x.ProductPrice,
                UpdateDate = x.UpdateDate
            }).OrderByDescending(x => x.UpdateDate).ToList();
            return View(products1.ToPagedList(currentpage, pageSize));

        }
        //----------Category-----------------//
        if (!string.IsNullOrEmpty(categoryEnglishName))
        {
            var productsByCategory = new List<Product>();


            var _category = context.Categories.Where(x => x.CategoryEnglishName == categoryEnglishName);
            ViewBag.CategoryName = context.Categories.FirstOrDefault(x => x.CategoryEnglishName == categoryEnglishName).CategoryName;
            var res = from cat in _category
                      join
                      grou in context.Groups
                      on
                      cat.Id equals grou.CategoryId
                      join
                      product in context.Products
                      on
                      grou.Id equals product.GroupId
                      select new ProductByCategoryVm
                      {
                          Id = product.Id,
                          ProductEnglishName = product.ProductEnglishName,
                          ProductName = product.ProductName,
                          ProductImageSmall = product.ProductImageSmall,
                          ProductPriceOffer = product.ProductPriceOffer,
                          ProductPrice = product.ProductPrice,
                          UpdateDate = product.UpdateDate
                      };

            foreach (var product in res)
            {
                var _product = new Product()
                {
                    Id = product.Id,
                    ProductEnglishName = product.ProductEnglishName,
                    ProductName = product.ProductName,
                    ProductImageSmall = product.ProductImageSmall,
                    ProductPriceOffer = product.ProductPriceOffer,
                    ProductPrice = product.ProductPrice,
                    UpdateDate = product.UpdateDate
                };
                productsByCategory.Add(_product);
            }
            return View(productsByCategory.OrderByDescending(x => x.UpdateDate).ToPagedList(currentpage, pageSize));


        }
        //----------Brand-----------------//
        if (!string.IsNullOrEmpty(brandEnglishName))
        {
            var brand = context.Brands.Include(x => x.Products).FirstOrDefault(x => x.BrandEnglishName == brandEnglishName);
            ViewBag.BrandName = brand.BrandName;



            var products2 = context.Products.Where(x => x.BrandId == brand.Id).Select(x => new Product()
            {
                Id = x.Id,
                ProductEnglishName = x.ProductEnglishName,
                ProductName = x.ProductName,
                ProductImageSmall = x.ProductImageSmall,
                ProductPriceOffer = x.ProductPriceOffer,
                ProductPrice = x.ProductPrice
            }).OrderByDescending(x => x.UpdateDate).ToPagedList(currentpage, pageSize);
            return View(products2);

        }
        //----------AllProducts-----------------//
        var products = context.Products.Select(x => new Product()
        {
            Id = x.Id,
            ProductEnglishName = x.ProductEnglishName,
            ProductName = x.ProductName,
            ProductImageSmall = x.ProductImageSmall,
            ProductPriceOffer = x.ProductPriceOffer,
            ProductPrice = x.ProductPrice,
            UpdateDate = x.UpdateDate
        }).OrderByDescending(x => x.UpdateDate).ToPagedList(currentpage, pageSize);

        return View(products);

    }


}
