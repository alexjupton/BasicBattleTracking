﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BasicBattleTracking
{
    public partial class AttackForm : Form
    {
        private MainWindow sendingForm;
        private List<Fighter> PCs;
        public string attackerName { get; set; }
        public bool isStatus { get; set; }
        public AttackForm(MainWindow sender, List<Fighter> combatants)
        {
            sendingForm = sender;
            InitializeComponent();
            PCs = new List<Fighter>();
            foreach (Fighter f in combatants)
            {
                if (!f.isPC)
                {
                    PCs.Add(f);
                    targetBox.Items.Add(f.Name);
                }
            }

            foreach (Fighter f in combatants)
            {
                if (f.isPC)
                {
                    PCs.Add(f);
                    targetBox.Items.Add(f.Name);
                }
            }
            targetBox.SelectedIndex = 0;
        }

        private void AttackForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (targetBox.SelectedIndex >= 0 && targetBox.SelectedIndex <= targetBox.Items.Count)
            {
                Fighter victim = PCs.ElementAt(targetBox.SelectedIndex);
                int damage = 0;

                try
                {
                    damage = Int32.Parse(DamageBox.Text);
                }
                catch
                {
                    MessageBox.Show("Invalid damage amount.", "Error", MessageBoxButtons.OK);
                }

                if (!victim.isPC)
                    victim.HP -= damage;


                sendingForm.LogAttack(victim.Name, damage);
                if (victim.HP <= 0 && !victim.isPC)
                {
                    sendingForm.removeFighter(victim);
                    sendingForm.WriteToLog(victim.Name + " has died!");
                    victim.StatusEffects.Clear();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid target");
                targetBox.SelectedIndex = 0;
            }
        }

        private void targetBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
