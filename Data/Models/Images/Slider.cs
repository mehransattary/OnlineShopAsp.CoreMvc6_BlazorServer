
using System.ComponentModel.DataAnnotations;


namespace Data.Models;

public class Slider : ModelCommon
{
    //==================>>
    [Required]
    [MaxLength(1500)]
    public string SliderImage { get; set; }
    //==================>>
    [MaxLength(150)]
    public string? SliderName { get; set; }
    //==================>>
    [MaxLength(250)]
    public string? SliderShortDescription { get; set; }
    //==================>>
    [MaxLength(400)]
    public string? SliderUrl { get; set; }
    //==================>>

}
