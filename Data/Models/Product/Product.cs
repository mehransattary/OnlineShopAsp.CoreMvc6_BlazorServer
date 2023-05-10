using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Data.Models;

public class Product : ModelCommon
{
    //==================>>
    [Required]
    [MaxLength(150)]
    public string ProductName { get; set; }
    //==================>>
    [MaxLength(150)]
    public string? ProductEnglishName { get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? ProductImageMain{ get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? ProductImageSmall { get; set; }
    //==================>>
    [Required]
    public int ProductOrder { get; set; }
    //==================>> 
    [Required]
    public double ProductPrice { get; set; }
    //==================>> 
    [Required]
    public double ProductPriceOffer { get; set; }
    //==================>> 
    [MaxLength(450)]
    public string? ProductShortDescription { get; set; }
    //==================>>
    public string? ProductDescription { get; set; }
    //==================>>
    [Required]
    public int GroupId { get; set; }
    //==================>>
    [Required]
    public int BrandId { get; set; }
    //==================>>

    [ForeignKey("GroupId")]
    public Group? Group { get; set; }
    //==================>>

    [ForeignKey("BrandId")]
    public Brand? Brand { get; set; }

}
