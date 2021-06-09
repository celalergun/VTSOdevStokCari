
namespace VTSOdevStokCari
{
    partial class AnaForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kartlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stokKartlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hareketlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.malGirişçıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kartlarToolStripMenuItem,
            this.hareketlerToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kartlarToolStripMenuItem
            // 
            this.kartlarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stokKartlarıToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.çıkışToolStripMenuItem});
            this.kartlarToolStripMenuItem.Name = "kartlarToolStripMenuItem";
            this.kartlarToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.kartlarToolStripMenuItem.Text = "Kartlar";
            // 
            // stokKartlarıToolStripMenuItem
            // 
            this.stokKartlarıToolStripMenuItem.Name = "stokKartlarıToolStripMenuItem";
            this.stokKartlarıToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stokKartlarıToolStripMenuItem.Text = "Stok kartları";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem1.Text = "Müşteri kartları";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            this.çıkışToolStripMenuItem.Click += new System.EventHandler(this.çıkışToolStripMenuItem_Click);
            // 
            // hareketlerToolStripMenuItem
            // 
            this.hareketlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.malGirişçıkışToolStripMenuItem});
            this.hareketlerToolStripMenuItem.Name = "hareketlerToolStripMenuItem";
            this.hareketlerToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.hareketlerToolStripMenuItem.Text = "Hareketler";
            // 
            // malGirişçıkışToolStripMenuItem
            // 
            this.malGirişçıkışToolStripMenuItem.Name = "malGirişçıkışToolStripMenuItem";
            this.malGirişçıkışToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.malGirişçıkışToolStripMenuItem.Text = "Fatura";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AnaForm";
            this.Text = "Veri Tabanı Sistemleri Proje Ödevi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kartlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stokKartlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hareketlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem malGirişçıkışToolStripMenuItem;
    }
}

