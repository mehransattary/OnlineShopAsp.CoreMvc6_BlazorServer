using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class Service : ModelCommon
{
    //==================>>
    [Required]
    [MaxLength(150)]
    public string ServiceName { get; set; }
    //==================>>
    [MaxLength(1500)]
    public string? ServiceImage { get; set; }
    //==================>>
    [Required]  
    public int ServiceOrder { get; set; }
    //==================>> 
    [MaxLength(450)]
    public string? ServiceShortDescription { get; set; }
    //==================>>
    [Required]
    public string? ServiceDescription { get; set; }
    //==================>>
    public bool ServiceIsEnableForMainPage { get; set; }
    //==================>> 

}
