﻿using System;
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
    public partial class AddFighterWindow : Form
    {
        public Fighter NewPC { get; private set; }
        public AddFighterWindow()
        {
            InitializeComponent();
            string ttCaption = "Enter the full Dexterity score, not the modifier. This will be used to resolve initiative ties.";
            toolTip1.SetToolTip(label4, ttCaption);
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            string name = "";
            int init = 0;
            bool errorFlag = false;
            string errorMessage = "";
            

            if (nameBox.Text != "")
            {
                name = nameBox.Text;
            }
            else
            {
                errorFlag = true;
                errorMessage += "Name cannot be blank.\n";
            }

            try
            {
                init = Int32.Parse(InitBox.Text);
            }
            catch
            {
                errorFlag = true;
                errorMessage = "Initiative Bonus must be a valid integer. \n";
            }

            if (errorFlag)
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK);
            }
            else
            {
                Fighter combatant = new Fighter(name, init, true);
                try
                {
                    combatant.Dex = Int32.Parse(dexBox.Text);
                }
                catch
                { }
                NewPC = combatant;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void cButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AddFighterWindow_Load(object sender, EventArgs e)
        {

        }
    }
}
