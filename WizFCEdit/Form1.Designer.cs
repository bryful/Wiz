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
            WizEdit.MagicPoint magicPoint1 = new WizEdit.MagicPoint();
            WizEdit.MagicPoint magicPoint2 = new WizEdit.MagicPoint();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pctureFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wizNesState1 = new WizEdit.WizData();
            this.wizCharList1 = new WizEdit.WizCharList();
            this.wizStatus1 = new WizEdit.WizStatus();
            this.wizConrol1 = new WizEdit.WizBoxControl();
            this.wizItemList1 = new WizEdit.WizItemList();
            this.btnSetting = new WizEdit.WizButton();
            this.wizPictureBox1 = new WizEdit.WizPictureBox();
            this.beAge = new WizEdit.WizByteEdit();
            this.beWeek = new WizEdit.WizByteEdit();
            this.beAC = new WizEdit.WizByteEdit();
            this.leGold = new WizEdit.WizLongEdit();
            this.leExp = new WizEdit.WizLongEdit();
            this.leHP = new WizEdit.WizLongEdit();
            this.leHPMax = new WizEdit.WizLongEdit();
            this.beVitality = new WizEdit.WizByteEdit();
            this.beStrength = new WizEdit.WizByteEdit();
            this.bePiety = new WizEdit.WizByteEdit();
            this.beIQ = new WizEdit.WizByteEdit();
            this.beAgility = new WizEdit.WizByteEdit();
            this.beLuck = new WizEdit.WizByteEdit();
            this.wizCharName1 = new WizEdit.WizCharName();
            this.wizCharClass1 = new WizEdit.WizCharClass();
            this.leLevel = new WizEdit.WizLongEdit();
            this.wizItemSelect1 = new WizEdit.WizItemSelect();
            this.wizMPList1 = new WizEdit.WizMPList();
            this.button1 = new System.Windows.Forms.Button();
            this.wizScnComb1 = new WizEdit.WizScnComb();
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
            this.menuStrip1.Size = new System.Drawing.Size(716, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.reloadToolStripMenuItem,
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
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // reloadToolStripMenuItem
            // 
            this.reloadToolStripMenuItem.Name = "reloadToolStripMenuItem";
            this.reloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reloadToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.reloadToolStripMenuItem.Text = "Reload";
            this.reloadToolStripMenuItem.Click += new System.EventHandler(this.reloadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.saveAsToolStripMenuItem.Text = "SaveAs";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.pctureFolderToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.K)));
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // pctureFolderToolStripMenuItem
            // 
            this.pctureFolderToolStripMenuItem.Name = "pctureFolderToolStripMenuItem";
            this.pctureFolderToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.pctureFolderToolStripMenuItem.Text = "キャラクタアイコンのフォルダを指定";
            this.pctureFolderToolStripMenuItem.Click += new System.EventHandler(this.pctureFolderToolStripMenuItem_Click);
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
            this.wizNesState1.CharAlg = WizEdit.WIZALG.GOOD;
            this.wizNesState1.CharClass = WizEdit.WIZCLASS.FIG;
            this.wizNesState1.CharCurrent = 0;
            this.wizNesState1.CharExp = ((long)(0));
            this.wizNesState1.CharGold = ((long)(0));
            this.wizNesState1.CharHP = ((ushort)(8));
            this.wizNesState1.CharHPMax = ((ushort)(8));
            this.wizNesState1.CharIQ = ((byte)(8));
            this.wizNesState1.CharLevel = ((ushort)(1));
            this.wizNesState1.CharLuck = ((byte)(9));
            this.wizNesState1.CharMagic = magicPoint1;
            this.wizNesState1.CharNameCode = new byte[] {
        ((byte)(123)),
        ((byte)(155)),
        ((byte)(121)),
        ((byte)(1))};
            this.wizNesState1.CharPiety = ((byte)(7));
            this.wizNesState1.CharPriest = magicPoint2;
            this.wizNesState1.CharRace = WizEdit.WIZRACE.HUMAN;
            this.wizNesState1.CharSpell = new byte[] {
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0)),
        ((byte)(0))};
            this.wizNesState1.CharStatus = WizEdit.WIZSTATUS.OK;
            this.wizNesState1.CharStrength = ((byte)(8));
            this.wizNesState1.CharVitarity = ((byte)(8));
            this.wizNesState1.CharWeek = ((byte)(24));
            this.wizNesState1.RES_SCN = WizEdit.WIZSCN.FC1;
            // 
            // wizCharList1
            // 
            this.wizCharList1.BackColor = System.Drawing.Color.Black;
            this.wizCharList1.BottomMargin = 5;
            this.wizCharList1.Corner = 5;
            this.wizCharList1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizCharList1.ForeColor = System.Drawing.Color.White;
            this.wizCharList1.IsActive = true;
            this.wizCharList1.IsEditSort = false;
            this.wizCharList1.LineHeight = 18;
            this.wizCharList1.LineWidth = 3;
            this.wizCharList1.ListBottomMgn = 5;
            this.wizCharList1.ListLeftMgn = 30;
            this.wizCharList1.ListRightMgn = 10;
            this.wizCharList1.ListTopMgn = 40;
            this.wizCharList1.Location = new System.Drawing.Point(37, 86);
            this.wizCharList1.Margin = new System.Windows.Forms.Padding(4);
            this.wizCharList1.MinimumSize = new System.Drawing.Size(0, 370);
            this.wizCharList1.Name = "wizCharList1";
            this.wizCharList1.SideMargin = 5;
            this.wizCharList1.Size = new System.Drawing.Size(205, 466);
            this.wizCharList1.TabIndex = 0;
            this.wizCharList1.Text = "wizCharList1";
            this.wizCharList1.TopMargin = 5;
            this.wizCharList1.WizNesState = this.wizNesState1;
            // 
            // wizStatus1
            // 
            this.wizStatus1.CaptionWidth = 100;
            this.wizStatus1.IsDrawFrame = false;
            this.wizStatus1.IsJapan = true;
            this.wizStatus1.Location = new System.Drawing.Point(451, 284);
            this.wizStatus1.Name = "wizStatus1";
            this.wizStatus1.Size = new System.Drawing.Size(220, 24);
            this.wizStatus1.TabIndex = 21;
            this.wizStatus1.Text = "wizStatus1";
            this.wizStatus1.WizNesState = this.wizNesState1;
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
            this.wizConrol1.Size = new System.Drawing.Size(436, 466);
            this.wizConrol1.TabIndex = 3;
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
            this.wizItemList1.Location = new System.Drawing.Point(267, 386);
            this.wizItemList1.MinimumSize = new System.Drawing.Size(0, 160);
            this.wizItemList1.Name = "wizItemList1";
            this.wizItemList1.Size = new System.Drawing.Size(320, 160);
            this.wizItemList1.StWidth = 18;
            this.wizItemList1.TabIndex = 23;
            this.wizItemList1.Text = "wizItemList1";
            this.wizItemList1.WizNesState = this.wizNesState1;
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Black;
            this.btnSetting.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.IsDrawWaku = true;
            this.btnSetting.Location = new System.Drawing.Point(607, 61);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(70, 24);
            this.btnSetting.TabIndex = 24;
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
            this.wizPictureBox1.PicureFolderPath = "";
            this.wizPictureBox1.SideMargin = 5;
            this.wizPictureBox1.Size = new System.Drawing.Size(120, 120);
            this.wizPictureBox1.TabIndex = 7;
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
            this.beAge.Mode = WizEdit.WizByteEditMode.Age;
            this.beAge.Name = "beAge";
            this.beAge.Size = new System.Drawing.Size(101, 23);
            this.beAge.TabIndex = 12;
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
            this.beWeek.Mode = WizEdit.WizByteEditMode.Week;
            this.beWeek.Name = "beWeek";
            this.beWeek.Size = new System.Drawing.Size(106, 23);
            this.beWeek.TabIndex = 13;
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
            this.beAC.Mode = WizEdit.WizByteEditMode.AC;
            this.beAC.Name = "beAC";
            this.beAC.Size = new System.Drawing.Size(119, 23);
            this.beAC.TabIndex = 20;
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
            this.leGold.Mode = WizEdit.WizLongEditMode.Gold;
            this.leGold.Name = "leGold";
            this.leGold.NumWidth = 10;
            this.leGold.Size = new System.Drawing.Size(253, 32);
            this.leGold.TabIndex = 8;
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
            this.leExp.Mode = WizEdit.WizLongEditMode.Exp;
            this.leExp.Name = "leExp";
            this.leExp.NumWidth = 10;
            this.leExp.Size = new System.Drawing.Size(253, 32);
            this.leExp.TabIndex = 9;
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
            this.leHP.Mode = WizEdit.WizLongEditMode.HP;
            this.leHP.Name = "leHP";
            this.leHP.NumWidth = 10;
            this.leHP.Size = new System.Drawing.Size(141, 32);
            this.leHP.TabIndex = 10;
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
            this.leHPMax.Mode = WizEdit.WizLongEditMode.HPMax;
            this.leHPMax.Name = "leHPMax";
            this.leHPMax.NumWidth = 10;
            this.leHPMax.Size = new System.Drawing.Size(106, 32);
            this.leHPMax.TabIndex = 11;
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
            this.beVitality.Mode = WizEdit.WizByteEditMode.Vitality;
            this.beVitality.Name = "beVitality";
            this.beVitality.Size = new System.Drawing.Size(147, 20);
            this.beVitality.TabIndex = 17;
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
            this.beStrength.Mode = WizEdit.WizByteEditMode.Strength;
            this.beStrength.Name = "beStrength";
            this.beStrength.Size = new System.Drawing.Size(147, 20);
            this.beStrength.TabIndex = 14;
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
            this.bePiety.Mode = WizEdit.WizByteEditMode.Piety;
            this.bePiety.Name = "bePiety";
            this.bePiety.Size = new System.Drawing.Size(147, 20);
            this.bePiety.TabIndex = 16;
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
            this.beIQ.Mode = WizEdit.WizByteEditMode.IQ;
            this.beIQ.Name = "beIQ";
            this.beIQ.Size = new System.Drawing.Size(147, 20);
            this.beIQ.TabIndex = 15;
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
            this.beAgility.Mode = WizEdit.WizByteEditMode.Agility;
            this.beAgility.Name = "beAgility";
            this.beAgility.Size = new System.Drawing.Size(147, 20);
            this.beAgility.TabIndex = 18;
            this.beAgility.Text = "すばやさ";
            this.beAgility.Value = 8;
            this.beAgility.WizFCState = this.wizNesState1;
            // 
            // beLuck
            // 
            this.beLuck.ArrowWidth = 10;
            this.beLuck.BackColor = System.Drawing.Color.Black;
            this.beLuck.CaptionLeft = false;
            this.beLuck.CaptionWidth = 100;
            this.beLuck.Font = new System.Drawing.Font("ＭＳ ゴシック", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.beLuck.ForeColor = System.Drawing.Color.White;
            this.beLuck.IsEdit = true;
            this.beLuck.Location = new System.Drawing.Point(286, 360);
            this.beLuck.Mode = WizEdit.WizByteEditMode.Luck;
            this.beLuck.Name = "beLuck";
            this.beLuck.Size = new System.Drawing.Size(147, 20);
            this.beLuck.TabIndex = 19;
            this.beLuck.Text = "うんのつよさ";
            this.beLuck.Value = 9;
            this.beLuck.WizFCState = this.wizNesState1;
            // 
            // wizCharName1
            // 
            this.wizCharName1.BackColor = System.Drawing.Color.Black;
            this.wizCharName1.ForeColor = System.Drawing.Color.White;
            this.wizCharName1.IsEdit = false;
            this.wizCharName1.Location = new System.Drawing.Point(282, 100);
            this.wizCharName1.Name = "wizCharName1";
            this.wizCharName1.Size = new System.Drawing.Size(144, 20);
            this.wizCharName1.TabIndex = 4;
            this.wizCharName1.Text = "wizCharName1";
            this.wizCharName1.WizNesState = this.wizNesState1;
            // 
            // wizCharClass1
            // 
            this.wizCharClass1.AlgWidth = 25;
            this.wizCharClass1.BackColor = System.Drawing.Color.Black;
            this.wizCharClass1.ClassWidth = 35;
            this.wizCharClass1.ForeColor = System.Drawing.Color.White;
            this.wizCharClass1.Location = new System.Drawing.Point(538, 99);
            this.wizCharClass1.Name = "wizCharClass1";
            this.wizCharClass1.RaceWidth = 50;
            this.wizCharClass1.Size = new System.Drawing.Size(118, 23);
            this.wizCharClass1.TabIndex = 6;
            this.wizCharClass1.Text = "wizCharClass1";
            this.wizCharClass1.WizNesState = this.wizNesState1;
            // 
            // leLevel
            // 
            this.leLevel.ArrowHeight = 5;
            this.leLevel.BackColor = System.Drawing.Color.Black;
            this.leLevel.ClearWidth = 10;
            this.leLevel.ForeColor = System.Drawing.Color.White;
            this.leLevel.IsEdit = false;
            this.leLevel.Location = new System.Drawing.Point(432, 95);
            this.leLevel.Mode = WizEdit.WizLongEditMode.Level;
            this.leLevel.Name = "leLevel";
            this.leLevel.NumWidth = 10;
            this.leLevel.Size = new System.Drawing.Size(92, 30);
            this.leLevel.TabIndex = 5;
            this.leLevel.Text = "L";
            this.leLevel.Value = ((ulong)(1ul));
            this.leLevel.WizFCState = this.wizNesState1;
            // 
            // wizItemSelect1
            // 
            this.wizItemSelect1.BackColor = System.Drawing.Color.Black;
            this.wizItemSelect1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wizItemSelect1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wizItemSelect1.ForeColor = System.Drawing.Color.White;
            this.wizItemSelect1.IsListMode = false;
            this.wizItemSelect1.ItemID = -1;
            this.wizItemSelect1.Location = new System.Drawing.Point(0, 0);
            this.wizItemSelect1.Name = "wizItemSelect1";
            this.wizItemSelect1.Size = new System.Drawing.Size(0, 21);
            this.wizItemSelect1.TabIndex = 0;
            // 
            // wizMPList1
            // 
            this.wizMPList1.BackColor = System.Drawing.Color.Black;
            this.wizMPList1.ForeColor = System.Drawing.Color.White;
            this.wizMPList1.IsEdit = false;
            this.wizMPList1.IsEditSpell = false;
            this.wizMPList1.Location = new System.Drawing.Point(455, 311);
            this.wizMPList1.Name = "wizMPList1";
            this.wizMPList1.Size = new System.Drawing.Size(190, 67);
            this.wizMPList1.TabIndex = 22;
            this.wizMPList1.Text = "wizMPList1";
            this.wizMPList1.WizNesState = this.wizNesState1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(596, 512);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // wizScnComb1
            // 
            this.wizScnComb1.BackColor = System.Drawing.Color.Black;
            this.wizScnComb1.Font = new System.Drawing.Font("MS UI Gothic", 8F);
            this.wizScnComb1.ForeColor = System.Drawing.Color.White;
            this.wizScnComb1.Location = new System.Drawing.Point(79, 68);
            this.wizScnComb1.Name = "wizScnComb1";
            this.wizScnComb1.Size = new System.Drawing.Size(106, 17);
            this.wizScnComb1.TabIndex = 26;
            this.wizScnComb1.Text = "wizScnComb1";
            this.wizScnComb1.WIZSCN = WizEdit.WIZSCN.SFC3;
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
            this.ClientSize = new System.Drawing.Size(716, 572);
            this.Controls.Add(this.wizScnComb1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wizMPList1);
            this.Controls.Add(this.wizItemSelect1);
            this.Controls.Add(this.leLevel);
            this.Controls.Add(this.wizCharClass1);
            this.Controls.Add(this.wizCharName1);
            this.Controls.Add(this.wizItemList1);
            this.Controls.Add(this.beLuck);
            this.Controls.Add(this.beAgility);
            this.Controls.Add(this.beIQ);
            this.Controls.Add(this.bePiety);
            this.Controls.Add(this.wizStatus1);
            this.Controls.Add(this.beStrength);
            this.Controls.Add(this.beVitality);
            this.Controls.Add(this.leHPMax);
            this.Controls.Add(this.leHP);
            this.Controls.Add(this.leExp);
            this.Controls.Add(this.leGold);
            this.Controls.Add(this.beAC);
            this.Controls.Add(this.beWeek);
            this.Controls.Add(this.beAge);
            this.Controls.Add(this.wizPictureBox1);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.wizCharList1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.wizConrol1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(638, 606);
            this.Name = "Form1";
            this.Text = "Wizaedry (FC) Editor";
            this.WizAC = this.beAC;
            this.WizAge = this.beAge;
            this.WizAgility = this.beAgility;
            this.WizCharClass = this.wizCharClass1;
            this.WizCharList = this.wizCharList1;
            this.WizCharName = this.wizCharName1;
            this.WizData = this.wizNesState1;
            this.WizEP = this.leExp;
            this.WizGold = this.leGold;
            this.WizHP = this.leHP;
            this.WizHPMax = this.leHPMax;
            this.WizIQ = this.beIQ;
            this.WizItemList = this.wizItemList1;
            this.WizLevel = this.leLevel;
            this.WizLuck = this.beLuck;
            this.WizMPlList = this.wizMPList1;
            this.WizName = this.wizCharName1;
            this.WizPiety = this.bePiety;
            this.WizStatus = this.wizStatus1;
            this.WizStrength = this.beStrength;
            this.WizVitarity = this.beVitality;
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
        private WizData wizNesState1;
        private WizCharList wizCharList1;
        private WizStatus wizStatus1;
        private WizBoxControl wizConrol1;
        private WizItemList wizItemList1;
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
        private WizByteEdit beLuck;
        private WizCharName wizCharName1;
        private WizCharClass wizCharClass1;
        private WizLongEdit leLevel;
        private WizItemSelect wizItemSelect1;
        private WizMPList wizMPList1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pctureFolderToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private WizScnComb wizScnComb1;
    }
}

