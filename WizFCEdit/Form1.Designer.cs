namespace WizFCEdit
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
            this.wizNesState1 = new WizFCEdit.WizFCState();
            this.wizCharList1 = new WizFCEdit.WizCharList();
            this.wizCharCaption1 = new WizFCEdit.WizCharCaption();
            this.wizGold = new WizFCEdit.WizParam();
            this.wizEP = new WizFCEdit.WizParam();
            this.wizAge = new WizFCEdit.WizParam();
            this.wizWeek = new WizFCEdit.WizParam();
            this.wizAC = new WizFCEdit.WizParam();
            this.wizBonus1 = new WizFCEdit.WizBonus();
            this.wizHP1 = new WizFCEdit.WizHP();
            this.wizStatus1 = new WizFCEdit.WizStatus();
            this.wizMP1 = new WizFCEdit.WizMP();
            this.wizConrol1 = new WizFCEdit.WizBoxControl();
            this.wizItemList1 = new WizFCEdit.WizItemList();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnUp = new WizFCEdit.WizButton();
            this.btnDown = new WizFCEdit.WizButton();
            this.wizValueEditor1 = new WizFCEdit.WizValueEditor();
            this.wizSpellList1 = new WizFCEdit.WizSpellList();
            this.btnSetting = new WizFCEdit.WizButton();
            this.wizPictureBox1 = new WizFCEdit.WizPictureBox();
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
            this.wizNesState1.CharAC = ((sbyte)(4));
            this.wizNesState1.CharAge = ((sbyte)(16));
            this.wizNesState1.CharAgility = 8;
            this.wizNesState1.CharAlg = WizFCEdit.WIZALG.GOOD;
            this.wizNesState1.CharClass = WizFCEdit.WIZCLASS.FIG;
            this.wizNesState1.CharCurrent = 0;
            this.wizNesState1.CharExp = ((long)(0));
            this.wizNesState1.CharGold = ((long)(0));
            this.wizNesState1.CharHP = 8;
            this.wizNesState1.CharHPMax = 8;
            this.wizNesState1.CharIQ = 8;
            this.wizNesState1.CharLevel = 1;
            this.wizNesState1.CharLuck = 9;
            this.wizNesState1.CharPiety = 7;
            this.wizNesState1.CharRace = WizFCEdit.WIZRACE.HUMAN;
            this.wizNesState1.CharSpell = new byte[] {
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0))};
            this.wizNesState1.CharStatus = WizFCEdit.WIZSTATUS.OK;
            this.wizNesState1.CharStrength = 11;
            this.wizNesState1.CharVitarity = 8;
            this.wizNesState1.CharWeek = 24;
            this.wizNesState1.RES_SCN = WizFCEdit.WIZ_SCN.S1;
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
            this.wizCharList1.TabIndex = 0;
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
            this.wizCharCaption1.TabIndex = 4;
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
            this.wizGold.Mode = WizFCEdit.WizParamMode.Gold;
            this.wizGold.Name = "wizGold";
            this.wizGold.NearText = "GOLD";
            this.wizGold.Size = new System.Drawing.Size(244, 23);
            this.wizGold.TabIndex = 6;
            this.wizGold.Text = "wizParam1";
            this.wizGold.Value = ((long)(0));
            this.wizGold.WizNesState = this.wizNesState1;
            // 
            // wizEP
            // 
            this.wizEP.BackColor = System.Drawing.Color.Black;
            this.wizEP.FarText = "0";
            this.wizEP.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizEP.ForeColor = System.Drawing.Color.White;
            this.wizEP.IsDrawFrame = false;
            this.wizEP.Location = new System.Drawing.Point(396, 166);
            this.wizEP.Mode = WizFCEdit.WizParamMode.Exp;
            this.wizEP.Name = "wizEP";
            this.wizEP.NearText = "E.P.";
            this.wizEP.Size = new System.Drawing.Size(244, 23);
            this.wizEP.TabIndex = 7;
            this.wizEP.Text = "wizParam2";
            this.wizEP.Value = ((long)(0));
            this.wizEP.WizNesState = this.wizNesState1;
            // 
            // wizAge
            // 
            this.wizAge.BackColor = System.Drawing.Color.Black;
            this.wizAge.FarText = "16";
            this.wizAge.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizAge.ForeColor = System.Drawing.Color.White;
            this.wizAge.IsDrawFrame = false;
            this.wizAge.Location = new System.Drawing.Point(396, 226);
            this.wizAge.Mode = WizFCEdit.WizParamMode.Age;
            this.wizAge.Name = "wizAge";
            this.wizAge.NearText = "AGE";
            this.wizAge.Size = new System.Drawing.Size(84, 23);
            this.wizAge.TabIndex = 9;
            this.wizAge.Text = "wizParam3";
            this.wizAge.Value = ((long)(16));
            this.wizAge.WizNesState = this.wizNesState1;
            // 
            // wizWeek
            // 
            this.wizWeek.BackColor = System.Drawing.Color.Black;
            this.wizWeek.FarText = "24";
            this.wizWeek.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizWeek.ForeColor = System.Drawing.Color.White;
            this.wizWeek.IsDrawFrame = false;
            this.wizWeek.Location = new System.Drawing.Point(556, 226);
            this.wizWeek.Mode = WizFCEdit.WizParamMode.Week;
            this.wizWeek.Name = "wizWeek";
            this.wizWeek.NearText = "Week";
            this.wizWeek.Size = new System.Drawing.Size(84, 23);
            this.wizWeek.TabIndex = 10;
            this.wizWeek.Text = "wizParam4";
            this.wizWeek.Value = ((long)(24));
            this.wizWeek.WizNesState = this.wizNesState1;
            // 
            // wizAC
            // 
            this.wizAC.BackColor = System.Drawing.Color.Black;
            this.wizAC.FarText = "4";
            this.wizAC.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizAC.ForeColor = System.Drawing.Color.White;
            this.wizAC.IsDrawFrame = false;
            this.wizAC.Location = new System.Drawing.Point(451, 255);
            this.wizAC.Mode = WizFCEdit.WizParamMode.AC;
            this.wizAC.Name = "wizAC";
            this.wizAC.NearText = "A.C.";
            this.wizAC.Size = new System.Drawing.Size(113, 23);
            this.wizAC.TabIndex = 12;
            this.wizAC.Text = "wizParam5";
            this.wizAC.Value = ((long)(4));
            this.wizAC.WizNesState = this.wizNesState1;
            // 
            // wizBonus1
            // 
            this.wizBonus1.BackColor = System.Drawing.Color.Black;
            this.wizBonus1.CaptionWidth = 100;
            this.wizBonus1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizBonus1.ForeColor = System.Drawing.Color.White;
            this.wizBonus1.IsDrawFrame = false;
            this.wizBonus1.IsJapan = true;
            this.wizBonus1.LineHeight = 18;
            this.wizBonus1.Location = new System.Drawing.Point(270, 255);
            this.wizBonus1.MinimumSize = new System.Drawing.Size(150, 108);
            this.wizBonus1.Name = "wizBonus1";
            this.wizBonus1.Size = new System.Drawing.Size(175, 120);
            this.wizBonus1.TabIndex = 11;
            this.wizBonus1.Text = "wizBonus2";
            this.wizBonus1.ValueWidth = 50;
            this.wizBonus1.WizNesState = this.wizNesState1;
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
            this.wizHP1.TabIndex = 8;
            this.wizHP1.Text = "wizHP1";
            this.wizHP1.WizNesState = this.wizNesState1;
            // 
            // wizStatus1
            // 
            this.wizStatus1.CaptionWidth = 100;
            this.wizStatus1.IsDrawFrame = false;
            this.wizStatus1.IsJapan = true;
            this.wizStatus1.Location = new System.Drawing.Point(451, 284);
            this.wizStatus1.Name = "wizStatus1";
            this.wizStatus1.Size = new System.Drawing.Size(220, 24);
            this.wizStatus1.TabIndex = 13;
            this.wizStatus1.Text = "wizStatus1";
            this.wizStatus1.WizNesState = this.wizNesState1;
            // 
            // wizMP1
            // 
            this.wizMP1.BackColor = System.Drawing.Color.Black;
            this.wizMP1.CaptionWidth = 25;
            this.wizMP1.ForeColor = System.Drawing.Color.White;
            this.wizMP1.IsDrawFrame = false;
            this.wizMP1.LineHeight = 25;
            this.wizMP1.Location = new System.Drawing.Point(451, 315);
            this.wizMP1.MinimumSize = new System.Drawing.Size(205, 50);
            this.wizMP1.Name = "wizMP1";
            this.wizMP1.Size = new System.Drawing.Size(205, 50);
            this.wizMP1.TabIndex = 14;
            this.wizMP1.Text = "wizMP1";
            this.wizMP1.ValueWidth = 25;
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
            this.wizConrol1.TabIndex = 1;
            this.wizConrol1.Text = "wizConrol1";
            this.wizConrol1.TopMargin = 5;
            // 
            // wizItemList1
            // 
            this.wizItemList1.BackColor = System.Drawing.Color.Black;
            this.wizItemList1.ForeColor = System.Drawing.Color.White;
            this.wizItemList1.IsDrawFrame = false;
            this.wizItemList1.ItemID = 1;
            this.wizItemList1.LineHeight = 20;
            this.wizItemList1.Location = new System.Drawing.Point(267, 381);
            this.wizItemList1.MinimumSize = new System.Drawing.Size(0, 160);
            this.wizItemList1.Name = "wizItemList1";
            this.wizItemList1.Size = new System.Drawing.Size(389, 160);
            this.wizItemList1.StWidth = 18;
            this.wizItemList1.TabIndex = 15;
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
            this.listBox1.Location = new System.Drawing.Point(110, 451);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(95, 66);
            this.listBox1.TabIndex = 17;
            this.listBox1.Visible = false;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Black;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnUp.ForeColor = System.Drawing.Color.White;
            this.btnUp.Location = new System.Drawing.Point(49, 544);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(35, 24);
            this.btnUp.TabIndex = 2;
            this.btnUp.Text = "UP";
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Black;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnDown.ForeColor = System.Drawing.Color.White;
            this.btnDown.Location = new System.Drawing.Point(90, 544);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(50, 24);
            this.btnDown.TabIndex = 3;
            this.btnDown.Text = "DOWN";
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // wizValueEditor1
            // 
            this.wizValueEditor1.BackColor = System.Drawing.Color.Black;
            this.wizValueEditor1.BottomMargin = 5;
            this.wizValueEditor1.Caption = "";
            this.wizValueEditor1.Corner = 5;
            this.wizValueEditor1.ForeColor = System.Drawing.Color.White;
            this.wizValueEditor1.LineWidth = 3;
            this.wizValueEditor1.Location = new System.Drawing.Point(54, 78);
            this.wizValueEditor1.MaximumSize = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.MinimumSize = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.Name = "wizValueEditor1";
            this.wizValueEditor1.SiseMargin = 5;
            this.wizValueEditor1.Size = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.TabIndex = 18;
            this.wizValueEditor1.Text = "wizValueEditor1";
            this.wizValueEditor1.TopMargin = 5;
            this.wizValueEditor1.Value = ((long)(0));
            this.wizValueEditor1.ValueMax = ((long)(281474976710655));
            this.wizValueEditor1.ValueMin = ((long)(0));
            this.wizValueEditor1.Visible = false;
            // 
            // wizSpellList1
            // 
            this.wizSpellList1.BackColor = System.Drawing.Color.Black;
            this.wizSpellList1.BottomMargin = 5;
            this.wizSpellList1.Corner = 5;
            this.wizSpellList1.Font = new System.Drawing.Font("MS UI Gothic", 9F);
            this.wizSpellList1.ForeColor = System.Drawing.Color.White;
            this.wizSpellList1.LeftMgn = 30;
            this.wizSpellList1.LineHeight = 20;
            this.wizSpellList1.LineWidth = 3;
            this.wizSpellList1.Location = new System.Drawing.Point(85, 195);
            this.wizSpellList1.MaximumSize = new System.Drawing.Size(570, 250);
            this.wizSpellList1.MinimumSize = new System.Drawing.Size(570, 250);
            this.wizSpellList1.Name = "wizSpellList1";
            this.wizSpellList1.SiseMargin = 5;
            this.wizSpellList1.Size = new System.Drawing.Size(570, 250);
            this.wizSpellList1.SpellWidth = 75;
            this.wizSpellList1.TabIndex = 19;
            this.wizSpellList1.Text = "wizSpellList1";
            this.wizSpellList1.TopMargin = 5;
            this.wizSpellList1.TopMgn = 40;
            this.wizSpellList1.Visible = false;
            this.wizSpellList1.WizNesState = this.wizNesState1;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Black;
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Location = new System.Drawing.Point(606, 61);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(65, 24);
            this.btnSetting.TabIndex = 20;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = false;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // wizPictureBox1
            // 
            this.wizPictureBox1.BackColor = System.Drawing.Color.Black;
            this.wizPictureBox1.BottomMargin = 5;
            this.wizPictureBox1.Corner = 5;
            this.wizPictureBox1.ForeColor = System.Drawing.Color.White;
            this.wizPictureBox1.LineWidth = 2;
            this.wizPictureBox1.Location = new System.Drawing.Point(267, 137);
            this.wizPictureBox1.MaximumSize = new System.Drawing.Size(120, 120);
            this.wizPictureBox1.MinimumSize = new System.Drawing.Size(120, 120);
            this.wizPictureBox1.Name = "wizPictureBox1";
            this.wizPictureBox1.SiseMargin = 5;
            this.wizPictureBox1.Size = new System.Drawing.Size(120, 120);
            this.wizPictureBox1.TabIndex = 21;
            this.wizPictureBox1.Text = "wizPictureBox1";
            this.wizPictureBox1.TopMargin = 5;
            this.wizPictureBox1.WizNesState = this.wizNesState1;
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
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.wizSpellList1);
            this.Controls.Add(this.wizValueEditor1);
            this.Controls.Add(this.wizPictureBox1);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.wizItemList1);
            this.Controls.Add(this.wizMP1);
            this.Controls.Add(this.wizStatus1);
            this.Controls.Add(this.wizHP1);
            this.Controls.Add(this.wizBonus1);
            this.Controls.Add(this.wizAC);
            this.Controls.Add(this.wizWeek);
            this.Controls.Add(this.wizAge);
            this.Controls.Add(this.wizEP);
            this.Controls.Add(this.wizGold);
            this.Controls.Add(this.wizCharCaption1);
            this.Controls.Add(this.wizCharList1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.wizConrol1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.ListBox = this.listBox1;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(638, 606);
            this.Name = "Form1";
            this.Text = "{X=0,Y=0,Width=903,Height=523}";
            this.WizAC = this.wizAC;
            this.WizAge = this.wizAge;
            this.WizBonus = this.wizBonus1;
            this.WizCharCaption = this.wizCharCaption1;
            this.WizCharList = this.wizCharList1;
            this.WizEP = this.wizEP;
            this.WizGold = this.wizGold;
            this.WizHP = this.wizHP1;
            this.WizItemList = this.wizItemList1;
            this.WizNesState = this.wizNesState1;
            this.WizStatus = this.wizStatus1;
            this.WizValueEditor = this.wizValueEditor1;
            this.WizWeek = this.wizWeek;
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
        private WizFCState wizNesState1;
        private WizCharList wizCharList1;
        private WizCharCaption wizCharCaption1;
        private WizParam wizGold;
        private WizParam wizEP;
        private WizParam wizAge;
        private WizParam wizWeek;
        private WizParam wizAC;
        private WizBonus wizBonus1;
        private WizHP wizHP1;
        private WizStatus wizStatus1;
        private WizMP wizMP1;
        private WizBoxControl wizConrol1;
        private WizItemList wizItemList1;
        private System.Windows.Forms.ListBox listBox1;
        private WizButton btnUp;
        private WizButton btnDown;
        private WizValueEditor wizValueEditor1;
        private WizSpellList wizSpellList1;
        private WizButton btnSetting;
        private WizPictureBox wizPictureBox1;
    }
}

