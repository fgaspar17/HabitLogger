using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public class EnumValidator<T> : IValidator<T> where T : struct, Enum
    {
        public (bool, T) Validate(string input)
        {
            return (Enum.TryParse(input.Trim(), true, out T result) && Enum.IsDefined(typeof(T), result), result);
        }
    }
}
