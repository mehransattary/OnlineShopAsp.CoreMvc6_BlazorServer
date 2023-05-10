using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Blog: ModelCommon
{
    //==================>>
    [Required]
    [MaxLength(150)]
    public string BlogName { get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? BlogImageMain { get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? BlogImageSmall { get; set; }
    //==================>>
    [Required]
    public int BlogOrder { get; set; }
    //==================>> 
    [MaxLength(450)]
    public string? BlogShortDescription { get; set; }
    //==================>>
    [Required(ErrorMessage ="لطفا {0} را وارد نمائید.")]
    [Display(Name ="متن مقاله")]
    public string BlogDescription { get; set; }
    //==================>>
    public bool BlogIsEnableForMainPage { get; set; }
    //==================>> 
    [Required]
    public int BlogGroupId { get; set; }
    //==================>>
    [ForeignKey(nameof(BlogGroupId))]
    public BlogGroup? BlogGroup { get; set; }
}
