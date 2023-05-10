using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel;

public enum StatusSearchProductEnum
{

    [Display(Name = "جدیدترین")]
    News,
    [Display(Name = "ارزان ترین")]
    cheap,
    [Display(Name = "گران ترین")]
    Expensive
}
