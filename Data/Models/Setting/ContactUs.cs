using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models;

    public class ContactUs : ModelCommon
    {
    [Required]
    public string ContactUsText { get; set; }
}

