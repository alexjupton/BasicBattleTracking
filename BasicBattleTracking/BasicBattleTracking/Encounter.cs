using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicBattleTracking.FighterDetail;
using BasicBattleTracking.Forms;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    public class Encounter
    {
        public event EventHandler UpdateFighterList;

        public List<Event.EncounterEvent> eventsList { get; set; }
        public int Turn { get; set; }

        public List<Fighter> activeFighters = new List<Fighter>();
        public List<Fighter> inactiveFighters = new List<Fighter>();

        public Fighter upFighter;
        public Fighter displayFighter;

        private PC_Initiative pcInitiative;
        private AddFighterWindow addPC;

        public Encounter()
        {
            activeFighters = new List<Fighter>();
            inactiveFighters = new List<Fighter>();
        }

        public Encounter(List<Fighter> allFighters)
        {
            activeFighters = allFighters;
            upFighter = new Fighter();
            displayFighter = upFighter;
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
                pcInitiative = pcInit;
                pcInit.Show();
            }
            else
            {
                await EndRollInitiative();
            }
        }

        private async Task EndRollInitiative()
        {
            await Task.Run(()=> activeFighters.OrderByDescending(x => x.Initiative).ThenByDescending(x => x.Dex));
            upFighter = activeFighters[0];
            Turn++;
        }

        private async void PcInit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (pcInitiative.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                await EndRollInitiative();
            }
        }

        public async Task NextFighter()
        {
            int nextIndex = 0;
            if (activeFighters.IndexOf(upFighter) < activeFighters.Count - 1)
            {
                nextIndex = activeFighters.IndexOf(upFighter) + 1;
            }
            else if (Program.activeSettings.initEachRound)
            {
                await BeginRollInitiative();
            }
            else
            {
                Turn++;
            }
            upFighter = activeFighters[nextIndex];
        }

        public void BeginAddPC()
        {
            addPC = new AddFighterWindow();
            addPC.FormClosed += AddPC_FormClosed;
            addPC.Show();
        }

        private void EndAddPC(Fighter newPC)
        {
            activeFighters.Add(newPC);
            OnUpdateFighterList(EventArgs.Empty);
        }

        private void AddPC_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (addPC.DialogResult == DialogResult.OK)
            {
                Fighter newPC = addPC.NewPC;
                EndAddPC(newPC);
            }
        }

        protected virtual void OnUpdateFighterList(EventArgs e)
        {
            EventHandler handler = UpdateFighterList;
            handler?.Invoke(this, e);
        }

        public void ChangeDisplayFighter(int charIndex)
        {
            if(charIndex < activeFighters.Count)
            {
                displayFighter = activeFighters[charIndex];
            }
        }
    }
}
