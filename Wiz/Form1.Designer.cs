namespace WizEdit
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
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wizNesState1 = new WizEdit.WizNesState();
            this.wizCharList1 = new WizEdit.WizCharList();
            this.wizCharCaption1 = new WizEdit.WizCharCaption();
            this.wizGold = new WizEdit.WizParam();
            this.wizParam2 = new WizEdit.WizParam();
            this.wizParam3 = new WizEdit.WizParam();
            this.wizParam4 = new WizEdit.WizParam();
            this.wizParam5 = new WizEdit.WizParam();
            this.wizBonus2 = new WizEdit.WizBonus();
            this.wizHP1 = new WizEdit.WizHP();
            this.wizStatus1 = new WizEdit.WizStatus();
            this.wizMP1 = new WizEdit.WizMP();
            this.wizConrol1 = new WizEdit.WizBoxControl();
            this.wizConrol3 = new WizEdit.WizBoxControl();
            this.wizItemList1 = new WizEdit.WizItemList();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.wizValueEditor1 = new WizEdit.WizValueEditor();
            this.wizBoxControl1 = new WizEdit.WizBoxControl();
            this.myButton1 = new WizEdit.MyButton();
            this.myButton2 = new WizEdit.MyButton();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(719, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.aboutToolStripMenuItem.Text = "バージョン情報の表示";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // wizNesState1
            // 
            this.wizNesState1.CharAlg = WizEdit.WIZALG.GOOD;
            this.wizNesState1.CharClass = WizEdit.WIZCLASS.FIG;
            this.wizNesState1.CharCurrent = 0;
            this.wizNesState1.CharRace = WizEdit.WIZRACE.HUMAN;
            // 
            // wizCharList1
            // 
            this.wizCharList1.BackColor = System.Drawing.Color.Black;
            this.wizCharList1.BottomMargin = 5;
            this.wizCharList1.Corner = 5;
            this.wizCharList1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizCharList1.ForeColor = System.Drawing.Color.White;
            this.wizCharList1.IsActive = true;
            this.wizCharList1.LineHeight = 18;
            this.wizCharList1.LineWidth = 3;
            this.wizCharList1.ListBottomMgn = 5;
            this.wizCharList1.ListLeftMgn = 30;
            this.wizCharList1.ListRightMgn = 10;
            this.wizCharList1.ListTopMgn = 5;
            this.wizCharList1.Location = new System.Drawing.Point(37, 86);
            this.wizCharList1.Margin = new System.Windows.Forms.Padding(4);
            this.wizCharList1.MinimumSize = new System.Drawing.Size(0, 455);
            this.wizCharList1.Name = "wizCharList1";
            this.wizCharList1.SiseMargin = 5;
            this.wizCharList1.Size = new System.Drawing.Size(205, 455);
            this.wizCharList1.TabIndex = 13;
            this.wizCharList1.Text = "wizCharList1";
            this.wizCharList1.TopMargin = 5;
            this.wizCharList1.WizNesState = this.wizNesState1;
            // 
            // wizCharCaption1
            // 
            this.wizCharCaption1.BackColor = System.Drawing.Color.Black;
            this.wizCharCaption1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizCharCaption1.ForeColor = System.Drawing.Color.White;
            this.wizCharCaption1.IsDrawFrame = false;
            this.wizCharCaption1.Location = new System.Drawing.Point(267, 100);
            this.wizCharCaption1.Margin = new System.Windows.Forms.Padding(4);
            this.wizCharCaption1.MinimumSize = new System.Drawing.Size(375, 0);
            this.wizCharCaption1.Name = "wizCharCaption1";
            this.wizCharCaption1.Size = new System.Drawing.Size(404, 30);
            this.wizCharCaption1.TabIndex = 14;
            this.wizCharCaption1.Text = "wizCharCaption1";
            this.wizCharCaption1.WidthAlg = 40;
            this.wizCharCaption1.WidthClass = 40;
            this.wizCharCaption1.WidthLevel = 75;
            this.wizCharCaption1.WidthName = 170;
            this.wizCharCaption1.WidthRace = 50;
            this.wizCharCaption1.WizNesState = this.wizNesState1;
            // 
            // wizGold
            // 
            this.wizGold.BackColor = System.Drawing.Color.Black;
            this.wizGold.FarText = "0";
            this.wizGold.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizGold.ForeColor = System.Drawing.Color.White;
            this.wizGold.IsDrawFrame = false;
            this.wizGold.Location = new System.Drawing.Point(396, 137);
            this.wizGold.Mode = WizEdit.WizParamMode.Gold;
            this.wizGold.Name = "wizGold";
            this.wizGold.NearText = "GOLD";
            this.wizGold.Size = new System.Drawing.Size(244, 23);
            this.wizGold.TabIndex = 15;
            this.wizGold.Text = "wizParam1";
            this.wizGold.WizNesState = this.wizNesState1;
            // 
            // wizParam2
            // 
            this.wizParam2.BackColor = System.Drawing.Color.Black;
            this.wizParam2.FarText = "0";
            this.wizParam2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizParam2.ForeColor = System.Drawing.Color.White;
            this.wizParam2.IsDrawFrame = false;
            this.wizParam2.Location = new System.Drawing.Point(396, 166);
            this.wizParam2.Mode = WizEdit.WizParamMode.Exp;
            this.wizParam2.Name = "wizParam2";
            this.wizParam2.NearText = "E.P.";
            this.wizParam2.Size = new System.Drawing.Size(244, 23);
            this.wizParam2.TabIndex = 16;
            this.wizParam2.Text = "wizParam2";
            this.wizParam2.WizNesState = this.wizNesState1;
            // 
            // wizParam3
            // 
            this.wizParam3.BackColor = System.Drawing.Color.Black;
            this.wizParam3.FarText = "16";
            this.wizParam3.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizParam3.ForeColor = System.Drawing.Color.White;
            this.wizParam3.IsDrawFrame = false;
            this.wizParam3.Location = new System.Drawing.Point(396, 226);
            this.wizParam3.Mode = WizEdit.WizParamMode.Age;
            this.wizParam3.Name = "wizParam3";
            this.wizParam3.NearText = "AGE";
            this.wizParam3.Size = new System.Drawing.Size(84, 23);
            this.wizParam3.TabIndex = 17;
            this.wizParam3.Text = "wizParam3";
            this.wizParam3.WizNesState = this.wizNesState1;
            // 
            // wizParam4
            // 
            this.wizParam4.BackColor = System.Drawing.Color.Black;
            this.wizParam4.FarText = "24";
            this.wizParam4.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizParam4.ForeColor = System.Drawing.Color.White;
            this.wizParam4.IsDrawFrame = false;
            this.wizParam4.Location = new System.Drawing.Point(556, 226);
            this.wizParam4.Mode = WizEdit.WizParamMode.Week;
            this.wizParam4.Name = "wizParam4";
            this.wizParam4.NearText = "Week";
            this.wizParam4.Size = new System.Drawing.Size(84, 23);
            this.wizParam4.TabIndex = 18;
            this.wizParam4.Text = "wizParam4";
            this.wizParam4.WizNesState = this.wizNesState1;
            // 
            // wizParam5
            // 
            this.wizParam5.BackColor = System.Drawing.Color.Black;
            this.wizParam5.FarText = "4";
            this.wizParam5.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizParam5.ForeColor = System.Drawing.Color.White;
            this.wizParam5.IsDrawFrame = false;
            this.wizParam5.Location = new System.Drawing.Point(469, 255);
            this.wizParam5.Mode = WizEdit.WizParamMode.AC;
            this.wizParam5.Name = "wizParam5";
            this.wizParam5.NearText = "A.C.";
            this.wizParam5.Size = new System.Drawing.Size(113, 23);
            this.wizParam5.TabIndex = 19;
            this.wizParam5.Text = "wizParam5";
            this.wizParam5.WizNesState = this.wizNesState1;
            // 
            // wizBonus2
            // 
            this.wizBonus2.BackColor = System.Drawing.Color.Black;
            this.wizBonus2.CaptionWidth = 100;
            this.wizBonus2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizBonus2.ForeColor = System.Drawing.Color.White;
            this.wizBonus2.IsDrawFrame = false;
            this.wizBonus2.IsJapan = true;
            this.wizBonus2.LineHeight = 18;
            this.wizBonus2.Location = new System.Drawing.Point(270, 255);
            this.wizBonus2.MinimumSize = new System.Drawing.Size(150, 108);
            this.wizBonus2.Name = "wizBonus2";
            this.wizBonus2.Size = new System.Drawing.Size(193, 120);
            this.wizBonus2.TabIndex = 21;
            this.wizBonus2.Text = "wizBonus2";
            this.wizBonus2.ValueWidth = 50;
            this.wizBonus2.WizNesState = this.wizNesState1;
            // 
            // wizHP1
            // 
            this.wizHP1.BackColor = System.Drawing.Color.Black;
            this.wizHP1.CaptionWidth = 50;
            this.wizHP1.ForeColor = System.Drawing.Color.White;
            this.wizHP1.HPMaxWidth = 95;
            this.wizHP1.HPWidth = 100;
            this.wizHP1.IsDrawFrame = false;
            this.wizHP1.Location = new System.Drawing.Point(396, 195);
            this.wizHP1.MinimumSize = new System.Drawing.Size(245, 0);
            this.wizHP1.Name = "wizHP1";
            this.wizHP1.Size = new System.Drawing.Size(250, 25);
            this.wizHP1.TabIndex = 22;
            this.wizHP1.Text = "wizHP1";
            this.wizHP1.WizNesState = this.wizNesState1;
            // 
            // wizStatus1
            // 
            this.wizStatus1.CaptionWidth = 100;
            this.wizStatus1.IsDrawFrame = false;
            this.wizStatus1.IsJapan = true;
            this.wizStatus1.Location = new System.Drawing.Point(469, 284);
            this.wizStatus1.Name = "wizStatus1";
            this.wizStatus1.Size = new System.Drawing.Size(190, 24);
            this.wizStatus1.TabIndex = 23;
            this.wizStatus1.Text = "wizStatus1";
            this.wizStatus1.WizNesState = this.wizNesState1;
            // 
            // wizMP1
            // 
            this.wizMP1.BackColor = System.Drawing.Color.Black;
            this.wizMP1.ForeColor = System.Drawing.Color.White;
            this.wizMP1.IsDrawFrame = false;
            this.wizMP1.LineHeight = 25;
            this.wizMP1.Location = new System.Drawing.Point(469, 314);
            this.wizMP1.Name = "wizMP1";
            this.wizMP1.Size = new System.Drawing.Size(190, 60);
            this.wizMP1.TabIndex = 24;
            this.wizMP1.Text = "wizMP1";
            this.wizMP1.WizNesState = this.wizNesState1;
            // 
            // wizConrol1
            // 
            this.wizConrol1.BackColor = System.Drawing.Color.Black;
            this.wizConrol1.BottomMargin = 5;
            this.wizConrol1.Corner = 5;
            this.wizConrol1.ForeColor = System.Drawing.Color.White;
            this.wizConrol1.LineWidth = 3;
            this.wizConrol1.Location = new System.Drawing.Point(249, 86);
            this.wizConrol1.Name = "wizConrol1";
            this.wizConrol1.SiseMargin = 5;
            this.wizConrol1.Size = new System.Drawing.Size(436, 482);
            this.wizConrol1.TabIndex = 25;
            this.wizConrol1.Text = "wizConrol1";
            this.wizConrol1.TopMargin = 5;
            // 
            // wizConrol3
            // 
            this.wizConrol3.BackColor = System.Drawing.Color.Black;
            this.wizConrol3.BottomMargin = 5;
            this.wizConrol3.Corner = 3;
            this.wizConrol3.ForeColor = System.Drawing.Color.White;
            this.wizConrol3.LineWidth = 1;
            this.wizConrol3.Location = new System.Drawing.Point(270, 127);
            this.wizConrol3.Name = "wizConrol3";
            this.wizConrol3.SiseMargin = 5;
            this.wizConrol3.Size = new System.Drawing.Size(120, 120);
            this.wizConrol3.TabIndex = 27;
            this.wizConrol3.Text = "wizConrol3";
            this.wizConrol3.TopMargin = 5;
            // 
            // wizItemList1
            // 
            this.wizItemList1.BackColor = System.Drawing.Color.Black;
            this.wizItemList1.ForeColor = System.Drawing.Color.White;
            this.wizItemList1.IsDrawFrame = false;
            this.wizItemList1.LineHeight = 20;
            this.wizItemList1.Location = new System.Drawing.Point(274, 394);
            this.wizItemList1.MinimumSize = new System.Drawing.Size(0, 160);
            this.wizItemList1.Name = "wizItemList1";
            this.wizItemList1.Size = new System.Drawing.Size(189, 160);
            this.wizItemList1.TabIndex = 28;
            this.wizItemList1.Text = "wizItemList1";
            this.wizItemList1.WizNesState = this.wizNesState1;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listBox1.BackColor = System.Drawing.Color.Black;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.ForeColor = System.Drawing.Color.White;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(329, 458);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(95, 66);
            this.listBox1.TabIndex = 31;
            this.listBox1.Visible = false;
            // 
            // wizValueEditor1
            // 
            this.wizValueEditor1.BackColor = System.Drawing.Color.Black;
            this.wizValueEditor1.BottomMargin = 5;
            this.wizValueEditor1.Caption = "Untitled";
            this.wizValueEditor1.Corner = 5;
            this.wizValueEditor1.ForeColor = System.Drawing.Color.White;
            this.wizValueEditor1.LineWidth = 3;
            this.wizValueEditor1.Location = new System.Drawing.Point(14, 137);
            this.wizValueEditor1.MaximumSize = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.MinimumSize = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.Name = "wizValueEditor1";
            this.wizValueEditor1.SiseMargin = 5;
            this.wizValueEditor1.Size = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.TabIndex = 34;
            this.wizValueEditor1.Text = "wizValueEditor1";
            this.wizValueEditor1.TopMargin = 5;
            this.wizValueEditor1.Value = ((long)(0));
            this.wizValueEditor1.ValueMax = ((long)(281474976710655));
            this.wizValueEditor1.ValueMin = ((long)(0));
            this.wizValueEditor1.Visible = false;
            // 
            // wizBoxControl1
            // 
            this.wizBoxControl1.BackColor = System.Drawing.Color.Black;
            this.wizBoxControl1.BottomMargin = 5;
            this.wizBoxControl1.Corner = 5;
            this.wizBoxControl1.ForeColor = System.Drawing.Color.White;
            this.wizBoxControl1.LineWidth = 3;
            this.wizBoxControl1.Location = new System.Drawing.Point(469, 394);
            this.wizBoxControl1.Name = "wizBoxControl1";
            this.wizBoxControl1.SiseMargin = 5;
            this.wizBoxControl1.Size = new System.Drawing.Size(216, 174);
            this.wizBoxControl1.TabIndex = 35;
            this.wizBoxControl1.Text = "wizBoxControl1";
            this.wizBoxControl1.TopMargin = 5;
            // 
            // myButton1
            // 
            this.myButton1.BackColor = System.Drawing.Color.Black;
            this.myButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.myButton1.ForeColor = System.Drawing.Color.White;
            this.myButton1.Location = new System.Drawing.Point(54, 548);
            this.myButton1.Name = "myButton1";
            this.myButton1.Size = new System.Drawing.Size(30, 20);
            this.myButton1.TabIndex = 36;
            this.myButton1.Text = "UP";
            this.myButton1.UseVisualStyleBackColor = false;
            // 
            // myButton2
            // 
            this.myButton2.BackColor = System.Drawing.Color.Black;
            this.myButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.myButton2.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.myButton2.ForeColor = System.Drawing.Color.White;
            this.myButton2.Location = new System.Drawing.Point(90, 548);
            this.myButton2.Name = "myButton2";
            this.myButton2.Size = new System.Drawing.Size(43, 20);
            this.myButton2.TabIndex = 37;
            this.myButton2.Text = "DOWN";
            this.myButton2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Black;
            this.BottomMgn = 15;
            this.CaptionWidth = 320;
            this.ClientSize = new System.Drawing.Size(719, 591);
            this.Controls.Add(this.myButton2);
            this.Controls.Add(this.myButton1);
            this.Controls.Add(this.wizBoxControl1);
            this.Controls.Add(this.wizValueEditor1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.wizItemList1);
            this.Controls.Add(this.wizConrol3);
            this.Controls.Add(this.wizMP1);
            this.Controls.Add(this.wizStatus1);
            this.Controls.Add(this.wizHP1);
            this.Controls.Add(this.wizBonus2);
            this.Controls.Add(this.wizParam5);
            this.Controls.Add(this.wizParam4);
            this.Controls.Add(this.wizParam3);
            this.Controls.Add(this.wizParam2);
            this.Controls.Add(this.wizGold);
            this.Controls.Add(this.wizCharCaption1);
            this.Controls.Add(this.wizCharList1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.wizConrol1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.ListBox = this.listBox1;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(638, 606);
            this.Name = "Form1";
            this.Text = "{X=0,Y=0,Width=903,Height=523}";
            this.WizCharCaption = this.wizCharCaption1;
            this.WizCharList = this.wizCharList1;
            this.WizGold = this.wizGold;
            this.WizNesState = this.wizNesState1;
            this.WizValueEditor = this.wizValueEditor1;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private WizNesState wizNesState1;
        private WizCharList wizCharList1;
        private WizCharCaption wizCharCaption1;
        private WizParam wizGold;
        private WizParam wizParam2;
        private WizParam wizParam3;
        private WizParam wizParam4;
        private WizParam wizParam5;
        private WizBonus wizBonus2;
        private WizHP wizHP1;
        private WizStatus wizStatus1;
        private WizMP wizMP1;
        private WizBoxControl wizConrol1;
        private WizBoxControl wizConrol3;
        private WizItemList wizItemList1;
        private System.Windows.Forms.ListBox listBox1;
        private WizValueEditor wizValueEditor1;
        private WizBoxControl wizBoxControl1;
        private MyButton myButton1;
        private MyButton myButton2;
    }
}

