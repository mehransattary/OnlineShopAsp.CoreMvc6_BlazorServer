using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Setting : ModelCommon
{
    //==================>>
    [MaxLength(200)]
    [Required]
    public string SettingSiteName { get; set; }
    //==================>>
    [MaxLength(200)]
    public string? SettingShopName { get; set; }
    //==================>>
    [MaxLength(450)]
    public string? SettingAddress { get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? SettingLogo { get; set; }
    //==================>>
    [MaxLength(11)]
    public string? SettingPhoneNumber { get; set; }
    //==================>>
}
