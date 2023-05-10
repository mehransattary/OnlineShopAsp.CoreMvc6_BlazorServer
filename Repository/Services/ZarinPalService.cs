using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Services;

public class ZarinPalService : IZarinPalService
{
    public string PaymentZarinPal(string mobile, string amount, string callbackurl)
    {
        //var payment = new Zarinpal.Payment("merchant", Convert.ToInt32(amount));
        var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(amount));
        var result = payment.PaymentRequest("توضیحات من", callbackurl,null, mobile).Result;
        if(result.Status==100)
        {
            return result.Link;
        }
        else
        {
           return "";   
        }


    }

    public string VerifyPay(string amount, string authority)
    {
        //var payment = new Zarinpal.Payment("merchant", Convert.ToInt32(amount));
         var payment = new ZarinpalSandbox.Payment(Convert.ToInt32(amount));
        var result = payment.Verification(authority).Result;
        if(result.Status==100)
        {
            return result.RefId.ToString();
        }
        else
        {
            return "";
        }
    }
}
