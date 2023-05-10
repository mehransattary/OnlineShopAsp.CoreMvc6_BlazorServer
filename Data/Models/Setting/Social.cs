using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class Social : ModelCommon
{
    public SocialEnum SocialEnum { get; set; }
    public byte SocialOrder { get; set; }
    [MaxLength(250)]
    public string? SocialLink { get; set; }

}
