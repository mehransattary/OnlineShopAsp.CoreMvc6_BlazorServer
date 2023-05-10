using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zarinpal;

namespace Repository.Interface;

public interface IZarinPalService
{
    string PaymentZarinPal(string mobile,string amount,string callbackurl);
     string VerifyPay(string amount,string authority);
}
