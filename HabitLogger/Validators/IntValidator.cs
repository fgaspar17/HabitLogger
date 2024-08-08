using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public class IntValidator : IValidator<int>
    {
        public (bool, int) Validate(string input)
        {
            return (int.TryParse(input, out int result), result);
        }
    }
}
