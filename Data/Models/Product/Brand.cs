using System.ComponentModel.DataAnnotations;

namespace Data.Models;


public class Brand : ModelCommon
{
    //==================>>
    [Required(ErrorMessage = "لطفا {0}  را وارد نمائید.")]
    [MaxLength(150)]
    [Display(Name = "نام برند")]
    public string BrandName { get; set; }
    //==================>>
    [Display(Name = "نام انگلیسی برند")]
    [MaxLength(150)]
    public string? BrandEnglishName { get; set; }
    //==================>>
    [Display(Name = "تصویر برند")]
    [MaxLength(1500)]
    public string? BrandImage { get; set; }
    //==================>>
    [Display(Name = "ترتیب برند")]
    [Required(ErrorMessage = "لطفا {0}  را وارد نمائید.")]
    public int BrandOrder { get; set; }
    //==================>> 
    [Display(Name = "توضیحات کوتاه برند")]
    [MaxLength(450)]
    public string? BrandShortDescription { get; set; }
    //==================>>
    [Display(Name = "توضیحات برند")]
    public string? BrandDescription { get; set; }
    //==================>>
    [Display(Name = " فعال بودن برند")]
    public bool BrandIsEnableForMainPage { get; set; }
    //==================>> 
    public ICollection<Product>? Products { get; set; }

}
