using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleCore.FighterDetail;

namespace BasicBattleTracking
{
    public partial class PC_Initiative : Form
    {
        private List<TextBox> initBoxes;
        private List<Fighter> fighters;

        public PC_Initiative(List<Fighter> pcs = null)
        {
            initBoxes = new List<TextBox>();
            pcs = pcs ?? new List<Fighter>();
            setPCList(pcs);
        }
        private void setPCList(List<Fighter> PCs)
        {
            int yOffset = 32;
            int index = 1;
            int labelX = 6;
            int boxX = 74;
            fighters = PCs;
            foreach (Fighter pc in PCs)
            {
                Label newLabel = new Label();
                newLabel.AutoSize = true;
                newLabel.Location = new Point(labelX, yOffset * index);
                newLabel.Name = "label" + index;
                newLabel.Text = pc.Name;

                TextBox newBox = new TextBox();
                newBox.Location = new Point(boxX, yOffset * index);
                newBox.Name = "TextBox" + index;
                newBox.TabIndex = index;

                initBoxes.Add(newBox);

                groupBox1.Controls.Add(newLabel);
                groupBox1.Controls.Add(newBox);

                index++;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Submit();
        }

        private List<Fighter> GetFightersWithInvalidInitiatives()
        {
            List<Fighter> invalidFighters = new List<Fighter>();
            foreach(TextBox box in initBoxes)
            {
                if (!string.IsNullOrEmpty(box.Text))
                {
                    if (!Int32.TryParse(box.Text, out int i))
                    {
                        invalidFighters.Add(fighters.ElementAt(initBoxes.IndexOf(box)));
                    }
                }
            }
            return invalidFighters;
        }

        private async Task UpdateInitiative()
        {
            foreach(TextBox box in initBoxes)
            {
                Fighter updateFighter = fighters.ElementAt(initBoxes.IndexOf(box));
                int init = 0;
                if (!string.IsNullOrEmpty(box.Text))
                {
                    init = await Task.Run(()=>Int32.Parse(box.Text));
                }
                updateFighter.Initiative = init;
            }
        }

        private async Task Submit()
        {
            List<Fighter> invalidFighters = GetFightersWithInvalidInitiatives();
            if (invalidFighters.Count > 0)
            {
                StringBuilder message = new StringBuilder("Invalid values for the following PCs:\n");
                foreach(Fighter f in invalidFighters)
                {
                    message.AppendLine(f.Name);
                }
                MessageBox.Show(message.ToString(), "Cannot set PC initiative", MessageBoxButtons.OK);
            }
            else
            {
                await UpdateInitiative();
            }
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PC_Initiative_Load(object sender, EventArgs e)
        {

        }
    }
}
