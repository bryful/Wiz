﻿namespace WizEdit
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.wizNameBox1 = new WizEdit.WizNameBox();
            this.wizNesState1 = new WizEdit.WizNesState();
            this.wizCharList1 = new WizEdit.WizCharList();
            this.wizCaption1 = new WizEdit.WizCaption();
            this.wizConrol1 = new WizEdit.WizConrol();
            this.wizSelectControl1 = new WizEdit.WizSelectControl();
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
            this.menuStrip1.Size = new System.Drawing.Size(851, 24);
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
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 512);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(851, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // wizNameBox1
            // 
            this.wizNameBox1.BackColor = System.Drawing.Color.Black;
            this.wizNameBox1.ForeColor = System.Drawing.Color.White;
            this.wizNameBox1.Location = new System.Drawing.Point(202, 93);
            this.wizNameBox1.MaximumSize = new System.Drawing.Size(150, 24);
            this.wizNameBox1.MinimumSize = new System.Drawing.Size(150, 24);
            this.wizNameBox1.Name = "wizNameBox1";
            this.wizNameBox1.Size = new System.Drawing.Size(150, 24);
            this.wizNameBox1.TabIndex = 14;
            this.wizNameBox1.Text = "wizNameBox1";
            this.wizNameBox1.WizNesState = this.wizNesState1;
            this.wizNameBox1.Click += new System.EventHandler(this.wizNameBox1_Click);
            // 
            // wizNesState1
            // 
            this.wizNesState1.CurrentChar = 1;
            // 
            // wizCharList1
            // 
            this.wizCharList1.BackColor = System.Drawing.Color.Black;
            this.wizCharList1.BottomMargin = 5;
            this.wizCharList1.Corner = 5;
            this.wizCharList1.ForeColor = System.Drawing.Color.White;
            this.wizCharList1.LineWidth = 3;
            this.wizCharList1.Location = new System.Drawing.Point(35, 78);
            this.wizCharList1.MaximumSize = new System.Drawing.Size(150, 400);
            this.wizCharList1.MinimumSize = new System.Drawing.Size(150, 400);
            this.wizCharList1.Name = "wizCharList1";
            this.wizCharList1.SiseMargin = 5;
            this.wizCharList1.Size = new System.Drawing.Size(150, 400);
            this.wizCharList1.TabIndex = 13;
            this.wizCharList1.Text = "wizCharList1";
            this.wizCharList1.TopMargin = 5;
            this.wizCharList1.WizNesState = this.wizNesState1;
            // 
            // wizCaption1
            // 
            this.wizCaption1.BackColor = System.Drawing.Color.Black;
            this.wizCaption1.BottomMargin = 5;
            this.wizCaption1.Corner = 3;
            this.wizCaption1.Font = new System.Drawing.Font("MS UI Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.wizCaption1.ForeColor = System.Drawing.Color.White;
            this.wizCaption1.LineWidth = 3;
            this.wizCaption1.Location = new System.Drawing.Point(307, 27);
            this.wizCaption1.Name = "wizCaption1";
            this.wizCaption1.SiseMargin = 5;
            this.wizCaption1.Size = new System.Drawing.Size(227, 42);
            this.wizCaption1.TabIndex = 10;
            this.wizCaption1.Text = "Wizardry FC StateFile Editor";
            this.wizCaption1.TopMargin = 5;
            // 
            // wizConrol1
            // 
            this.wizConrol1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wizConrol1.BackColor = System.Drawing.Color.Black;
            this.wizConrol1.BottomMargin = 5;
            this.wizConrol1.Corner = 5;
            this.wizConrol1.ForeColor = System.Drawing.Color.White;
            this.wizConrol1.LineWidth = 3;
            this.wizConrol1.Location = new System.Drawing.Point(0, 46);
            this.wizConrol1.Name = "wizConrol1";
            this.wizConrol1.SiseMargin = 5;
            this.wizConrol1.Size = new System.Drawing.Size(839, 463);
            this.wizConrol1.TabIndex = 7;
            this.wizConrol1.Text = "Wizardry NES State Editor";
            this.wizConrol1.TopMargin = 5;
            // 
            // wizSelectControl1
            // 
            this.wizSelectControl1.BackColor = System.Drawing.Color.Black;
            this.wizSelectControl1.BottomMargin = 5;
            this.wizSelectControl1.Corner = 5;
            this.wizSelectControl1.ForeColor = System.Drawing.Color.White;
            this.wizSelectControl1.LineWidth = 3;
            this.wizSelectControl1.Location = new System.Drawing.Point(234, 179);
            this.wizSelectControl1.Name = "wizSelectControl1";
            this.wizSelectControl1.SelectedIndex = -1;
            this.wizSelectControl1.SiseMargin = 5;
            this.wizSelectControl1.Size = new System.Drawing.Size(300, 100);
            this.wizSelectControl1.TabIndex = 15;
            this.wizSelectControl1.Text = "wizSelectControl1";
            this.wizSelectControl1.TopMargin = 5;
            this.wizSelectControl1.Visible = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(851, 534);
            this.Controls.Add(this.wizSelectControl1);
            this.Controls.Add(this.wizNameBox1);
            this.Controls.Add(this.wizCharList1);
            this.Controls.Add(this.wizCaption1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.wizConrol1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private WizCaption wizCaption1;
        private WizConrol wizConrol1;
        private WizNesState wizNesState1;
        private WizCharList wizCharList1;
        private WizNameBox wizNameBox1;
        private WizSelectControl wizSelectControl1;
    }
}

