using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class DateModifier
    {
        public DateModifier(string date1, string date2)
        {
            this.Date1 = DateTime.ParseExact(date1, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
            this.Date2 = DateTime.ParseExact(date2, "yyyy MM dd", System.Globalization.CultureInfo.InvariantCulture);
        }
        public DateTime Date1 { get; private set; }
        public DateTime Date2 { get; private set; }

        public int DayDifference()
        {
            return Math.Abs((this.Date1.Date - this.Date2.Date).Days);
        }
    }
}
