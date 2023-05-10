using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel;

public class ProductAdminIndexViewModel
{
    public string? ProductName { get; set; }
    public string? ProductImageSmall { get; set; }
    public int ProductOrder { get; set; }
    public string?  GroupName { get; set; }
    public string? BrandName { get; set; }
    public int ProductId { get; set; }

    public double ProductPrice { get; set; }
    public double ProductPriceOffer { get; set; }

}
