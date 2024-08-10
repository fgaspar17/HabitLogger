using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Validators
{
    public class StringValidator : IValidator<string>
    {
        public (bool, string) Validate(string input)
        {
            return (!string.IsNullOrEmpty(input), input);
        }
    }
}
