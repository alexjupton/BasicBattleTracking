using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.API.CharacterDetail
{
    public class Modifier
    {
        public string Name { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return $"{StringHelper.FormatModifier(Value)} ({Name})";
        }
    }
}
