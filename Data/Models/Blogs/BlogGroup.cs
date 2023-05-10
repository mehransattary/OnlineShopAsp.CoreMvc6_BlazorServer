using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class BlogGroup: ModelCommon
{
    //==================>>
    [Required]
    [MaxLength(150)]
    public string BlogGroupName { get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? BlogGroupImage { get; set; }
    //==================>>
    [Required]
    public int BlogGroupOrder { get; set; }
    //==================>> 
    [MaxLength(450)]
    public string? BlogGroupShortDescription { get; set; }
    //==================>>
    public string? BlogGroupDescription { get; set; }
    //==================>>
    public bool BlogGroupIsEnableForMainPage { get; set; }
    //==================>> 
    [Required]
    public int BlogCategoryId { get; set; }
    //==================>>
    [ForeignKey(nameof(BlogCategoryId))]
    public BlogCategory? BlogCategory { get; set; }
}
