
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Role : ModelCommon
{
    //==================>>
    [Required]
    [MaxLength(200)]
    public string RoleName { get; set; }
    //==================>>
    [Required]
    [MaxLength(200)]
    public string RoleTitle { get; set; }
    //==================>>
    public ICollection<User>? Users { get; set; }

}
