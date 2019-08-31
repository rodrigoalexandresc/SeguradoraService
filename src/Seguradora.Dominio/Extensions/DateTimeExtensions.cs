using System;
using System.Collections.Generic;
using System.Text;

namespace Seguradora.Dominio.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime RetornaQuintoDiaUtil(this DateTime data)
        {
            var primeiroDia = new DateTime(data.Year, data.Month, 1);

            Func<int> quintoDia = () =>
            {
                switch (primeiroDia.DayOfWeek)
                {
                    case DayOfWeek.Monday:
                        return 5;
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        return 6;
                    default:
                        return 7;
                }
            };

            return new DateTime(data.Year, data.Month, quintoDia());

        }
    }
}
