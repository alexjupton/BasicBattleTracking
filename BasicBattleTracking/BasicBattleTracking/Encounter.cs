using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicBattleTracking.FighterDetail;
using BasicBattleTracking.Forms;

namespace BasicBattleTracking
{
    public class Encounter
    {
        public List<Event.EncounterEvent> eventsList { get; set; }
        public int Turn { get; set; }

        public List<Fighter> activeFighters = new List<Fighter>();
        public List<Fighter> inactiveFighters = new List<Fighter>();

        public Encounter(List<Fighter> allFighters)
        {
            activeFighters = allFighters;
        }

        public async Task BeginRollInitiative()
        {
            List<Fighter> manualRolled = new List<Fighter>();
            foreach(Fighter fighter in activeFighters)
            {
                if (fighter.isPC)
                {
                    manualRolled.Add(fighter);
                }
                else
                {
                    await fighter.RollInitiative();
                }
            }

            if (manualRolled.Count > 0)
            {
                PC_Initiative pcInit = new PC_Initiative(manualRolled);
                pcInit.FormClosing += PcInit_FormClosing;
            }
            else
            {
                await EndRollInitiative();
            }
        }

        private async Task EndRollInitiative()
        {
            await Task.Run(()=> activeFighters.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Dex));
            Turn++;
        }

        private void PcInit_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
