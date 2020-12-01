using PF.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PF.Forms
{
    public partial class AddCharacter : Form
    {

        public Character Character { get; set; }
        public AddCharacter()
        {
            InitializeComponent();
        }

        public async Task<Character> BuildCharacter()
        {
            List<string> missingFields = new List<string>();
            Character newChar = new Character();
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                missingFields.Add("Name");
            }
            else
            {
                newChar.Name = txtName.Text;
            }

            int dex;
            if (string.IsNullOrWhiteSpace(txtDex.Text) || !Int32.TryParse(txtDex.Text, out dex))
            {
                missingFields.Add("Dexterity Score");
            }
            else
            {
                newChar.GetAbility("Dexterity").Base = dex;
            }

            int hp;
            if (string.IsNullOrEmpty(txtHP.Text) || !Int32.TryParse(txtHP.Text, out hp))
            {
                missingFields.Add("Hit Points");
            }
            else
            {
                newChar.HP = new API.CharacterDetail.HitPoints();
                newChar.HP.Max = hp;
                newChar.HP.Current = hp;
            }

            if (missingFields.Count > 0)
            {
                StringBuilder errorMessage = new StringBuilder("Cannot create character. The following fields were missing:\n");
                foreach(string s in missingFields)
                {
                    errorMessage.AppendLine($"\t{s}");
                }
                throw new MissingFieldException(errorMessage.ToString());
            }
            return newChar;
        }

        public async Task Add()
        {
            try
            {
                Character = await BuildCharacter();
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            await Add();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddCharacter_Load(object sender, EventArgs e)
        {
            txtName.Select();
        }
    }
}
