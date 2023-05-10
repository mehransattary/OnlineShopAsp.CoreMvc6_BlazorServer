
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Models;

public class User : ModelCommon
{
    //==================>>
    [MaxLength(200)]
    [Display(Name ="نام کامل")]
    public string? FullName { get; set; }
    //==================>>
    [Required(ErrorMessage ="لطفا {0} را وارد کنید.")]
    [MaxLength(11)]
    [Display(Name = "موبایل ")]
    public string Mobile { get; set; }
    //==================>>
    [Required(ErrorMessage = "لطفا {0} را وارد کنید.")]
    [MaxLength(200)]
    [Display(Name = "رمز عبور ")]
    public string Password { get; set; }
    //==================>>
    [MaxLength(450)]
    public string? Address { get; set; }
    //==================>>
    [MaxLength(20)]
    public string? CodePosti { get; set; }
    //==================>>
    [MaxLength(200)]
    public string? City { get; set; }
    //==================>>
    public StateEnum State { get; set; }
    //==================>>
    [Required]
    public int RoleId { get; set; }
    //==================>>

    [ForeignKey(nameof(RoleId))]
    public Role? Role { get; set; }

}
 public enum StateEnum
 {
    [Display(Name ="آذربایجان شرقی")]
    Az_Sh=1,
    [Display(Name = "آذربایجان غربی")]
    Az_Gar = 2,
    [Display(Name = "تهران ")]
    Tehran =3,

 }