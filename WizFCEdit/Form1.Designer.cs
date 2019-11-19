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
            this.beAge = new WizFCEdit.WizByteEdit();
            this.beWeek = new WizFCEdit.WizByteEdit();
            this.beAC = new WizFCEdit.WizByteEdit();
            this.leGold = new WizFCEdit.WizLongEdit();
            this.leExp = new WizFCEdit.WizLongEdit();
            this.leHP = new WizFCEdit.WizLongEdit();
            this.leHPMax = new WizFCEdit.WizLongEdit();
            this.beVitality = new WizFCEdit.WizByteEdit();
            this.beStrength = new WizFCEdit.WizByteEdit();
            this.bePiety = new WizFCEdit.WizByteEdit();
            this.beIQ = new WizFCEdit.WizByteEdit();
            this.beAgility = new WizFCEdit.WizByteEdit();
            this.wizByteEdit1 = new WizFCEdit.WizByteEdit();
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
            this.wizNesState1.CharAgility = ((byte)(8));
            this.wizNesState1.CharAlg = WizFCEdit.WIZALG.GOOD;
            this.wizNesState1.CharClass = WizFCEdit.WIZCLASS.FIG;
            this.wizNesState1.CharCurrent = 0;
            this.wizNesState1.CharExp = ((long)(0));
            this.wizNesState1.CharGold = ((long)(0));
            this.wizNesState1.CharHP = ((ushort)(8));
            this.wizNesState1.CharHPMax = ((ushort)(8));
            this.wizNesState1.CharIQ = ((byte)(8));
            this.wizNesState1.CharLevel = ((ushort)(1));
            this.wizNesState1.CharLuck = ((byte)(9));
            this.wizNesState1.CharNameCode = new byte[] {
        ((byte)(123)),
        ((byte)(155)),
        ((byte)(121)),
        ((byte)(1))};
            this.wizNesState1.CharPiety = ((byte)(7));
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
            this.wizNesState1.CharStrength = ((byte)(8));
            this.wizNesState1.CharVitarity = ((byte)(8));
            this.wizNesState1.CharWeek = ((byte)(24));
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
            this.wizCharList1.ListTopMgn = 30;
            this.wizCharList1.Location = new System.Drawing.Point(37, 86);
            this.wizCharList1.Margin = new System.Windows.Forms.Padding(4);
            this.wizCharList1.MinimumSize = new System.Drawing.Size(0, 370);
            this.wizCharList1.Name = "wizCharList1";
            this.wizCharList1.SideMargin = 5;
            this.wizCharList1.Size = new System.Drawing.Size(205, 451);
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
            this.wizConrol1.SideMargin = 5;
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
            this.wizItemList1.Location = new System.Drawing.Point(270, 391);
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
            this.wizValueEditor1.Location = new System.Drawing.Point(-45, 166);
            this.wizValueEditor1.MaximumSize = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.MinimumSize = new System.Drawing.Size(250, 310);
            this.wizValueEditor1.Name = "wizValueEditor1";
            this.wizValueEditor1.SideMargin = 5;
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
            this.wizSpellList1.Location = new System.Drawing.Point(-448, 86);
            this.wizSpellList1.MaximumSize = new System.Drawing.Size(570, 250);
            this.wizSpellList1.MinimumSize = new System.Drawing.Size(570, 250);
            this.wizSpellList1.Name = "wizSpellList1";
            this.wizSpellList1.SideMargin = 5;
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
            this.wizPictureBox1.Location = new System.Drawing.Point(263, 128);
            this.wizPictureBox1.MaximumSize = new System.Drawing.Size(120, 120);
            this.wizPictureBox1.MinimumSize = new System.Drawing.Size(120, 120);
            this.wizPictureBox1.Name = "wizPictureBox1";
            this.wizPictureBox1.SideMargin = 5;
            this.wizPictureBox1.Size = new System.Drawing.Size(120, 120);
            this.wizPictureBox1.TabIndex = 21;
            this.wizPictureBox1.Text = "wizPictureBox1";
            this.wizPictureBox1.TopMargin = 5;
            this.wizPictureBox1.WizNesState = this.wizNesState1;
            // 
            // beAge
            // 
            this.beAge.ArrowWidth = 10;
            this.beAge.BackColor = System.Drawing.Color.Black;
            this.beAge.CaptionLeft = true;
            this.beAge.CaptionWidth = 130;
            this.beAge.ForeColor = System.Drawing.Color.White;
            this.beAge.IsEdit = true;
            this.beAge.Location = new System.Drawing.Point(393, 226);
            this.beAge.Mode = WizFCEdit.WizByteEditMode.Age;
            this.beAge.Name = "beAge";
            this.beAge.Size = new System.Drawing.Size(101, 23);
            this.beAge.TabIndex = 22;
            this.beAge.Text = "AGE";
            this.beAge.Value = 16;
            this.beAge.WizFCState = this.wizNesState1;
            // 
            // beWeek
            // 
            this.beWeek.ArrowWidth = 10;
            this.beWeek.BackColor = System.Drawing.Color.Black;
            this.beWeek.CaptionLeft = true;
            this.beWeek.CaptionWidth = 100;
            this.beWeek.ForeColor = System.Drawing.Color.White;
            this.beWeek.IsEdit = false;
            this.beWeek.Location = new System.Drawing.Point(540, 226);
            this.beWeek.Mode = WizFCEdit.WizByteEditMode.Week;
            this.beWeek.Name = "beWeek";
            this.beWeek.Size = new System.Drawing.Size(106, 23);
            this.beWeek.TabIndex = 23;
            this.beWeek.Text = "Week";
            this.beWeek.Value = 24;
            this.beWeek.WizFCState = this.wizNesState1;
            // 
            // beAC
            // 
            this.beAC.ArrowWidth = 10;
            this.beAC.BackColor = System.Drawing.Color.Black;
            this.beAC.CaptionLeft = true;
            this.beAC.CaptionWidth = 130;
            this.beAC.ForeColor = System.Drawing.Color.White;
            this.beAC.IsEdit = false;
            this.beAC.Location = new System.Drawing.Point(451, 255);
            this.beAC.Mode = WizFCEdit.WizByteEditMode.AC;
            this.beAC.Name = "beAC";
            this.beAC.Size = new System.Drawing.Size(119, 23);
            this.beAC.TabIndex = 24;
            this.beAC.Text = "A.C.";
            this.beAC.Value = 4;
            this.beAC.WizFCState = this.wizNesState1;
            // 
            // leGold
            // 
            this.leGold.ArrowHeight = 5;
            this.leGold.BackColor = System.Drawing.Color.Black;
            this.leGold.ClearWidth = 10;
            this.leGold.ForeColor = System.Drawing.Color.White;
            this.leGold.IsEdit = false;
            this.leGold.Location = new System.Drawing.Point(393, 130);
            this.leGold.Mode = WizFCEdit.WizLongEditMode.Gold;
            this.leGold.Name = "leGold";
            this.leGold.NumWidth = 10;
            this.leGold.Size = new System.Drawing.Size(253, 32);
            this.leGold.TabIndex = 26;
            this.leGold.Text = "GOLD";
            this.leGold.Value = ((ulong)(0ul));
            this.leGold.WizFCState = this.wizNesState1;
            // 
            // leExp
            // 
            this.leExp.ArrowHeight = 5;
            this.leExp.BackColor = System.Drawing.Color.Black;
            this.leExp.ClearWidth = 10;
            this.leExp.ForeColor = System.Drawing.Color.White;
            this.leExp.IsEdit = false;
            this.leExp.Location = new System.Drawing.Point(393, 162);
            this.leExp.Mode = WizFCEdit.WizLongEditMode.Exp;
            this.leExp.Name = "leExp";
            this.leExp.NumWidth = 10;
            this.leExp.Size = new System.Drawing.Size(253, 32);
            this.leExp.TabIndex = 28;
            this.leExp.Text = "E.P.";
            this.leExp.Value = ((ulong)(0ul));
            this.leExp.WizFCState = this.wizNesState1;
            // 
            // leHP
            // 
            this.leHP.ArrowHeight = 5;
            this.leHP.BackColor = System.Drawing.Color.Black;
            this.leHP.ClearWidth = 10;
            this.leHP.ForeColor = System.Drawing.Color.White;
            this.leHP.IsEdit = false;
            this.leHP.Location = new System.Drawing.Point(393, 194);
            this.leHP.Mode = WizFCEdit.WizLongEditMode.HP;
            this.leHP.Name = "leHP";
            this.leHP.NumWidth = 10;
            this.leHP.Size = new System.Drawing.Size(141, 32);
            this.leHP.TabIndex = 29;
            this.leHP.Text = "H.P.";
            this.leHP.Value = ((ulong)(8ul));
            this.leHP.WizFCState = this.wizNesState1;
            // 
            // leHPMax
            // 
            this.leHPMax.ArrowHeight = 5;
            this.leHPMax.BackColor = System.Drawing.Color.Black;
            this.leHPMax.ClearWidth = 10;
            this.leHPMax.ForeColor = System.Drawing.Color.White;
            this.leHPMax.IsEdit = false;
            this.leHPMax.Location = new System.Drawing.Point(540, 194);
            this.leHPMax.Mode = WizFCEdit.WizLongEditMode.HPMax;
            this.leHPMax.Name = "leHPMax";
            this.leHPMax.NumWidth = 10;
            this.leHPMax.Size = new System.Drawing.Size(106, 32);
            this.leHPMax.TabIndex = 30;
            this.leHPMax.Text = "/";
            this.leHPMax.Value = ((ulong)(8ul));
            this.leHPMax.WizFCState = this.wizNesState1;
            // 
            // beVitality
            // 
            this.beVitality.ArrowWidth = 10;
            this.beVitality.BackColor = System.Drawing.Color.Black;
            this.beVitality.CaptionLeft = false;
            this.beVitality.CaptionWidth = 100;
            this.beVitality.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.beVitality.ForeColor = System.Drawing.Color.White;
            this.beVitality.IsEdit = true;
            this.beVitality.Location = new System.Drawing.Point(286, 320);
            this.beVitality.Mode = WizFCEdit.WizByteEditMode.Vitality;
            this.beVitality.Name = "beVitality";
            this.beVitality.Size = new System.Drawing.Size(147, 20);
            this.beVitality.TabIndex = 31;
            this.beVitality.Text = "せいめいりょく";
            this.beVitality.Value = 8;
            this.beVitality.WizFCState = this.wizNesState1;
            // 
            // beStrength
            // 
            this.beStrength.ArrowWidth = 10;
            this.beStrength.BackColor = System.Drawing.Color.Black;
            this.beStrength.CaptionLeft = false;
            this.beStrength.CaptionWidth = 100;
            this.beStrength.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.beStrength.ForeColor = System.Drawing.Color.White;
            this.beStrength.IsEdit = true;
            this.beStrength.Location = new System.Drawing.Point(286, 260);
            this.beStrength.Mode = WizFCEdit.WizByteEditMode.Strength;
            this.beStrength.Name = "beStrength";
            this.beStrength.Size = new System.Drawing.Size(147, 20);
            this.beStrength.TabIndex = 32;
            this.beStrength.Text = "ちから";
            this.beStrength.Value = 8;
            this.beStrength.WizFCState = this.wizNesState1;
            // 
            // bePiety
            // 
            this.bePiety.ArrowWidth = 10;
            this.bePiety.BackColor = System.Drawing.Color.Black;
            this.bePiety.CaptionLeft = false;
            this.bePiety.CaptionWidth = 100;
            this.bePiety.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.bePiety.ForeColor = System.Drawing.Color.White;
            this.bePiety.IsEdit = true;
            this.bePiety.Location = new System.Drawing.Point(286, 300);
            this.bePiety.Mode = WizFCEdit.WizByteEditMode.Piety;
            this.bePiety.Name = "bePiety";
            this.bePiety.Size = new System.Drawing.Size(147, 20);
            this.bePiety.TabIndex = 33;
            this.bePiety.Text = "しんこうしん";
            this.bePiety.Value = 7;
            this.bePiety.WizFCState = this.wizNesState1;
            // 
            // beIQ
            // 
            this.beIQ.ArrowWidth = 10;
            this.beIQ.BackColor = System.Drawing.Color.Black;
            this.beIQ.CaptionLeft = false;
            this.beIQ.CaptionWidth = 100;
            this.beIQ.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.beIQ.ForeColor = System.Drawing.Color.White;
            this.beIQ.IsEdit = true;
            this.beIQ.Location = new System.Drawing.Point(286, 280);
            this.beIQ.Mode = WizFCEdit.WizByteEditMode.IQ;
            this.beIQ.Name = "beIQ";
            this.beIQ.Size = new System.Drawing.Size(147, 20);
            this.beIQ.TabIndex = 34;
            this.beIQ.Text = "ちえ";
            this.beIQ.Value = 8;
            this.beIQ.WizFCState = this.wizNesState1;
            // 
            // beAgility
            // 
            this.beAgility.ArrowWidth = 10;
            this.beAgility.BackColor = System.Drawing.Color.Black;
            this.beAgility.CaptionLeft = false;
            this.beAgility.CaptionWidth = 100;
            this.beAgility.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.beAgility.ForeColor = System.Drawing.Color.White;
            this.beAgility.IsEdit = true;
            this.beAgility.Location = new System.Drawing.Point(286, 340);
            this.beAgility.Mode = WizFCEdit.WizByteEditMode.Agility;
            this.beAgility.Name = "beAgility";
            this.beAgility.Size = new System.Drawing.Size(147, 20);
            this.beAgility.TabIndex = 35;
            this.beAgility.Text = "すばやさ";
            this.beAgility.Value = 8;
            this.beAgility.WizFCState = this.wizNesState1;
            // 
            // wizByteEdit1
            // 
            this.wizByteEdit1.ArrowWidth = 10;
            this.wizByteEdit1.BackColor = System.Drawing.Color.Black;
            this.wizByteEdit1.CaptionLeft = false;
            this.wizByteEdit1.CaptionWidth = 100;
            this.wizByteEdit1.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizByteEdit1.ForeColor = System.Drawing.Color.White;
            this.wizByteEdit1.IsEdit = true;
            this.wizByteEdit1.Location = new System.Drawing.Point(286, 360);
            this.wizByteEdit1.Mode = WizFCEdit.WizByteEditMode.Luck;
            this.wizByteEdit1.Name = "wizByteEdit1";
            this.wizByteEdit1.Size = new System.Drawing.Size(147, 20);
            this.wizByteEdit1.TabIndex = 36;
            this.wizByteEdit1.Text = "うんのつよさ";
            this.wizByteEdit1.Value = 9;
            this.wizByteEdit1.WizFCState = this.wizNesState1;
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
            this.Controls.Add(this.wizByteEdit1);
            this.Controls.Add(this.beAgility);
            this.Controls.Add(this.beIQ);
            this.Controls.Add(this.bePiety);
            this.Controls.Add(this.wizStatus1);
            this.Controls.Add(this.beStrength);
            this.Controls.Add(this.beVitality);
            this.Controls.Add(this.leHPMax);
            this.Controls.Add(this.leHP);
            this.Controls.Add(this.leExp);
            this.Controls.Add(this.wizSpellList1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.wizValueEditor1);
            this.Controls.Add(this.leGold);
            this.Controls.Add(this.beAC);
            this.Controls.Add(this.beWeek);
            this.Controls.Add(this.beAge);
            this.Controls.Add(this.wizPictureBox1);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.wizMP1);
            this.Controls.Add(this.wizCharCaption1);
            this.Controls.Add(this.wizCharList1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.wizItemList1);
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
            this.WizAC = this.beAC;
            this.WizAge = this.beAge;
            this.WizCharCaption = this.wizCharCaption1;
            this.WizCharList = this.wizCharList1;
            this.WizEP = this.leExp;
            this.WizGold = this.leGold;
            this.WizHP = this.leHP;
            this.WizHPMax = this.leHPMax;
            this.WizItemList = this.wizItemList1;
            this.WizNesState = this.wizNesState1;
            this.WizStatus = this.wizStatus1;
            this.WizValueEditor = this.wizValueEditor1;
            this.WizWeek = this.beWeek;
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
        private WizByteEdit beAge;
        private WizByteEdit beWeek;
        private WizByteEdit beAC;
        private WizLongEdit leGold;
        private WizLongEdit leExp;
        private WizLongEdit leHP;
        private WizLongEdit leHPMax;
        private WizByteEdit beVitality;
        private WizByteEdit beStrength;
        private WizByteEdit bePiety;
        private WizByteEdit beIQ;
        private WizByteEdit beAgility;
        private WizByteEdit wizByteEdit1;
    }
}

