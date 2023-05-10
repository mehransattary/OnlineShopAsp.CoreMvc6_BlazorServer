
using System.ComponentModel.DataAnnotations;

namespace Data.Models;

public class FactorMain: ModelCommon
{
    //==================>>
    [Required]
    public DateTime FactorMainDate { get; set; }
    //==================>>
    [MaxLength(100)]
    [Required]
    public string FactorMainNumber { get; set; }
    //==================>>
    [Required]
    [MaxLength(100)]
    public string FactorMainPayNumber { get; set; }
    //==================>>
    [Required]
    public double FactorMainSumPriceAll { get; set; }
    //==================>>
    [Required]
    public bool FactorMainIsPay { get; set; }
    //==================>>

    //========خریدار=================//
    [MaxLength(250)]
    [Required]
    public string FactorMainBuyerFullName { get; set; }
    //==================>>
    [Required]
    [MaxLength(450)]
    public string FactorMainBuyerAddress { get; set; }
    //==================>>
    [MaxLength(11)]
    public string? FactorMainBuyerMobile { get; set; }
    //==================>>
    [MaxLength(20)]
    public string? FactorMainBuyerCodePosti { get; set; }
    //==================>>


    //========فروشنده=================//
    [MaxLength(250)]
    [Required]
    public string FactorMainSellerFullName { get; set; }
    //==================>>
    [MaxLength(450)]  
    public string? FactorMainSellerAddress { get; set; }
    //==================>>
    [MaxLength(20)]
    public string? FactorMainSellerPhoneNumber { get; set; }
    //==================>>


    public ICollection<FactorDetails>? FactorDetails { get; set; }

}
