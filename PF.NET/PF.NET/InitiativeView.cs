using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PF.API;

namespace PF.Forms
{
    public partial class InitiativeView : UserControl
    {
        private InitiativeTable table;
        private Encounter currentEncounter;
        public InitiativeView()
        {
            InitializeComponent();
        }

        public void InitEncounter(Encounter encounter)
        {
            currentEncounter = encounter;
            table = encounter.InitiativeTable;
            table.OnListUpdate += Table_OnListUpdate;
            UpdateLists();
        }

        private void Table_OnListUpdate(object sender, EventArgs e)
        {
            UpdateLists();
        }

        private void UpdateLists()
        {
            List<ListViewItem> items = new List<ListViewItem>();
            foreach(Character active in table.ActiveList)
            {
                var newItem = Line(active, true);
                if (currentEncounter.ActiveCharacter != null && currentEncounter.ActiveCharacter == active)
                {
                    if (active.HP.Current <= 0)
                    {
                        newItem.BackColor = Color.Red;
                    }
                    else
                    {
                        newItem.BackColor = Color.Gold;
                    }
                }
                items.Add(newItem);
            }
            activeList.Items.Clear();
            activeList.Items.AddRange(items.ToArray());
            activeList.Columns[1].Width = -1;

            List<ListViewItem> inactiveItems = new List<ListViewItem>();
            foreach(Character inactive in table.InactiveList)
            {
                inactiveItems.Add(Line(inactive, false));
            }
            inactiveList.Items.Clear();
            inactiveList.Items.AddRange(inactiveItems.ToArray());
            inactiveList.Columns[1].Width = -1;
        }

        private ListViewItem Line(Character character, bool colorDying)
        {
            ListViewItem temp = new ListViewItem(character.Initiative.LastRollResult.Total.ToString());
            temp.SubItems.Add(character.Name);
            temp.SubItems.Add(character.HP.Current.ToString());
            if (colorDying && character.HP.Current <= 0)
            {
                temp.BackColor = Color.LightCoral;
            }
            return temp;
        }

        private async void btnRoll_Click(object sender, EventArgs e)
        {
            await currentEncounter.RollInitiative();
        }

        private void InitiativeView_Load(object sender, EventArgs e)
        {

        }
    }
}
