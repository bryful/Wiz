namespace WizFCEdit
{
    partial class WizSpellEditDialogcs
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.wizSpellList1 = new WizFCEdit.WizSpellList();
            this.btnOK = new WizFCEdit.WizButton();
            this.btnCancel = new WizFCEdit.WizButton();
            this.btnGetAll = new WizFCEdit.WizButton();
            this.btnForgetAll = new WizFCEdit.WizButton();
            this.SuspendLayout();
            // 
            // wizSpellList1
            // 
            this.wizSpellList1.BackColor = System.Drawing.Color.Black;
            this.wizSpellList1.BottomMargin = 5;
            this.wizSpellList1.Corner = 5;
            this.wizSpellList1.Font = new System.Drawing.Font("MS UI Gothic", 12F);
            this.wizSpellList1.ForeColor = System.Drawing.Color.White;
            this.wizSpellList1.LeftMgn = 30;
            this.wizSpellList1.LineHeight = 24;
            this.wizSpellList1.LineWidth = 3;
            this.wizSpellList1.Location = new System.Drawing.Point(12, 12);
            this.wizSpellList1.Name = "wizSpellList1";
            this.wizSpellList1.SCN = WizFCEdit.WIZ_SCN.S1;
            this.wizSpellList1.SideMargin = 5;
            this.wizSpellList1.Size = new System.Drawing.Size(700, 295);
            this.wizSpellList1.Spell = new byte[] {
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0))};
            this.wizSpellList1.SpellWidth = 100;
            this.wizSpellList1.TabIndex = 0;
            this.wizSpellList1.Text = "wizSpellList1";
            this.wizSpellList1.TopMargin = 5;
            this.wizSpellList1.TopMgn = 40;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Black;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(547, 337);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(130, 40);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(411, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 40);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnGetAll
            // 
            this.btnGetAll.BackColor = System.Drawing.Color.Black;
            this.btnGetAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAll.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnGetAll.ForeColor = System.Drawing.Color.White;
            this.btnGetAll.Location = new System.Drawing.Point(22, 322);
            this.btnGetAll.Name = "btnGetAll";
            this.btnGetAll.Size = new System.Drawing.Size(83, 29);
            this.btnGetAll.TabIndex = 3;
            this.btnGetAll.Text = "すべて覚える";
            this.btnGetAll.UseVisualStyleBackColor = false;
            this.btnGetAll.Click += new System.EventHandler(this.btnGetAll_Click);
            // 
            // btnForgetAll
            // 
            this.btnForgetAll.BackColor = System.Drawing.Color.Black;
            this.btnForgetAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForgetAll.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnForgetAll.ForeColor = System.Drawing.Color.White;
            this.btnForgetAll.Location = new System.Drawing.Point(111, 322);
            this.btnForgetAll.Name = "btnForgetAll";
            this.btnForgetAll.Size = new System.Drawing.Size(83, 29);
            this.btnForgetAll.TabIndex = 4;
            this.btnForgetAll.Text = "すべて忘れる";
            this.btnForgetAll.UseVisualStyleBackColor = false;
            this.btnForgetAll.Click += new System.EventHandler(this.btnForgetAll_Click);
            // 
            // WizSpellEditDialogcs
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(725, 407);
            this.Controls.Add(this.btnForgetAll);
            this.Controls.Add(this.btnGetAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.wizSpellList1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizSpellEditDialogcs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "WizSpellEditDialogcs";
            this.ResumeLayout(false);

        }

        #endregion

        private WizSpellList wizSpellList1;
        private WizButton btnOK;
        private WizButton btnCancel;
        private WizButton btnGetAll;
        private WizButton btnForgetAll;
    }
}