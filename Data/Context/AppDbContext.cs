using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context;

public class AppDbContext:DbContext
{
	public AppDbContext(DbContextOptions<AppDbContext> option):base(option)	
	{

	}

	public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }

    public DbSet<Role> Roles { get; set; }

    public DbSet<Setting> Settings { get; set; }

    public DbSet<Social> Socials { get; set; }

    public DbSet<Brand> Brands { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Group> Groups { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<Advertise> Advertises { get; set; }

    public DbSet<Slider> Sliders { get; set; }

    public DbSet<FactorDetails> FactorDetails { get; set; }
    public DbSet<FactorMain> FactorMain { get; set; }

    public DbSet<Post> Posts { get; set; }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<BlogCategory> BlogCategories { get; set; }

    public DbSet<BlogGroup> BlogGroups { get; set; }

    public DbSet<AbouteUs> AbouteUs { get; set; }

    public DbSet<ContactUs> ContactUs { get; set; }


}
