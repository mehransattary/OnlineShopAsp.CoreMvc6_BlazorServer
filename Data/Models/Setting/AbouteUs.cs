using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

public class AbouteUs: ModelCommon
{
    [Required]
    public string AbouteText { get; set; }
}

