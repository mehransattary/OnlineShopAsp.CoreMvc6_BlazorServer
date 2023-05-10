using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel;

public class ShopCartViewModel
{
    public int ProductId { get; set; }
    public int Count { get; set; }

    public string? ProductName { get; set; }
    public string? ProductEnglishName { get; set; }
    public string? ProductImage { get; set; }
    public double ProductPrice { get; set; }
    public double ProductSumPrice { get; set; }

}
