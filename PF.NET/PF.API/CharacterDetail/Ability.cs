using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.API.CharacterDetail
{
    public class Ability
    {
        public string Name { get; set; }
        public int Total
        {
            get
            {
                return Base + ScoreModifiers.Sum(x => x.Value);
            }
        }
        public int Base { get; set; }
        public List<Modifier> ScoreModifiers { get; set; }
        public int Modifier
        {
            get
            {
                return (int)(Math.Floor((decimal)((Total - 10) / 2)));
            }
        }
        public Ability()
        {
            ScoreModifiers = new List<Modifier>();
        }

        public static List<Ability> GetDefaultAbilities()
        {
            List<Ability> abilities = new List<Ability>();
            abilities.Add(new Ability() { Name = "Strength" });
            abilities.Add(new Ability() { Name = "Dexterity" });
            abilities.Add(new Ability() { Name = "Constitution" });
            abilities.Add(new Ability() { Name = "Intelligence" });
            abilities.Add(new Ability() { Name = "Wisdom" });
            abilities.Add(new Ability() { Name = "Charisma" });
            return abilities;
        }

    }
}
