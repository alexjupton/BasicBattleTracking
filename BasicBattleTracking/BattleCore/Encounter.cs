using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCore.FighterDetail;

namespace BattleCore
{
    public class Encounter
    {
        public List<Fighter> combatants { get; private set; }
        public List<Fighter> dyingCombatants { get; private set; }
        public List<Fighter> deadCombatants { get; private set; }
        public Fighter activeFighter { get; private set; }
        public Fighter disaplyFighter { get; private set; }
    }
}
