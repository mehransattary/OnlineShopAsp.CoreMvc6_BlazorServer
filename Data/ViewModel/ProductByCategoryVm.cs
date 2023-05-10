using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModel;

public class ProductByCategoryVm
{
    public int Id { get; set; }
    public string ProductEnglishName { get; set; }

    public string ProductName { get; set; }
    public string ProductImageSmall { get; set; }
    public double ProductPriceOffer { get; set; }
    public double ProductPrice { get; set; }
    public DateTime UpdateDate { get; set; }

    

}
