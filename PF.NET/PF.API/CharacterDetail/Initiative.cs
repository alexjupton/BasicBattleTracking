using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.API.CharacterDetail
{
    public class Initiative
    {
        public DieResult LastRollResult { get; set; }
        public int Value { get; set; }
        public Ability BaseAbility { get; set; }
        public List<Modifier> Modifiers { get; set; }
        public int Modifier
        {
            get
            {
                return Value + BaseAbility.Modifier + Modifiers.Sum(x => x.Value);
            }
        }

        public Initiative()
        {
            Modifiers = new List<Modifier>();
            LastRollResult = new DieResult() { DieRolls = new List<int>(), modifier = 0, Total = -1 };
        }

        public async Task<DieResult> Roll()
        {
            var result = await Dice.Roll(20, 1, Modifier);
            LastRollResult = result;
            return result;
        }
    }
}
