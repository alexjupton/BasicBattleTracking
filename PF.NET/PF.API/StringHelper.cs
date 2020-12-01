using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.API
{
    public class StringHelper
    {
        public static string FormatModifier(int mod)
        {
            if (mod < 0)
            {
                return mod.ToString();
            }
            else
            {
                return $"+{mod}";
            }
        }
    }
}
