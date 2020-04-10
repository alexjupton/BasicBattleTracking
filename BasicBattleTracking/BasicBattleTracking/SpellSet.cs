using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleCore.FighterDetail;

namespace BasicBattleTracking
{
    public class SpellSet
    {
        public List<Spell> spellsKnown { get; set; }
        public List<int> spellSlotsPerLevel { get; set; }
        public int SpellPoints { get; set; }    
        

    }
}
