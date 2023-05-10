using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class Group : ModelCommon
{
    //==================>>
    [Required(ErrorMessage = "لطفا {0}  را وارد نمائید.")]
    [MaxLength(150)]
    [Display(Name = "نام گروه")]
    public string GroupName { get; set; }
    //==================>>
    [Display(Name = "نام انگلیسی گروه")]
    [MaxLength(150)]
    public string? GroupEnglishName { get; set; }
    //==================>>
    [MaxLength(1500)]
    [Display(Name = "تصویر گروه")]
    public string? GroupImage { get; set; }
    //==================>>
    [Required(ErrorMessage = "لطفا {0}  را وارد نمائید.")]
    [Display(Name = "ترتیب گروه")]
    public int GroupOrder { get; set; }
    //==================>> 
    [MaxLength(450)]
    [Display(Name = "توضیحات کوتاه گروه")]
    public string? GroupShortDescription { get; set; }
    //==================>>
    [Display(Name = "توضیحات  گروه")]
    public string? GroupDescription { get; set; }
    //==================>>
    [Display(Name = "فعال بودن گروه")]
    public bool GroupIsEnableForMainPage { get; set; }
    //==================>> 
    [Display(Name = " دسته")]
    [Required(ErrorMessage = "لطفا {0}  را وارد نمائید.")]
    public int CategoryId { get; set; }
    //==================>>
    [ForeignKey(nameof(CategoryId))]
    public Category? Category { get; set; }

    public ICollection<Product>? Products { get; set; }

}
