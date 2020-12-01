using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class Person
    {
        private Person _partner;
        public string Name { get; set; }
        public bool Assigned { get; set; }
        public Person Partner
        {
            get
            {
                return _partner;
            }
            set
            {
                _partner = value;
                if (value != null)
                {
                    Partner.Assigned = true;
                }
            }
        }
    }
}
