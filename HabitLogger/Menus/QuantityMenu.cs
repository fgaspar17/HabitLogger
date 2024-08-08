using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitLogger.Menus
{
    public class QuantityMenu : IMenu
    {
        public string GetMenu()
        {
            StringBuilder sbMenu = new StringBuilder();

            sbMenu.AppendLine("Introduce a Quantity: ");

            return sbMenu.ToString();
        }
    }
}
