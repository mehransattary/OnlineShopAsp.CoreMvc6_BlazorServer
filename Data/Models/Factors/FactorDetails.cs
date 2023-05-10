
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models;

public class FactorDetails: ModelCommon
{
    //==================>>
    [MaxLength(100)]
    [Required]
    public string FactorDetailsNameProduct { get; set; }
    //==================>>
    [Required]
    public int FactorDetailsCountProduct { get; set; }
    //==================>>
    [Required]
    public double FactorDetailsPriceProduct { get; set; }
    //==================>>
    [Required]
    public double FactorDetailsSumPriceProduct { get; set; }
    //==================>>
    [Required]
    public int FactorMainId { get; set; }
    //==================>>

    [ForeignKey("FactorMainId")]
    public FactorMain? FactorMain { get; set; }
}
