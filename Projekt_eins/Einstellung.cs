using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_eins
{
    public class Einstellung
    {
        public static bool darkmode = false;
        public static bool sound = false;
        public static void ToggelDarkMode()
        {
            darkmode = !darkmode;
        }

       
        public static void ToggelDarkSound()
        {
            sound = !sound;
        }
    }
 
}
