namespace WizFCEdit
{
    partial class WizSpellEdit
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
            this.wizButton1 = new WizFCEdit.WizButton();
            this.SuspendLayout();
            // 
            // wizSpellList1
            // 
            this.wizSpellList1.BackColor = System.Drawing.Color.Black;
            this.wizSpellList1.BottomMargin = 5;
            this.wizSpellList1.Corner = 5;
            this.wizSpellList1.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.wizSpellList1.ForeColor = System.Drawing.Color.White;
            this.wizSpellList1.LeftMgn = 30;
            this.wizSpellList1.LineHeight = 20;
            this.wizSpellList1.LineWidth = 3;
            this.wizSpellList1.Location = new System.Drawing.Point(12, 12);
            this.wizSpellList1.MaximumSize = new System.Drawing.Size(570, 250);
            this.wizSpellList1.MinimumSize = new System.Drawing.Size(570, 250);
            this.wizSpellList1.Name = "wizSpellList1";
            this.wizSpellList1.SideMargin = 5;
            this.wizSpellList1.Size = new System.Drawing.Size(570, 250);
            this.wizSpellList1.SpellWidth = 75;
            this.wizSpellList1.TabIndex = 0;
            this.wizSpellList1.Text = "wizSpellList1";
            this.wizSpellList1.TopMargin = 5;
            this.wizSpellList1.TopMgn = 40;
            this.wizSpellList1.WizNesState = null;
            // 
            // wizButton1
            // 
            this.wizButton1.BackColor = System.Drawing.Color.Black;
            this.wizButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wizButton1.ForeColor = System.Drawing.Color.White;
            this.wizButton1.Location = new System.Drawing.Point(475, 283);
            this.wizButton1.Name = "wizButton1";
            this.wizButton1.Size = new System.Drawing.Size(75, 23);
            this.wizButton1.TabIndex = 1;
            this.wizButton1.Text = "wizButton1";
            this.wizButton1.UseVisualStyleBackColor = false;
            // 
            // WizSpellEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(601, 342);
            this.Controls.Add(this.wizButton1);
            this.Controls.Add(this.wizSpellList1);
            this.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizSpellEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "WizSpellEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private WizSpellList wizSpellList1;
        private WizButton wizButton1;
    }
}