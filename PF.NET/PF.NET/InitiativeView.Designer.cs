
namespace PF.Forms
{
    partial class InitiativeView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnRoll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.activePage = new System.Windows.Forms.TabPage();
            this.activeList = new System.Windows.Forms.ListView();
            this.colInit = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colHP = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.inactiveList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.activePage.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(109, 451);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(75, 23);
            this.btnPrev.TabIndex = 8;
            this.btnPrev.Text = "Previous";
            this.btnPrev.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(190, 450);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(73, 25);
            this.btnNext.TabIndex = 7;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            // 
            // btnRoll
            // 
            this.btnRoll.Location = new System.Drawing.Point(7, 439);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(73, 47);
            this.btnRoll.TabIndex = 6;
            this.btnRoll.Text = "Roll Initiative";
            this.btnRoll.UseVisualStyleBackColor = true;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 422);
            this.panel1.TabIndex = 10;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.activePage);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(480, 422);
            this.tabControl.TabIndex = 1;
            // 
            // activePage
            // 
            this.activePage.Controls.Add(this.activeList);
            this.activePage.Location = new System.Drawing.Point(4, 24);
            this.activePage.Name = "activePage";
            this.activePage.Padding = new System.Windows.Forms.Padding(3);
            this.activePage.Size = new System.Drawing.Size(472, 394);
            this.activePage.TabIndex = 0;
            this.activePage.Text = "Active";
            this.activePage.UseVisualStyleBackColor = true;
            // 
            // activeList
            // 
            this.activeList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInit,
            this.colName,
            this.colHP});
            this.activeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.activeList.FullRowSelect = true;
            this.activeList.HideSelection = false;
            this.activeList.Location = new System.Drawing.Point(3, 3);
            this.activeList.Name = "activeList";
            this.activeList.Size = new System.Drawing.Size(466, 388);
            this.activeList.TabIndex = 1;
            this.activeList.UseCompatibleStateImageBehavior = false;
            this.activeList.View = System.Windows.Forms.View.Details;
            // 
            // colInit
            // 
            this.colInit.Name = "colInit";
            this.colInit.Text = "Initiative";
            // 
            // colName
            // 
            this.colName.Name = "colName";
            this.colName.Text = "Name";
            // 
            // colHP
            // 
            this.colHP.Name = "colHP";
            this.colHP.Text = "HP";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.inactiveList);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(472, 394);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Inactive";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // inactiveList
            // 
            this.inactiveList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.inactiveList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inactiveList.FullRowSelect = true;
            this.inactiveList.HideSelection = false;
            this.inactiveList.Location = new System.Drawing.Point(3, 3);
            this.inactiveList.Name = "inactiveList";
            this.inactiveList.Size = new System.Drawing.Size(466, 388);
            this.inactiveList.TabIndex = 2;
            this.inactiveList.UseCompatibleStateImageBehavior = false;
            this.inactiveList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Name = "colInit";
            this.columnHeader1.Text = "Initiative";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Name = "colName";
            this.columnHeader2.Text = "Name";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Name = "colHP";
            this.columnHeader3.Text = "HP";
            // 
            // InitiativeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnRoll);
            this.Name = "InitiativeView";
            this.Size = new System.Drawing.Size(494, 497);
            this.Load += new System.EventHandler(this.InitiativeView_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.activePage.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage activePage;
        private System.Windows.Forms.ListView activeList;
        private System.Windows.Forms.ColumnHeader colInit;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colHP;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListView inactiveList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}
