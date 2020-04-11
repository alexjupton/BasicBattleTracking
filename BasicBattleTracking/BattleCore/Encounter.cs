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

        public Encounter()
        {
            combatants = new List<Fighter>();
            dyingCombatants = new List<Fighter>();
            deadCombatants = new List<Fighter>();
            activeFighter = new Fighter();
            disaplyFighter = new Fighter();
        }

        public void AddFighter(Fighter newFighter)
        {
            combatants.Add(newFighter);
            LogMessageQueue.Log($"Added {newFighter.Name}");
            EvaluateDeathStatus();
        }
        
        public async Task AddFighter(List<Fighter> newFighters)
        {
            foreach(Fighter f in newFighters)
            {
                combatants.Add(f);
                LogMessageQueue.Log($"Added {f.Name}");
            }
            EvaluateDeathStatus();
            await EvaluateInitiativeOrder();
        }

        private void EvaluateDeathStatus()
        {
            List<Fighter> aliveToDying = new List<Fighter>();
            List<Fighter> aliveToDead = new List<Fighter>();
            foreach(Fighter alive in combatants)
            {
                if (!alive.isPC)
                {
                    if (alive.HP <= 0 && Math.Abs(alive.HP) < alive.Con)
                    {
                        aliveToDying.Add(alive);
                        LogMessageQueue.Log($"{alive.Name} is unconscious, but still alive!");
                    }
                    else if (alive.HP <= 0)
                    {
                        aliveToDead.Add(alive);
                        LogMessageQueue.Log($"{alive.Name} was completely killed!");
                    }
                }
            }
            TransferFightersToNewList(combatants, dyingCombatants, aliveToDying);
            TransferFightersToNewList(combatants, deadCombatants, aliveToDead);

            List<Fighter> dyingToDead = new List<Fighter>();
            foreach (Fighter dying in dyingCombatants)
            {
                if (Math.Abs(dying.HP) >= dying.Con)
                {
                    dyingToDead.Add(dying);
                    LogMessageQueue.Log($"{dying.Name} bled out!");
                }
            }
            TransferFightersToNewList(dyingCombatants, deadCombatants, dyingToDead);
        }

        private void TransferFightersToNewList(List<Fighter> oldList, List<Fighter> newList, List<Fighter> fightersToMove)
        {
            foreach(Fighter f in fightersToMove)
            {
                if (oldList.Contains(f))
                {
                    oldList.Remove(f);
                }
                newList.Add(f);
            }

        }

        private async Task EvaluateInitiativeOrder()
        {
            List<Task> sortTasks = new List<Task>();
            sortTasks.Add(Task.Run(() => combatants.OrderByDescending(x => x.Initiative)));
            sortTasks.Add(Task.Run(() => dyingCombatants.OrderByDescending(x => x.Initiative)));
            sortTasks.Add(Task.Run(() => deadCombatants.OrderByDescending(x => x.Initiative)));
            await Task.WhenAll(sortTasks);
        }
    }
}
