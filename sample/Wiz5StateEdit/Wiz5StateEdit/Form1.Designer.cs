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
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chrMPCount1 = new Wiz5StateEdit.ChrMPCount();
            this.snes9xWizFive1 = new Wiz5StateEdit.Snes9xWizFive();
            this.chrHP1 = new Wiz5StateEdit.ChrHP();
            this.chrItemList1 = new Wiz5StateEdit.ChrItemList();
            this.chrStatus1 = new Wiz5StateEdit.ChrStatus();
            this.chrParam14 = new Wiz5StateEdit.ChrParam();
            this.chrParam13 = new Wiz5StateEdit.ChrParam();
            this.chrParam12 = new Wiz5StateEdit.ChrParam();
            this.chrParam11 = new Wiz5StateEdit.ChrParam();
            this.chrParam10 = new Wiz5StateEdit.ChrParam();
            this.chrParam9 = new Wiz5StateEdit.ChrParam();
            this.chrParam8 = new Wiz5StateEdit.ChrParam();
            this.chrParam7 = new Wiz5StateEdit.ChrParam();
            this.chrParam6 = new Wiz5StateEdit.ChrParam();
            this.chrParam5 = new Wiz5StateEdit.ChrParam();
            this.chrParam4 = new Wiz5StateEdit.ChrParam();
            this.chrParam3 = new Wiz5StateEdit.ChrParam();
            this.chrParam2 = new Wiz5StateEdit.ChrParam();
            this.chrRace1 = new Wiz5StateEdit.ChrRace();
            this.chrParam1 = new Wiz5StateEdit.ChrParam();
            this.shopList1 = new Wiz5StateEdit.ShopList();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(593, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // chrMPCount1
            // 
            this.chrMPCount1.BackColor = System.Drawing.Color.Black;
            this.chrMPCount1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrMPCount1.Location = new System.Drawing.Point(411, 315);
            this.chrMPCount1.MaximumSize = new System.Drawing.Size(170, 80);
            this.chrMPCount1.MinimumSize = new System.Drawing.Size(170, 80);
            this.chrMPCount1.Name = "chrMPCount1";
            this.chrMPCount1.Size = new System.Drawing.Size(170, 80);
            this.chrMPCount1.TabIndex = 23;
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
            this.snes9xWizFive1.Location = new System.Drawing.Point(12, 43);
            this.snes9xWizFive1.Name = "snes9xWizFive1";
            this.snes9xWizFive1.Size = new System.Drawing.Size(228, 276);
            this.snes9xWizFive1.TabIndex = 0;
            // 
            // chrHP1
            // 
            this.chrHP1.BackColor = System.Drawing.Color.Black;
            this.chrHP1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrHP1.ForeColor = System.Drawing.Color.White;
            this.chrHP1.Location = new System.Drawing.Point(259, 127);
            this.chrHP1.MaximumSize = new System.Drawing.Size(900, 50);
            this.chrHP1.MinimumSize = new System.Drawing.Size(100, 50);
            this.chrHP1.Name = "chrHP1";
            this.chrHP1.Size = new System.Drawing.Size(180, 50);
            this.chrHP1.TabIndex = 22;
            this.chrHP1.Text = "chrHP1";
            this.chrHP1.WizFive = this.snes9xWizFive1;
            // 
            // chrItemList1
            // 
            this.chrItemList1.BackColor = System.Drawing.Color.Black;
            this.chrItemList1.ForeColor = System.Drawing.Color.White;
            this.chrItemList1.Location = new System.Drawing.Point(12, 325);
            this.chrItemList1.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.chrItemList1.MinimumSize = new System.Drawing.Size(195, 50);
            this.chrItemList1.Name = "chrItemList1";
            this.chrItemList1.Size = new System.Drawing.Size(228, 175);
            this.chrItemList1.TabIndex = 19;
            this.chrItemList1.Text = "chrItemList1";
            this.chrItemList1.WizFive = this.snes9xWizFive1;
            // 
            // chrStatus1
            // 
            this.chrStatus1.BackColor = System.Drawing.Color.Black;
            this.chrStatus1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrStatus1.Location = new System.Drawing.Point(462, 127);
            this.chrStatus1.MaximumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.MinimumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.Name = "chrStatus1";
            this.chrStatus1.Size = new System.Drawing.Size(110, 24);
            this.chrStatus1.TabIndex = 17;
            this.chrStatus1.Text = "chrStatus1";
            this.chrStatus1.WizFive = this.snes9xWizFive1;
            // 
            // chrParam14
            // 
            this.chrParam14.CaptionWidth = 75;
            this.chrParam14.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam14.Location = new System.Drawing.Point(259, 465);
            this.chrParam14.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam14.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam14.Mode = Wiz5StateEdit.ChrParam.MODE.UN;
            this.chrParam14.Name = "chrParam14";
            this.chrParam14.Size = new System.Drawing.Size(130, 24);
            this.chrParam14.TabIndex = 16;
            this.chrParam14.Text = "chrParam14";
            this.chrParam14.TextLeft = false;
            this.chrParam14.WizFive = this.snes9xWizFive1;
            // 
            // chrParam13
            // 
            this.chrParam13.CaptionWidth = 75;
            this.chrParam13.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam13.Location = new System.Drawing.Point(259, 435);
            this.chrParam13.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam13.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam13.Mode = Wiz5StateEdit.ChrParam.MODE.SUBAYASA;
            this.chrParam13.Name = "chrParam13";
            this.chrParam13.Size = new System.Drawing.Size(130, 24);
            this.chrParam13.TabIndex = 15;
            this.chrParam13.Text = "chrParam13";
            this.chrParam13.TextLeft = false;
            this.chrParam13.WizFive = this.snes9xWizFive1;
            // 
            // chrParam12
            // 
            this.chrParam12.CaptionWidth = 75;
            this.chrParam12.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam12.Location = new System.Drawing.Point(259, 405);
            this.chrParam12.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam12.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam12.Mode = Wiz5StateEdit.ChrParam.MODE.SEIMEI;
            this.chrParam12.Name = "chrParam12";
            this.chrParam12.Size = new System.Drawing.Size(130, 24);
            this.chrParam12.TabIndex = 14;
            this.chrParam12.Text = "chrParam12";
            this.chrParam12.TextLeft = false;
            this.chrParam12.WizFive = this.snes9xWizFive1;
            // 
            // chrParam11
            // 
            this.chrParam11.CaptionWidth = 75;
            this.chrParam11.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam11.Location = new System.Drawing.Point(259, 375);
            this.chrParam11.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam11.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam11.Mode = Wiz5StateEdit.ChrParam.MODE.SINKOSIN;
            this.chrParam11.Name = "chrParam11";
            this.chrParam11.Size = new System.Drawing.Size(130, 24);
            this.chrParam11.TabIndex = 13;
            this.chrParam11.Text = "chrParam11";
            this.chrParam11.TextLeft = false;
            this.chrParam11.WizFive = this.snes9xWizFive1;
            // 
            // chrParam10
            // 
            this.chrParam10.CaptionWidth = 75;
            this.chrParam10.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam10.Location = new System.Drawing.Point(259, 345);
            this.chrParam10.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam10.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam10.Mode = Wiz5StateEdit.ChrParam.MODE.CHIE;
            this.chrParam10.Name = "chrParam10";
            this.chrParam10.Size = new System.Drawing.Size(130, 24);
            this.chrParam10.TabIndex = 12;
            this.chrParam10.Text = "chrParam10";
            this.chrParam10.TextLeft = false;
            this.chrParam10.WizFive = this.snes9xWizFive1;
            // 
            // chrParam9
            // 
            this.chrParam9.CaptionWidth = 75;
            this.chrParam9.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam9.Location = new System.Drawing.Point(259, 315);
            this.chrParam9.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam9.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam9.Mode = Wiz5StateEdit.ChrParam.MODE.CHIKARA;
            this.chrParam9.Name = "chrParam9";
            this.chrParam9.Size = new System.Drawing.Size(130, 24);
            this.chrParam9.TabIndex = 11;
            this.chrParam9.Text = "chrParam9";
            this.chrParam9.TextLeft = false;
            this.chrParam9.WizFive = this.snes9xWizFive1;
            // 
            // chrParam8
            // 
            this.chrParam8.CaptionWidth = 50;
            this.chrParam8.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam8.Location = new System.Drawing.Point(478, 282);
            this.chrParam8.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam8.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam8.Mode = Wiz5StateEdit.ChrParam.MODE.RIP;
            this.chrParam8.Name = "chrParam8";
            this.chrParam8.Size = new System.Drawing.Size(94, 24);
            this.chrParam8.TabIndex = 9;
            this.chrParam8.Text = "chrParam8";
            this.chrParam8.TextLeft = true;
            this.chrParam8.WizFive = this.snes9xWizFive1;
            // 
            // chrParam7
            // 
            this.chrParam7.CaptionWidth = 50;
            this.chrParam7.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam7.Location = new System.Drawing.Point(478, 252);
            this.chrParam7.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam7.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam7.Mode = Wiz5StateEdit.ChrParam.MODE.SWIM;
            this.chrParam7.Name = "chrParam7";
            this.chrParam7.Size = new System.Drawing.Size(94, 24);
            this.chrParam7.TabIndex = 8;
            this.chrParam7.Text = "chrParam7";
            this.chrParam7.TextLeft = true;
            this.chrParam7.WizFive = this.snes9xWizFive1;
            // 
            // chrParam6
            // 
            this.chrParam6.CaptionWidth = 50;
            this.chrParam6.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam6.Location = new System.Drawing.Point(478, 222);
            this.chrParam6.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam6.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam6.Mode = Wiz5StateEdit.ChrParam.MODE.AC;
            this.chrParam6.Name = "chrParam6";
            this.chrParam6.Size = new System.Drawing.Size(94, 24);
            this.chrParam6.TabIndex = 7;
            this.chrParam6.Text = "chrParam6";
            this.chrParam6.TextLeft = true;
            this.chrParam6.WizFive = this.snes9xWizFive1;
            // 
            // chrParam5
            // 
            this.chrParam5.CaptionWidth = 50;
            this.chrParam5.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam5.Location = new System.Drawing.Point(478, 192);
            this.chrParam5.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam5.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam5.Mode = Wiz5StateEdit.ChrParam.MODE.NENEI;
            this.chrParam5.Name = "chrParam5";
            this.chrParam5.Size = new System.Drawing.Size(94, 24);
            this.chrParam5.TabIndex = 6;
            this.chrParam5.Text = "chrParam5";
            this.chrParam5.TextLeft = true;
            this.chrParam5.WizFive = this.snes9xWizFive1;
            // 
            // chrParam4
            // 
            this.chrParam4.CaptionWidth = 80;
            this.chrParam4.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam4.Location = new System.Drawing.Point(259, 252);
            this.chrParam4.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam4.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam4.Mode = Wiz5StateEdit.ChrParam.MODE.MARKS;
            this.chrParam4.Name = "chrParam4";
            this.chrParam4.Size = new System.Drawing.Size(202, 24);
            this.chrParam4.TabIndex = 5;
            this.chrParam4.Text = "chrParam4";
            this.chrParam4.TextLeft = true;
            this.chrParam4.WizFive = this.snes9xWizFive1;
            // 
            // chrParam3
            // 
            this.chrParam3.CaptionWidth = 80;
            this.chrParam3.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam3.Location = new System.Drawing.Point(259, 222);
            this.chrParam3.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam3.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam3.Mode = Wiz5StateEdit.ChrParam.MODE.GOLD;
            this.chrParam3.Name = "chrParam3";
            this.chrParam3.Size = new System.Drawing.Size(202, 24);
            this.chrParam3.TabIndex = 4;
            this.chrParam3.Text = "chrParam3";
            this.chrParam3.TextLeft = true;
            this.chrParam3.WizFive = this.snes9xWizFive1;
            // 
            // chrParam2
            // 
            this.chrParam2.CaptionWidth = 80;
            this.chrParam2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam2.Location = new System.Drawing.Point(259, 192);
            this.chrParam2.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam2.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam2.Mode = Wiz5StateEdit.ChrParam.MODE.EP;
            this.chrParam2.Name = "chrParam2";
            this.chrParam2.Size = new System.Drawing.Size(202, 24);
            this.chrParam2.TabIndex = 3;
            this.chrParam2.Text = "chrParam2";
            this.chrParam2.TextLeft = true;
            this.chrParam2.WizFive = this.snes9xWizFive1;
            // 
            // chrRace1
            // 
            this.chrRace1.BackColor = System.Drawing.Color.Black;
            this.chrRace1.Enabled = false;
            this.chrRace1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrRace1.Location = new System.Drawing.Point(352, 83);
            this.chrRace1.MaximumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.MinimumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.Name = "chrRace1";
            this.chrRace1.Size = new System.Drawing.Size(220, 24);
            this.chrRace1.TabIndex = 2;
            this.chrRace1.Text = "chrRace1";
            this.chrRace1.WizFive = this.snes9xWizFive1;
            // 
            // chrParam1
            // 
            this.chrParam1.CaptionWidth = 80;
            this.chrParam1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam1.Location = new System.Drawing.Point(259, 53);
            this.chrParam1.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam1.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam1.Mode = Wiz5StateEdit.ChrParam.MODE.LV;
            this.chrParam1.Name = "chrParam1";
            this.chrParam1.Size = new System.Drawing.Size(313, 24);
            this.chrParam1.TabIndex = 1;
            this.chrParam1.Text = "chrParam1";
            this.chrParam1.TextLeft = true;
            this.chrParam1.WizFive = this.snes9xWizFive1;
            // 
            // shopList1
            // 
            this.shopList1.BackColor = System.Drawing.Color.Black;
            this.shopList1.ForeColor = System.Drawing.Color.White;
            this.shopList1.FormattingEnabled = true;
            this.shopList1.ItemHeight = 12;
            this.shopList1.Location = new System.Drawing.Point(411, 401);
            this.shopList1.Name = "shopList1";
            this.shopList1.Size = new System.Drawing.Size(161, 88);
            this.shopList1.TabIndex = 24;
            this.shopList1.WizFive = this.snes9xWizFive1;
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(593, 505);
            this.Controls.Add(this.shopList1);
            this.Controls.Add(this.chrMPCount1);
            this.Controls.Add(this.chrHP1);
            this.Controls.Add(this.chrItemList1);
            this.Controls.Add(this.chrStatus1);
            this.Controls.Add(this.chrParam14);
            this.Controls.Add(this.chrParam13);
            this.Controls.Add(this.chrParam12);
            this.Controls.Add(this.chrParam11);
            this.Controls.Add(this.chrParam10);
            this.Controls.Add(this.chrParam9);
            this.Controls.Add(this.chrParam8);
            this.Controls.Add(this.chrParam7);
            this.Controls.Add(this.chrParam6);
            this.Controls.Add(this.chrParam5);
            this.Controls.Add(this.chrParam4);
            this.Controls.Add(this.chrParam3);
            this.Controls.Add(this.chrParam2);
            this.Controls.Add(this.chrRace1);
            this.Controls.Add(this.chrParam1);
            this.Controls.Add(this.snes9xWizFive1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ウィザードリィⅤ 災禍の中心 Snes9x State Data Editor";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Snes9xWizFive snes9xWizFive1;
        private ChrParam chrParam1;
        private ChrRace chrRace1;
        private ChrParam chrParam2;
        private ChrParam chrParam3;
        private ChrParam chrParam4;
        private ChrParam chrParam5;
        private ChrParam chrParam6;
        private ChrParam chrParam7;
        private ChrParam chrParam8;
        private ChrParam chrParam9;
        private ChrParam chrParam10;
        private ChrParam chrParam11;
        private ChrParam chrParam12;
        private ChrParam chrParam13;
        private ChrParam chrParam14;
        private ChrStatus chrStatus1;
        private ChrItemList chrItemList1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private ChrHP chrHP1;
        private ChrMPCount chrMPCount1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private ShopList shopList1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    }
}

