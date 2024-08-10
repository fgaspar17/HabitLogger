using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public class DateTimeValidator : IValidator<DateTime>
    {
        public (bool, DateTime) Validate(string input)
        {
            return (DateTime.TryParseExact(input, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result), result);
        }
    }
}
