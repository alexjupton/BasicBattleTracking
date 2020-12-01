using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.API
{
    public class Encounter
    {

        public event EventHandler OnSelectedCharacterChanged;
        public InitiativeTable InitiativeTable { get; set; }
        private Character active;
        public Character ActiveCharacter
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
                SelectedCharacter = value;
            }
        }
        private Character selected;
        public Character SelectedCharacter
        {
            get
            {
                return selected;
            }
            set
            {
                selected = value;
                SelectedCharacterChanged(EventArgs.Empty);
            }
        }
        public int TurnCount { get; set; }

        public Encounter()
        {
            InitiativeTable = new InitiativeTable();
        }

        protected virtual void SelectedCharacterChanged(EventArgs e)
        {
            EventHandler handler = OnSelectedCharacterChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public bool NextCharacter()
        {
            bool turnAdvance = false;
            if (InitiativeTable.ActiveList.Count > 0)
            {
                int index = -1;
                if (ActiveCharacter != null)
                {
                    index = InitiativeTable.ActiveList.IndexOf(ActiveCharacter);
                }
                index++;
                if (index < InitiativeTable.ActiveList.Count)
                {
                    ActiveCharacter = InitiativeTable.ActiveList.ElementAt(index);
                }
                else
                {
                    ActiveCharacter = InitiativeTable.ActiveList.First();
                    turnAdvance = true;
                }
            }
            return turnAdvance;
        }

        public void PreviousCharacter()
        {
            if (InitiativeTable.ActiveList.Count > 0)
            {
                int index = InitiativeTable.ActiveList.Count;
                if (ActiveCharacter != null)
                {
                    index = InitiativeTable.ActiveList.IndexOf(ActiveCharacter);
                }
                index--;
                if (index < 0)
                {
                    ActiveCharacter = InitiativeTable.ActiveList.Last();
                }
                else
                {
                    ActiveCharacter = InitiativeTable.ActiveList.ElementAt(index);
                }
            }
        }

        public async Task RollInitiative()
        {
            TurnCount = 0;
            await InitiativeTable.RollInitiative();
            if (InitiativeTable.ActiveList.Count > 0)
            {
                ActiveCharacter = InitiativeTable.ActiveList[0];
            }
        }

        public void AddCharacter(Character newChar)
        {
            InitiativeTable.AddCharacter(newChar);
        }
    }
}
