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
            await Task.Delay(5000);
            splashScreen.Close();
            this.Visible = true;
            this.WindowState = FormWindowState.Maximized;
        }

        public async Task UpdateFighterList()
        {
            List<Task> taskList = new List<Task>();
            taskList.Add(Task.Run(() => FillFighters(InitOrderView, encounter.combatants)));
            taskList.Add(Task.Run(() => FillFighters(lvwDying, encounter.dyingCombatants)));
            taskList.Add(Task.Run(() => FillFighters(lvwDead, encounter.deadCombatants)));
            await Task.WhenAll(taskList.ToArray());
        }

        private void FillFighters(ListView listView, List<Fighter> fighters)
        {
            listView.Items.Clear();
            int order = 1;
            List<ListViewItem> addItems = new List<ListViewItem>();
            foreach (Fighter f in encounter.combatants)
            {
                ListViewItem item = new ListViewItem(order.ToString());
                item.SubItems.Add(f.Name);
                item.SubItems.Add(f.Initiative.ToString());
                item.SubItems.Add(f.HP.ToString());
                item.SubItems.Add(f.HoldAction ? "Yes" : "No");
                addItems.Add(item);
                order++;
            }
        }

        public void AddPC()
        {

        }

        private void addFighterButton_Click(object sender, EventArgs e)
        {

        }
    }
}
