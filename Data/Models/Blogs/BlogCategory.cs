using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class BlogCategory: ModelCommon
{
    //==================>>
    [Required]
    [MaxLength(150)]
    public string BlogCategoryName { get; set; }
    //==================>>
    [MaxLength(150)]
    public string? BlogCategoryEnglishName { get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? BlogCategoryImage { get; set; }
    //==================>>
    [Required]
    public int BlogCategoryOrder { get; set; }
    //==================>> 
    [MaxLength(450)]
    public string? BlogCategoryShortDescription { get; set; }
    //==================>>
    public string? BlogCategoryDescription { get; set; }
    //==================>> 
    public bool BlogCategoryIsEnableForMainPage { get; set; }
    //==================>> 

    public ICollection<BlogGroup>? BlogGroups { get; set; }
}
