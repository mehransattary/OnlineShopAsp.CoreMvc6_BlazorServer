using System.ComponentModel.DataAnnotations;


namespace Data.Models;

public class Category : ModelCommon
{
    //==================>>
    [Display(Name ="نام دسته")]
    [Required(ErrorMessage ="لطفا {0}  را وارد نمائید.")]
    [MaxLength(150)]
    public string CategoryName { get; set; }
    //==================>>
    [Display(Name = "نام انگلیسی دسته")]
    [MaxLength(150)]
    public string? CategoryEnglishName { get; set; }
    //==================>>
    [Display(Name = "تصویر")]   
    [MaxLength(1500)]
    public string? CategoryImage { get; set; }
    //==================>>
    [Display(Name = "ترتیب")]
    [Required(ErrorMessage = "لطفا {0}  را وارد نمائید.")]
    public int CategoryOrder { get; set; }
    //==================>> 
    [Display(Name = "توضیح کوتاه")] 
    [MaxLength(450)]
    public string? CategoryShortDescription { get; set; }
    //==================>>
    [Display(Name = "توضیح کامل")]
    public string? CategoryDescription { get; set; }
    //==================>> 
    public bool CategoryIsEnableForMainPage { get; set; }
    //==================>> 

    public ICollection<Group>? Groups { get; set; }

}
