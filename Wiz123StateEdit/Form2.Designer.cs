namespace Wiz123StateEdit
{
    partial class Form2
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
            this.chrRace1 = new Wiz123StateEdit.ChrRace();
            this.snes9xWiz123SFC1 = new Wiz123StateEdit.Snes9xWiz123SFC();
            this.chrMPCount1 = new Wiz123StateEdit.ChrMPCount();
            this.chrItemList1 = new Wiz123StateEdit.ChrItemList();
            this.combWizScenario1 = new Wiz123StateEdit.CombWizScenario();
            this.chrStatus1 = new Wiz123StateEdit.ChrStatus();
            this.chrLV = new Wiz123StateEdit.ChrParam();
            this.chrChikara = new Wiz123StateEdit.ChrParam();
            this.chrParam1 = new Wiz123StateEdit.ChrParam();
            this.chrParam2 = new Wiz123StateEdit.ChrParam();
            this.chrParam3 = new Wiz123StateEdit.ChrParam();
            this.chrParam4 = new Wiz123StateEdit.ChrParam();
            this.chrParam5 = new Wiz123StateEdit.ChrParam();
            this.chrParam6 = new Wiz123StateEdit.ChrParam();
            this.shopList1 = new Wiz123StateEdit.ShopList();
            this.SuspendLayout();
            // 
            // chrRace1
            // 
            this.chrRace1.BackColor = System.Drawing.Color.Black;
            this.chrRace1.Enabled = false;
            this.chrRace1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrRace1.Location = new System.Drawing.Point(348, 164);
            this.chrRace1.MaximumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.MinimumSize = new System.Drawing.Size(220, 24);
            this.chrRace1.Name = "chrRace1";
            this.chrRace1.Size = new System.Drawing.Size(220, 24);
            this.chrRace1.TabIndex = 6;
            this.chrRace1.Text = "chrRace1";
            this.chrRace1.Wiz123SFC = this.snes9xWiz123SFC1;
            // 
            // snes9xWiz123SFC1
            // 
            this.snes9xWiz123SFC1.BackColor = System.Drawing.Color.Black;
            this.snes9xWiz123SFC1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.snes9xWiz123SFC1.ForeColor = System.Drawing.Color.White;
            this.snes9xWiz123SFC1.FormattingEnabled = true;
            this.snes9xWiz123SFC1.ItemHeight = 16;
            this.snes9xWiz123SFC1.Location = new System.Drawing.Point(29, 57);
            this.snes9xWiz123SFC1.Name = "snes9xWiz123SFC1";
            this.snes9xWiz123SFC1.Scenario = Wiz123StateEdit.SCENARIO.WIZ1_Proving_Grounds_of_the_Mad_Overlord;
            this.snes9xWiz123SFC1.Size = new System.Drawing.Size(285, 292);
            this.snes9xWiz123SFC1.TabIndex = 0;
            // 
            // chrMPCount1
            // 
            this.chrMPCount1.BackColor = System.Drawing.Color.Black;
            this.chrMPCount1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrMPCount1.Location = new System.Drawing.Point(338, 77);
            this.chrMPCount1.MaximumSize = new System.Drawing.Size(170, 80);
            this.chrMPCount1.MinimumSize = new System.Drawing.Size(170, 80);
            this.chrMPCount1.Name = "chrMPCount1";
            this.chrMPCount1.Size = new System.Drawing.Size(170, 80);
            this.chrMPCount1.TabIndex = 5;
            this.chrMPCount1.Text = "chrMPCount1";
            this.chrMPCount1.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrItemList1
            // 
            this.chrItemList1.BackColor = System.Drawing.Color.Black;
            this.chrItemList1.ForeColor = System.Drawing.Color.White;
            this.chrItemList1.Location = new System.Drawing.Point(348, 241);
            this.chrItemList1.MaximumSize = new System.Drawing.Size(4000, 4000);
            this.chrItemList1.MinimumSize = new System.Drawing.Size(195, 50);
            this.chrItemList1.Name = "chrItemList1";
            this.chrItemList1.Size = new System.Drawing.Size(224, 197);
            this.chrItemList1.TabIndex = 4;
            this.chrItemList1.Text = "chrItemList1";
            this.chrItemList1.Wiz123SFC = this.snes9xWiz123SFC1;
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
            this.combWizScenario1.Location = new System.Drawing.Point(29, 27);
            this.combWizScenario1.MaxDropDownItems = 3;
            this.combWizScenario1.Name = "combWizScenario1";
            this.combWizScenario1.Senario = Wiz123StateEdit.SCENARIO.WIZ1_Proving_Grounds_of_the_Mad_Overlord;
            this.combWizScenario1.Size = new System.Drawing.Size(497, 24);
            this.combWizScenario1.TabIndex = 1;
            this.combWizScenario1.Wiz123SFC = this.snes9xWiz123SFC1;
            // 
            // chrStatus1
            // 
            this.chrStatus1.BackColor = System.Drawing.Color.Black;
            this.chrStatus1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrStatus1.Location = new System.Drawing.Point(578, 92);
            this.chrStatus1.MaximumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.MinimumSize = new System.Drawing.Size(110, 24);
            this.chrStatus1.Name = "chrStatus1";
            this.chrStatus1.Size = new System.Drawing.Size(110, 24);
            this.chrStatus1.TabIndex = 7;
            this.chrStatus1.Text = "chrStatus1";
            this.chrStatus1.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrLV
            // 
            this.chrLV.CaptionWidth = 80;
            this.chrLV.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrLV.Location = new System.Drawing.Point(559, 27);
            this.chrLV.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrLV.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrLV.Mode = Wiz123StateEdit.ChrParam.MODE.LV;
            this.chrLV.Name = "chrLV";
            this.chrLV.Size = new System.Drawing.Size(190, 24);
            this.chrLV.TabIndex = 8;
            this.chrLV.Text = "chrParam1";
            this.chrLV.TextLeft = true;
            this.chrLV.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrChikara
            // 
            this.chrChikara.CaptionWidth = 80;
            this.chrChikara.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrChikara.Location = new System.Drawing.Point(587, 200);
            this.chrChikara.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrChikara.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrChikara.Mode = Wiz123StateEdit.ChrParam.MODE.CHIKARA;
            this.chrChikara.Name = "chrChikara";
            this.chrChikara.Size = new System.Drawing.Size(190, 24);
            this.chrChikara.TabIndex = 9;
            this.chrChikara.Text = "chrParam1";
            this.chrChikara.TextLeft = true;
            this.chrChikara.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrParam1
            // 
            this.chrParam1.CaptionWidth = 80;
            this.chrParam1.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam1.Location = new System.Drawing.Point(587, 230);
            this.chrParam1.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam1.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam1.Mode = Wiz123StateEdit.ChrParam.MODE.CHIE;
            this.chrParam1.Name = "chrParam1";
            this.chrParam1.Size = new System.Drawing.Size(190, 24);
            this.chrParam1.TabIndex = 10;
            this.chrParam1.Text = "chrParam1";
            this.chrParam1.TextLeft = true;
            this.chrParam1.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrParam2
            // 
            this.chrParam2.CaptionWidth = 80;
            this.chrParam2.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam2.Location = new System.Drawing.Point(587, 260);
            this.chrParam2.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam2.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam2.Mode = Wiz123StateEdit.ChrParam.MODE.GOLD;
            this.chrParam2.Name = "chrParam2";
            this.chrParam2.Size = new System.Drawing.Size(190, 24);
            this.chrParam2.TabIndex = 11;
            this.chrParam2.Text = "chrParam2";
            this.chrParam2.TextLeft = true;
            this.chrParam2.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrParam3
            // 
            this.chrParam3.CaptionWidth = 80;
            this.chrParam3.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam3.Location = new System.Drawing.Point(587, 290);
            this.chrParam3.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam3.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam3.Mode = Wiz123StateEdit.ChrParam.MODE.EP;
            this.chrParam3.Name = "chrParam3";
            this.chrParam3.Size = new System.Drawing.Size(190, 24);
            this.chrParam3.TabIndex = 12;
            this.chrParam3.Text = "chrParam3";
            this.chrParam3.TextLeft = true;
            this.chrParam3.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrParam4
            // 
            this.chrParam4.CaptionWidth = 80;
            this.chrParam4.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam4.Location = new System.Drawing.Point(587, 325);
            this.chrParam4.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam4.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam4.Mode = Wiz123StateEdit.ChrParam.MODE.AC;
            this.chrParam4.Name = "chrParam4";
            this.chrParam4.Size = new System.Drawing.Size(190, 24);
            this.chrParam4.TabIndex = 13;
            this.chrParam4.Text = "chrParam4";
            this.chrParam4.TextLeft = true;
            this.chrParam4.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrParam5
            // 
            this.chrParam5.CaptionWidth = 80;
            this.chrParam5.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam5.Location = new System.Drawing.Point(587, 364);
            this.chrParam5.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam5.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam5.Mode = Wiz123StateEdit.ChrParam.MODE.MARKS;
            this.chrParam5.Name = "chrParam5";
            this.chrParam5.Size = new System.Drawing.Size(190, 24);
            this.chrParam5.TabIndex = 14;
            this.chrParam5.Text = "chrParam5";
            this.chrParam5.TextLeft = true;
            this.chrParam5.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // chrParam6
            // 
            this.chrParam6.CaptionWidth = 80;
            this.chrParam6.Font = new System.Drawing.Font("ＭＳ ゴシック", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.chrParam6.Location = new System.Drawing.Point(587, 394);
            this.chrParam6.MaximumSize = new System.Drawing.Size(800, 24);
            this.chrParam6.MinimumSize = new System.Drawing.Size(70, 24);
            this.chrParam6.Mode = Wiz123StateEdit.ChrParam.MODE.RIP;
            this.chrParam6.Name = "chrParam6";
            this.chrParam6.Size = new System.Drawing.Size(190, 24);
            this.chrParam6.TabIndex = 15;
            this.chrParam6.Text = "chrParam6";
            this.chrParam6.TextLeft = true;
            this.chrParam6.Wiz123sfc = this.snes9xWiz123SFC1;
            // 
            // shopList1
            // 
            this.shopList1.FormattingEnabled = true;
            this.shopList1.ItemHeight = 12;
            this.shopList1.Location = new System.Drawing.Point(46, 383);
            this.shopList1.Name = "shopList1";
            this.shopList1.Size = new System.Drawing.Size(268, 172);
            this.shopList1.TabIndex = 16;
            this.shopList1.Wiz123sfc = null;
            // 
            // Form2
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 603);
            this.Controls.Add(this.shopList1);
            this.Controls.Add(this.chrParam6);
            this.Controls.Add(this.chrParam5);
            this.Controls.Add(this.chrParam4);
            this.Controls.Add(this.chrParam3);
            this.Controls.Add(this.chrParam2);
            this.Controls.Add(this.chrParam1);
            this.Controls.Add(this.chrChikara);
            this.Controls.Add(this.chrLV);
            this.Controls.Add(this.chrStatus1);
            this.Controls.Add(this.chrRace1);
            this.Controls.Add(this.chrMPCount1);
            this.Controls.Add(this.chrItemList1);
            this.Controls.Add(this.combWizScenario1);
            this.Controls.Add(this.snes9xWiz123SFC1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Form2";
            this.Text = "Form2";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form2_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form2_DragEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private Snes9xWiz123SFC snes9xWiz123SFC1;
        private CombWizScenario combWizScenario1;
        private ChrItemList chrItemList1;
        private ChrMPCount chrMPCount1;
        private ChrRace chrRace1;
        private ChrStatus chrStatus1;
        private ChrParam chrLV;
        private ChrParam chrChikara;
        private ChrParam chrParam1;
        private ChrParam chrParam2;
        private ChrParam chrParam3;
        private ChrParam chrParam4;
        private ChrParam chrParam5;
        private ChrParam chrParam6;
        private ShopList shopList1;
    }
}