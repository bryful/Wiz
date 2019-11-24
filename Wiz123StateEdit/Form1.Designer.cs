namespace Wiz123StateEdit
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
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chrMPCount1 = new Wiz123StateEdit.ChrMPCount();
            this.snes9xWizFive1 = new Wiz123StateEdit.Snes9xWiz123SFC();
            this.chrHP1 = new Wiz123StateEdit.ChrHP();
            this.chrItemList1 = new Wiz123StateEdit.ChrItemList();
            this.chrStatus1 = new Wiz123StateEdit.ChrStatus();
            this.chrParam14 = new Wiz123StateEdit.ChrParam();
            this.chrParam13 = new Wiz123StateEdit.ChrParam();
            this.chrParam12 = new Wiz123StateEdit.ChrParam();
            this.chrParam11 = new Wiz123StateEdit.ChrParam();
            this.chrParam10 = new Wiz123StateEdit.ChrParam();
            this.chrParam9 = new Wiz123StateEdit.ChrParam();
            this.chrParam8 = new Wiz123StateEdit.ChrParam();
            this.chrParam6 = new Wiz123StateEdit.ChrParam();
            this.chrParam5 = new Wiz123StateEdit.ChrParam();
            this.chrParam4 = new Wiz123StateEdit.ChrParam();
            this.chrParam3 = new Wiz123StateEdit.ChrParam();
            this.chrParam2 = new Wiz123StateEdit.ChrParam();
            this.chrRace1 = new Wiz123StateEdit.ChrRace();
            this.chrParam1 = new Wiz123StateEdit.ChrParam();
            this.shopList1 = new Wiz123StateEdit.ShopList();
            this.combWizScenario1 = new Wiz123StateEdit.CombWizScenario();
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
            this.openToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // chrMPCount1
            // 
            this.chrMPCount1.BackColor = System.Drawing.Color.Black;
            this.chrMPCount1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrMPCount1.Location = new System.Drawing.Point(411, 355);
            this.chrMPCount1.MaximumSize = new System.Drawing.Size(170, 80);
            this.chrMPCount1.MinimumSize = new System.Drawing.Size(170, 80);
            this.chrMPCount1.Name = "chrMPCount1";
            this.chrMPCount1.Size = new System.Drawing.Size(170, 80);
            this.chrMPCount1.TabIndex = 23;
            this.chrMPCount1.Text = "chrMPCount1";
            this.chrMPCount1.Wiz123sfc = this.snes9xWizFive1;
            // 
            // snes9xWizFive1
            // 
            this.snes9xWizFive1.BackColor = System.Drawing.Color.Black;
            this.snes9xWizFive1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.snes9xWizFive1.ForeColor = System.Drawing.Color.White;
            this.snes9xWizFive1.FormattingEnabled = true;
            this.snes9xWizFive1.ItemHeight = 16;
            this.snes9xWizFive1.Location = new System.Drawing.Point(12, 83);
            this.snes9xWizFive1.Name = "snes9xWizFive1";
            this.snes9xWizFive1.Scenario = Wiz123StateEdit.SCENARIO.WIZ1_Proving_Grounds_of_the_Mad_Overlord;
            this.snes9xWizFive1.Size = new System.Drawing.Size(228, 276);
            this.snes9xWizFive1.TabIndex = 0;
            // 
            // chrHP1
            // 
            this.chrHP1.BackColor = System.Drawing.Color.Black;
            this.chrHP1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrHP1.ForeColor = System.Drawing.Color.White;
            this.chrHP1.Location = new System.Drawing.Point(259, 167);
            this.chrHP1.MaximumSize = new System.Drawing.Size(900, 50);
            this.chrHP1.MinimumSize = new System.Drawing.Size(100, 50);
            this.chrHP1.Name = "chrHP1";
            this.chrHP1.Size = new System.Drawing.Size(180, 50);
            this.chrHP1.TabIndex = 22;
            this.chrHP1.Text = "chrHP1";
            this.chrHP1.Wiz123SFC = this.snes9xWizFive1;
            // 
            // chrItemList1
            // 
            this.chrItemList1.BackColor = System.Drawing.Color.Black;
            this.chrItemList1.ForeColor = System.Drawing.Color.White;
            this.chrItemList1.Location = new System.Drawing.Point(12, 365);
            this.chrItemList1.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.chrItemList1.MinimumSize = new System.Drawing.Size(195, 50);
            this.chrItemList1.Name = "chrItemList1";
            this.chrItemList1.Size = new System.Drawing.Size(228, 175);
            this.chrItemList1.TabIndex = 19;
            this.chrItemList1.Text = "chrItemList1";
            this.chrItemList1.Wiz123SFC = this.snes9xWizFive1;
            // 
            // chrStatus1
            // 
            this.chrStatus1.BackColor = System.Drawing.Color.Black;
            this.chrStatus1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrStatus1.Location = new System.Drawing.Point(462, 167);
            this.chrStatus1.MaximumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.MinimumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.Name = "chrStatus1";
            this.chrStatus1.Size = new System.Drawing.Size(110, 24);
            this.chrStatus1.TabIndex = 17;
            this.chrStatus1.Text = "chrStatus1";
            this.chrStatus1.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam14
            // 
            this.chrParam14.CaptionWidth = 75;
            this.chrParam14.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam14.Location = new System.Drawing.Point(259, 505);
            this.chrParam14.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam14.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam14.Mode = Wiz123StateEdit.ChrParam.MODE.UN;
            this.chrParam14.Name = "chrParam14";
            this.chrParam14.Size = new System.Drawing.Size(130, 24);
            this.chrParam14.TabIndex = 16;
            this.chrParam14.Text = "chrParam14";
            this.chrParam14.TextLeft = false;
            this.chrParam14.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam13
            // 
            this.chrParam13.CaptionWidth = 75;
            this.chrParam13.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam13.Location = new System.Drawing.Point(259, 475);
            this.chrParam13.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam13.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam13.Mode = Wiz123StateEdit.ChrParam.MODE.SUBAYASA;
            this.chrParam13.Name = "chrParam13";
            this.chrParam13.Size = new System.Drawing.Size(130, 24);
            this.chrParam13.TabIndex = 15;
            this.chrParam13.Text = "chrParam13";
            this.chrParam13.TextLeft = false;
            this.chrParam13.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam12
            // 
            this.chrParam12.CaptionWidth = 75;
            this.chrParam12.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam12.Location = new System.Drawing.Point(259, 445);
            this.chrParam12.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam12.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam12.Mode = Wiz123StateEdit.ChrParam.MODE.SEIMEI;
            this.chrParam12.Name = "chrParam12";
            this.chrParam12.Size = new System.Drawing.Size(130, 24);
            this.chrParam12.TabIndex = 14;
            this.chrParam12.Text = "chrParam12";
            this.chrParam12.TextLeft = false;
            this.chrParam12.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam11
            // 
            this.chrParam11.CaptionWidth = 75;
            this.chrParam11.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam11.Location = new System.Drawing.Point(259, 415);
            this.chrParam11.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam11.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam11.Mode = Wiz123StateEdit.ChrParam.MODE.SINKOSIN;
            this.chrParam11.Name = "chrParam11";
            this.chrParam11.Size = new System.Drawing.Size(130, 24);
            this.chrParam11.TabIndex = 13;
            this.chrParam11.Text = "chrParam11";
            this.chrParam11.TextLeft = false;
            this.chrParam11.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam10
            // 
            this.chrParam10.CaptionWidth = 75;
            this.chrParam10.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam10.Location = new System.Drawing.Point(259, 385);
            this.chrParam10.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam10.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam10.Mode = Wiz123StateEdit.ChrParam.MODE.CHIE;
            this.chrParam10.Name = "chrParam10";
            this.chrParam10.Size = new System.Drawing.Size(130, 24);
            this.chrParam10.TabIndex = 12;
            this.chrParam10.Text = "chrParam10";
            this.chrParam10.TextLeft = false;
            this.chrParam10.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam9
            // 
            this.chrParam9.CaptionWidth = 75;
            this.chrParam9.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam9.Location = new System.Drawing.Point(259, 355);
            this.chrParam9.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam9.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam9.Mode = Wiz123StateEdit.ChrParam.MODE.CHIKARA;
            this.chrParam9.Name = "chrParam9";
            this.chrParam9.Size = new System.Drawing.Size(130, 24);
            this.chrParam9.TabIndex = 11;
            this.chrParam9.Text = "chrParam9";
            this.chrParam9.TextLeft = false;
            this.chrParam9.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam8
            // 
            this.chrParam8.CaptionWidth = 50;
            this.chrParam8.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam8.Location = new System.Drawing.Point(478, 292);
            this.chrParam8.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam8.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam8.Mode = Wiz123StateEdit.ChrParam.MODE.RIP;
            this.chrParam8.Name = "chrParam8";
            this.chrParam8.Size = new System.Drawing.Size(94, 24);
            this.chrParam8.TabIndex = 9;
            this.chrParam8.Text = "chrParam8";
            this.chrParam8.TextLeft = true;
            this.chrParam8.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam6
            // 
            this.chrParam6.CaptionWidth = 50;
            this.chrParam6.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam6.Location = new System.Drawing.Point(478, 262);
            this.chrParam6.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam6.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam6.Mode = Wiz123StateEdit.ChrParam.MODE.AC;
            this.chrParam6.Name = "chrParam6";
            this.chrParam6.Size = new System.Drawing.Size(94, 24);
            this.chrParam6.TabIndex = 7;
            this.chrParam6.Text = "chrParam6";
            this.chrParam6.TextLeft = true;
            this.chrParam6.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam5
            // 
            this.chrParam5.CaptionWidth = 50;
            this.chrParam5.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam5.Location = new System.Drawing.Point(478, 232);
            this.chrParam5.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam5.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam5.Mode = Wiz123StateEdit.ChrParam.MODE.NENEI;
            this.chrParam5.Name = "chrParam5";
            this.chrParam5.Size = new System.Drawing.Size(94, 24);
            this.chrParam5.TabIndex = 6;
            this.chrParam5.Text = "chrParam5";
            this.chrParam5.TextLeft = true;
            this.chrParam5.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam4
            // 
            this.chrParam4.CaptionWidth = 80;
            this.chrParam4.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam4.Location = new System.Drawing.Point(259, 292);
            this.chrParam4.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam4.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam4.Mode = Wiz123StateEdit.ChrParam.MODE.MARKS;
            this.chrParam4.Name = "chrParam4";
            this.chrParam4.Size = new System.Drawing.Size(202, 24);
            this.chrParam4.TabIndex = 5;
            this.chrParam4.Text = "chrParam4";
            this.chrParam4.TextLeft = true;
            this.chrParam4.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam3
            // 
            this.chrParam3.CaptionWidth = 80;
            this.chrParam3.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam3.Location = new System.Drawing.Point(259, 262);
            this.chrParam3.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam3.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam3.Mode = Wiz123StateEdit.ChrParam.MODE.GOLD;
            this.chrParam3.Name = "chrParam3";
            this.chrParam3.Size = new System.Drawing.Size(202, 24);
            this.chrParam3.TabIndex = 4;
            this.chrParam3.Text = "chrParam3";
            this.chrParam3.TextLeft = true;
            this.chrParam3.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrParam2
            // 
            this.chrParam2.CaptionWidth = 80;
            this.chrParam2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam2.Location = new System.Drawing.Point(259, 232);
            this.chrParam2.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam2.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam2.Mode = Wiz123StateEdit.ChrParam.MODE.EP;
            this.chrParam2.Name = "chrParam2";
            this.chrParam2.Size = new System.Drawing.Size(202, 24);
            this.chrParam2.TabIndex = 3;
            this.chrParam2.Text = "chrParam2";
            this.chrParam2.TextLeft = true;
            this.chrParam2.Wiz123sfc = this.snes9xWizFive1;
            // 
            // chrRace1
            // 
            this.chrRace1.BackColor = System.Drawing.Color.Black;
            this.chrRace1.Enabled = false;
            this.chrRace1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrRace1.Location = new System.Drawing.Point(352, 123);
            this.chrRace1.MaximumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.MinimumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.Name = "chrRace1";
            this.chrRace1.Size = new System.Drawing.Size(220, 24);
            this.chrRace1.TabIndex = 2;
            this.chrRace1.Text = "chrRace1";
            this.chrRace1.Wiz123SFC = this.snes9xWizFive1;
            // 
            // chrParam1
            // 
            this.chrParam1.CaptionWidth = 80;
            this.chrParam1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam1.Location = new System.Drawing.Point(259, 83);
            this.chrParam1.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam1.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam1.Mode = Wiz123StateEdit.ChrParam.MODE.LV;
            this.chrParam1.Name = "chrParam1";
            this.chrParam1.Size = new System.Drawing.Size(313, 24);
            this.chrParam1.TabIndex = 1;
            this.chrParam1.Text = "chrParam1";
            this.chrParam1.TextLeft = true;
            this.chrParam1.Wiz123sfc = this.snes9xWizFive1;
            // 
            // shopList1
            // 
            this.shopList1.BackColor = System.Drawing.Color.Black;
            this.shopList1.ForeColor = System.Drawing.Color.White;
            this.shopList1.FormattingEnabled = true;
            this.shopList1.ItemHeight = 12;
            this.shopList1.Items.AddRange(new object[] {
            "00: 00:ガラクタ",
            "00: 01:けん",
            "00: 02:たんけん",
            "00: 03:メイス",
            "00: 04:フレイル",
            "00: 05:つえ",
            "00: 06:たんとう",
            "00: 07:こがたのたて",
            "00: 08:たて",
            "00: 09:ローブ",
            "00: 0A:かわのよろい",
            "00: 0B:くさりかたびら",
            "00: 0C:むねあて",
            "00: 0D:よろい",
            "00: 0E:かぶと",
            "00: 0F:ちりょうのくすり",
            "00: 10:どくけしのくすり",
            "00: 11:きりさきのけん",
            "00: 12:よいたんけん",
            "00: 13:ふんさいのメイス",
            "00: 14:てつのつえ",
            "00: 15:ねむりのまきもの",
            "00: 16:かたいかわよろい",
            "00: 17:ひかるくさりかたびら",
            "00: 18:ますらおのよろい",
            "00: 19:てつのたて",
            "00: 1A:どうよろい",
            "00: 1B:くつうのまきもの",
            "00: 1C:ほのおのまきもの",
            "00: 1D:なまくらなけん",
            "00: 1E:げんめつのたんけん",
            "00: 1F:わざわいのメイス",
            "00: 20:かたいつえ",
            "00: 21:ドラゴンスレイヤー",
            "00: 22:にんたいのかぶと",
            "00: 23:くさったかわよろい",
            "00: 24:さびたくさりかたびら",
            "00: 25:ひびわれたむねあて",
            "00: 26:ゆがんだたて",
            "00: 27:ほうせきのゆびわ",
            "00: 28:くるしみのまきもの",
            "00: 29:かくれみのくすり",
            "00: 2A:まっぷたつのけん",
            "00: 2B:さいきょうのたんけん",
            "00: 2C:ちからのメイス",
            "00: 2D:あかりのまきもの",
            "00: 2E:くらやみのまきもの",
            "00: 2F:どうのこて",
            "00: 30:ごうかなかわよろい",
            "00: 31:エルフのくさりかたびら",
            "00: 32:ごくじょうのよろい",
            "00: 33:ささえのたて",
            "00: 34:あくのかぶと",
            "00: 35:かいふくのくすり",
            "00: 36:まもりのゆびわ",
            "00: 37:ワースレイヤー",
            "00: 38:メイジマッシャー",
            "00: 39:ヘビのメイス",
            "00: 3A:ちんもくのつえ",
            "00: 3B:カシナートのつるぎ",
            "00: 3C:いましめのゆびわ",
            "00: 3D:ほのおのつえ",
            "00: 3E:あくのくさりかたびら",
            "00: 3F:ちゅうりつのよろい",
            "00: 40:あくのたて",
            "00: 41:ちっそくのゆびわ",
            "00: 42:てんいのかぶと",
            "00: 43:いちげきのまきもの",
            "00: 44:はめつのたんけん",
            "00: 45:きりさきのたんとう",
            "00: 46:やめるメイス",
            "00: 47:ねじれたつえ",
            "00: 48:はやわざのたんとう",
            "00: 49:のろわれたローブ",
            "00: 4A:はめつのかわよろい",
            "00: 4B:のろいのくさりかたびら",
            "00: 4C:あくまのむねあて",
            "00: 4D:うつろのたて",
            "00: 4E:ふるびたかぶと",
            "00: 4F:きぼうのむねあて",
            "00: 50:ぎんのこて",
            "00: 51:あくのサーベル",
            "00: 52:ソウルスレイヤー",
            "00: 53:とうぞくのたんとう",
            "00: 54:えいゆうのよろい",
            "00: 55:せいなるよろい",
            "00: 56:むらまさ",
            "00: 57:しゅりけん",
            "00: 58:こおりのくさりかたびら",
            "00: 59:あくのよろい",
            "00: 5A:まもりのたて",
            "00: 5B:かいふくのゆびわ",
            "00: 5C:はじゃのゆびわ",
            "00: 5D:しのゆびわ",
            "00: 5E:ワードナのまよけ",
            "00: 5F:クマのおきもの",
            "00: 60:カエルのおきもの",
            "00: 61:せいどうのかぎ",
            "00: 62:ぎんのかぎ",
            "00: 63:ぎんのかぎ",
            "00: 64:ブルーリボン"});
            this.shopList1.Location = new System.Drawing.Point(411, 441);
            this.shopList1.Name = "shopList1";
            this.shopList1.Size = new System.Drawing.Size(161, 88);
            this.shopList1.TabIndex = 24;
            this.shopList1.Wiz123sfc = this.snes9xWizFive1;
            // 
            // combWizScenario1
            // 
            this.combWizScenario1.BackColor = System.Drawing.Color.Black;
            this.combWizScenario1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combWizScenario1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.combWizScenario1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.combWizScenario1.ForeColor = System.Drawing.Color.White;
            this.combWizScenario1.FormattingEnabled = true;
            this.combWizScenario1.Items.AddRange(new object[] {
            "WIZ1_Proving_Grounds_of_the_Mad_Overlord",
            "WIZ2_Legacy_of_Llylgamyn",
            "WIZ3_Knight_of_Diamonds"});
            this.combWizScenario1.Location = new System.Drawing.Point(12, 43);
            this.combWizScenario1.MaxDropDownItems = 3;
            this.combWizScenario1.Name = "combWizScenario1";
            this.combWizScenario1.Senario = Wiz123StateEdit.SCENARIO.WIZ1_Proving_Grounds_of_the_Mad_Overlord;
            this.combWizScenario1.Size = new System.Drawing.Size(560, 24);
            this.combWizScenario1.TabIndex = 25;
            this.combWizScenario1.Wiz123SFC = this.snes9xWizFive1;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(593, 563);
            this.Controls.Add(this.combWizScenario1);
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

        private Snes9xWiz123SFC snes9xWizFive1;
        private ChrParam chrParam1;
        private ChrRace chrRace1;
        private ChrParam chrParam2;
        private ChrParam chrParam3;
        private ChrParam chrParam4;
        private ChrParam chrParam5;
        private ChrParam chrParam6;
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
        private CombWizScenario combWizScenario1;
    }
}

