using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.API
{
    public class InitiativeTable
    {
        public event EventHandler OnListUpdate;
        public List<Character> ActiveList { get; set; }
        public List<Character> InactiveList { get; set; }

        public List<Character> AllChars { get; set; }
        public List<Character> Allies { get; set; }
        public List<Character> Enemies { get; set; }

        public async Task TransferCharacterToList(Character character, List<Character> sourceList, List<Character> destList)
        {
            if (sourceList.Contains(character))
            {
                await Task.Run(()=>destList.Add(character));
                await Task.Run(()=>sourceList.Remove(character));
            }
            await UpdateListCaches();
        }

        private async Task UpdateListCaches()
        {
            AllChars = await Task.Run(()=> ActiveList.Concat(InactiveList).ToList());
            Allies = await Task.Run(() => AllChars.Where(x => x.PlayerControlled).ToList());
            Enemies = await Task.Run(() => AllChars.Where(x => !x.PlayerControlled).ToList());

            EventHandler handler = OnListUpdate;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public InitiativeTable()
        {
            ActiveList = new List<Character>();
            InactiveList = new List<Character>();
            AllChars = new List<Character>();
            Allies = new List<Character>();
            Enemies = new List<Character>();
        }

        public async Task RollInitiative()
        {
            foreach(Character enemy in Enemies)
            {
                await enemy.Initiative.Roll();
            }
            ActiveList.OrderByDescending(x => x.Initiative.LastRollResult.Total).ThenBy(x => x.Abilities.Where(y => y.Name == "Dexterity").FirstOrDefault().Total);
            await UpdateListCaches();
        }

        public void AddCharacter(Character newChar)
        {
            ActiveList.Add(newChar);
            UpdateListCaches();
        }
    }
}
