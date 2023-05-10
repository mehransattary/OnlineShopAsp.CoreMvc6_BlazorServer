using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common;

public static class DateExtention
{

    public static string ToShamsi(this DateTime date)
    {
        PersianCalendar pc = new PersianCalendar();
        return pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + pc.GetDayOfMonth(date);
    }
}
