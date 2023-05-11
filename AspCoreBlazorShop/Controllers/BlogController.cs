using Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using X.PagedList;

namespace AspCoreBlazorShop.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext context;
        public BlogController(AppDbContext context)
        {
            this.context = context;
        }
        [Route("/Blogs")]
        public IActionResult ShowBlogs(int currentpage = 1)
        {

            var blogs = context.Blogs.ToPagedList(currentpage, 12);
            return View(blogs);
        }

        [Route("/Blog/{Id}")]
        public IActionResult DetailBlog(int Id )
        {
            var blog = context.Blogs.FirstOrDefault(x=>x.Id==Id);
            return View(blog);
        }
    }
}
