namespace Wiz5StateEdit
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chrItemList1 = new Wiz5StateEdit.ChrItemList();
            this.chrMPCount1 = new Wiz5StateEdit.ChrMPCount();
            this.snes9xWizFive1 = new Wiz5StateEdit.Snes9xWizFive();
            this.chrRace1 = new Wiz5StateEdit.ChrRace();
            this.chrStatus1 = new Wiz5StateEdit.ChrStatus();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(718, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // chrItemList1
            // 
            this.chrItemList1.BackColor = System.Drawing.Color.Black;
            this.chrItemList1.ForeColor = System.Drawing.Color.White;
            this.chrItemList1.Location = new System.Drawing.Point(12, 326);
            this.chrItemList1.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.chrItemList1.MinimumSize = new System.Drawing.Size(195, 50);
            this.chrItemList1.Name = "chrItemList1";
            this.chrItemList1.Size = new System.Drawing.Size(236, 175);
            this.chrItemList1.TabIndex = 4;
            this.chrItemList1.Text = "chrItemList1";
            this.chrItemList1.WizFive = this.snes9xWizFive1;
            // 
            // chrMPCount1
            // 
            this.chrMPCount1.BackColor = System.Drawing.Color.Black;
            this.chrMPCount1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrMPCount1.Location = new System.Drawing.Point(465, 137);
            this.chrMPCount1.MaximumSize = new System.Drawing.Size(170, 40);
            this.chrMPCount1.MinimumSize = new System.Drawing.Size(170, 40);
            this.chrMPCount1.Name = "chrMPCount1";
            this.chrMPCount1.Size = new System.Drawing.Size(170, 40);
            this.chrMPCount1.TabIndex = 3;
            this.chrMPCount1.Text = "chrMPCount1";
            this.chrMPCount1.WizFive = this.snes9xWizFive1;
            // 
            // snes9xWizFive1
            // 
            this.snes9xWizFive1.BackColor = System.Drawing.Color.Black;
            this.snes9xWizFive1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.snes9xWizFive1.ForeColor = System.Drawing.Color.White;
            this.snes9xWizFive1.FormattingEnabled = true;
            this.snes9xWizFive1.ItemHeight = 16;
            this.snes9xWizFive1.Location = new System.Drawing.Point(12, 44);
            this.snes9xWizFive1.Name = "snes9xWizFive1";
            this.snes9xWizFive1.Size = new System.Drawing.Size(236, 276);
            this.snes9xWizFive1.TabIndex = 0;
            // 
            // chrRace1
            // 
            this.chrRace1.BackColor = System.Drawing.Color.Black;
            this.chrRace1.Enabled = false;
            this.chrRace1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrRace1.Location = new System.Drawing.Point(415, 44);
            this.chrRace1.MaximumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.MinimumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.Name = "chrRace1";
            this.chrRace1.Size = new System.Drawing.Size(220, 24);
            this.chrRace1.TabIndex = 2;
            this.chrRace1.Text = "chrRace1";
            this.chrRace1.WizFive = this.snes9xWizFive1;
            // 
            // chrStatus1
            // 
            this.chrStatus1.BackColor = System.Drawing.Color.Black;
            this.chrStatus1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrStatus1.Location = new System.Drawing.Point(548, 89);
            this.chrStatus1.MaximumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.MinimumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.Name = "chrStatus1";
            this.chrStatus1.Size = new System.Drawing.Size(110, 24);
            this.chrStatus1.TabIndex = 1;
            this.chrStatus1.Text = "chrStatus1";
            this.chrStatus1.WizFive = this.snes9xWizFive1;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(718, 533);
            this.Controls.Add(this.chrItemList1);
            this.Controls.Add(this.chrMPCount1);
            this.Controls.Add(this.chrRace1);
            this.Controls.Add(this.chrStatus1);
            this.Controls.Add(this.snes9xWizFive1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private Snes9xWizFive snes9xWizFive1;
        private ChrStatus chrStatus1;
        private ChrRace chrRace1;
        private ChrMPCount chrMPCount1;
        private ChrItemList chrItemList1;
    }
}

