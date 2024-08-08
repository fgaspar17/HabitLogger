using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public static class ValidatorFactory
    {
        public static IValidator<T> GetValidator<T>()
        {
            if(typeof(T) == typeof(int))
            {
                return (IValidator<T>)new IntValidator();
            }

            if(typeof(T).IsEnum)
            {
                return (IValidator<T>)Activator.CreateInstance(typeof(EnumValidator<>).MakeGenericType(typeof(T)));
            }

            throw new NotImplementedException($"There's no validator for {typeof(T)}");
        }
    }
}
