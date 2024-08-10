using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger
{
    public class HabitIdMenu : IMenu
    {
        public string GetMenu()
        {
            StringBuilder sbMenu = new StringBuilder();

            sbMenu.AppendLine("Choose a Habit Id: ");

            return sbMenu.ToString();
        }
    }
}
