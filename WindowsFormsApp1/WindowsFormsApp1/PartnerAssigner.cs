using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public class PartnerAssigner
    {
        public List<Person> people { get; set; }

        public PartnerAssigner()
        {
            people = new List<Person>();
        }

        public async Task AssignPartners()
        {
            Random randy = new Random();
            foreach(Person person in people)
            {
                var remainingPeople = people.Where(x => !x.Assigned && x != person);
                var partner = await Task.Run(()=>remainingPeople.ElementAt(randy.Next(remainingPeople.Count())));
                person.Partner = partner;
            }
        }
    }
}
