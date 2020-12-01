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
using PF.Forms;

namespace PF.NET
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Session session;

        private void MainForm_Load(object sender, EventArgs e)
        {
            session = new Session();
            initiativeView1.InitEncounter(session.Encounter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddCharacter addCharacter = new AddCharacter();
            addCharacter.FormClosing += AddWindow_FormClosing;
            addCharacter.Show();
        }

        private void AddWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sender is AddCharacter)
            {
                AddCharacter newChar = (AddCharacter)sender;
                if (newChar.Character != null)
                {
                    session.AddCharacter(newChar.Character);
                }
            }
        }
    }
}
