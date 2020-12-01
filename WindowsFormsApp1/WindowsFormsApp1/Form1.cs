using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private PartnerAssigner assigner;
        private Logger log;
        public Form1()
        {
            InitializeComponent();
            assigner = new PartnerAssigner();
            log = new Logger();
            log.LogBox = logBox;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void btnAddPeople_Click(object sender, EventArgs e)
        {
            await Add();
        }

        private async Task Add()
        {
            string name = txtName.Text;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty or blank.");
                return;
            }
            assigner.people.Add(new Person()
            {
                Name = name
            });
            CheckProceedButtonStatus();
            await log.Log($"Added: {name}");
            await DisplayNames();
            txtName.Clear();
        }

        private async Task DisplayNames()
        {
            lvwNames.Items.Clear();
            List<ListViewItem> names = new List<ListViewItem>();
            foreach(Person p in assigner.people)
            {
                ListViewItem item = new ListViewItem(p.Name);
                item.SubItems.Add(p.Assigned.ToString());
                await Task.Run(()=> names.Add(item));
            }
            lvwNames.Items.AddRange(names.ToArray());
        }

        private async void btnRemove_Click(object sender, EventArgs e)
        {
            await Remove();
        }

        private async Task Remove()
        {
            List<Person> removePeople = new List<Person>();
            foreach(ListViewItem selected in lvwNames.SelectedItems)
            {
                removePeople.Add(assigner.people.ElementAt(lvwNames.Items.IndexOf(selected)));
            }
            int removeCount = 0;
            foreach(Person person in removePeople)
            {
                await log.Log($"Removing: {person.Name}");
                await Task.Run(() => assigner.people.Remove(person));
                removeCount++;
            }
            CheckProceedButtonStatus();
            await log.Log($"Removed {removeCount} people.");
            await DisplayNames();
        }

        private void CheckProceedButtonStatus()
        {
            if (assigner.people.Count < 2)
            {
                btnAction.Enabled = false;
            }
            else
            {
                btnAction.Enabled = true;
            }
        }

        private void LockUnlockPersonButtons(bool value)
        {
            btnAddPeople.Enabled = value;
            btnRemove.Enabled = value;
        }

        private async void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await Add();
            }
        }

        private async void btnAction_Click(object sender, EventArgs e)
        {
            await Assign();
        }

        private async Task Assign()
        {
            LockUnlockPersonButtons(false);
            await assigner.AssignPartners();
            foreach(Person p in assigner.people)
            {
                await log.Log($"{p.Name} assigned to {p.Partner.Name}.");
            }
        }
    }
}
