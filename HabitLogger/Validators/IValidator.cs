﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public interface IValidator<T>
    {
        (bool, T) Validate(string input);
    }
}
