namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwNames = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colAssigned = new System.Windows.Forms.ColumnHeader();
            this.btnAddPeople = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAction = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.logBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // lvwNames
            // 
            this.lvwNames.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAssigned});
            this.lvwNames.FullRowSelect = true;
            this.lvwNames.HideSelection = false;
            this.lvwNames.Location = new System.Drawing.Point(12, 12);
            this.lvwNames.Name = "lvwNames";
            this.lvwNames.Size = new System.Drawing.Size(271, 337);
            this.lvwNames.TabIndex = 0;
            this.lvwNames.UseCompatibleStateImageBehavior = false;
            this.lvwNames.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 205;
            // 
            // colAssigned
            // 
            this.colAssigned.Text = "Assigned";
            // 
            // btnAddPeople
            // 
            this.btnAddPeople.Location = new System.Drawing.Point(391, 42);
            this.btnAddPeople.Name = "btnAddPeople";
            this.btnAddPeople.Size = new System.Drawing.Size(105, 23);
            this.btnAddPeople.TabIndex = 1;
            this.btnAddPeople.Text = "Add Person";
            this.btnAddPeople.UseVisualStyleBackColor = true;
            this.btnAddPeople.Click += new System.EventHandler(this.btnAddPeople_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 355);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(90, 23);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAction
            // 
            this.btnAction.Enabled = false;
            this.btnAction.Location = new System.Drawing.Point(367, 355);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(129, 41);
            this.btnAction.TabIndex = 2;
            this.btnAction.Text = "Assign Partners";
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(289, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(331, 13);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 23);
            this.txtName.TabIndex = 4;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(289, 85);
            this.logBox.Name = "logBox";
            this.logBox.ReadOnly = true;
            this.logBox.Size = new System.Drawing.Size(280, 264);
            this.logBox.TabIndex = 5;
            this.logBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 410);
            this.Controls.Add(this.logBox);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAddPeople);
            this.Controls.Add(this.lvwNames);
            this.Name = "Form1";
            this.Text = "Secret Santa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwNames;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAssigned;
        private System.Windows.Forms.Button btnAddPeople;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.RichTextBox logBox;
    }
}

