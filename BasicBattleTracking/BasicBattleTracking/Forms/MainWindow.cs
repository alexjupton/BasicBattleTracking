using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using BattleCore;
using BattleCore.FighterDetail;

namespace BasicBattleTracking
{
    [Serializable()]
    public partial class MainWindow : Form
    {
        private Encounter encounter = new Encounter();
        public MainWindow()
        {
            InitializeComponent();
            this.Visible = false;
            this.WindowState = FormWindowState.Minimized;
        }
        private async void MainWindow_Load(object sender, EventArgs e)
        {
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.Show();
            splashScreen.Close();
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            ObserveMessageQueue();
        }

        public void UpdateFighterList()
        {
            List<Task> taskList = new List<Task>();
            FillFighters(InitOrderView, encounter.combatants);
            FillFighters(lvwDying, encounter.dyingCombatants);
            FillFighters(lvwDead, encounter.deadCombatants);
        }

        private void FillFighters(ListView listView, List<Fighter> fighters)
        {
            listView.Items.Clear();
            int order = 1;
            List<ListViewItem> addItems = new List<ListViewItem>();
            foreach (Fighter f in fighters)
            {
                ListViewItem item = new ListViewItem(order.ToString());
                item.SubItems.Add(f.Name);
                item.SubItems.Add(f.Initiative.ToString());
                item.SubItems.Add(f.HP.ToString());
                item.SubItems.Add(f.HoldAction ? "Yes" : "No");
                addItems.Add(item);
                order++;
            }
            listView.Items.AddRange(addItems.ToArray());
        }

        public void AddPC()
        {
            AddFighterWindow addPC = new AddFighterWindow();
            addPC.FormClosed += (sender, e) =>
            {
                if (addPC.DialogResult == DialogResult.OK)
                {
                    encounter.AddFighter(addPC.NewPC);
                    UpdateFighterList();
                }
            };
            addPC.Show();
        }

        public void AddNPC()
        {
            StatBlockDesigner addNPC = new StatBlockDesigner();
            addNPC.FormClosed += async (sender, e) =>
            {
                if (addNPC.DialogResult == DialogResult.OK)
                {
                    await encounter.AddFighter(addNPC.addFighters);
                    UpdateFighterList();
                }
            };
            addNPC.Show();
        }

        private async Task ObserveMessageQueue()
        {
            while (true)
            {
                while (LogMessageQueue.msgQueue.Count > 0)
                {
                    LogBox.Text += $"{LogMessageQueue.msgQueue.Dequeue()}{Environment.NewLine}";
                }
                await Task.Delay(200);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddNPC();
        }

        private void addFighterButton_Click(object sender, EventArgs e)
        {
            AddPC();
        }
    }
}
