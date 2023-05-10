
using System.ComponentModel.DataAnnotations;


namespace Data.Models;

public class Advertise : ModelCommon

{
    //==================>>
    [Required]
    [MaxLength(1500)]
    public string AdvertiseImage { get; set; }
    //==================>>
    [MaxLength(150)]
    public string? AdvertiseName { get; set; }
    //==================>>
    [MaxLength(400)]
    public string? AdvertiseUrl { get; set; }
    //==================>>
}
