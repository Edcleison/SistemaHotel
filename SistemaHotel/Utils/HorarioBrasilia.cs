using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaHotel.Utils
{
    public static class HorarioBrasilia
    {
        public static DateTime getHoraBrasilia() => TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time"));

    }
}