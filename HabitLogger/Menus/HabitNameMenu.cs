using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Menus
{
    public class HabitNameMenu : IMenu
    {
        public string GetMenu()
        {
            StringBuilder sbMenu = new StringBuilder();

            sbMenu.AppendLine("Introduce a Name for the Habit: ");

            return sbMenu.ToString();
        }
    }
}
