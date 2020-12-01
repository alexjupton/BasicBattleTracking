using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PF.API.CharacterDetail;

namespace PF.API
{
    [Serializable()]
    public class Character
    {
        public string Name { get; set; }
        public List<Ability> Abilities { get; set; }
        public bool PlayerControlled { get; set; }
        public Initiative Initiative { get; set; }
        public HitPoints HP { get; set; }

        public Character()
        {
            Abilities = Ability.GetDefaultAbilities();
            Initiative = new Initiative();
            HP = new HitPoints();
        }

        public Ability GetAbility(string abilityName)
        {
            return Abilities.Where(x => x.Name.ToLower() == abilityName.ToLower()).FirstOrDefault();
        }
    }
}
