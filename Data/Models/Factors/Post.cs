

using System.ComponentModel.DataAnnotations;


namespace Data.Models;

public class Post : ModelCommon
{
    //==================>>
    [MaxLength(200)]
    [Required]
    public string PostName { get; set; }
    //==================>>
    [Required]
    public int PostPrice { get; set; }
    //==================>>
}
