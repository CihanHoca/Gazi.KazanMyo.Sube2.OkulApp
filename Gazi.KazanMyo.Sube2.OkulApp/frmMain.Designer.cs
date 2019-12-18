namespace Gazi.KazanMyo.Sube2.OkulApp
{
    partial class frmMain
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
            this.menuOgrenciIslemleri = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOgrenciKayit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOgrenciListe = new System.Windows.Forms.ToolStripMenuItem();
            this.öğretmenİşlemleriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.çıkışToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.denemeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOgrenciIslemleri,
            this.öğretmenİşlemleriToolStripMenuItem,
            this.çıkışToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuOgrenciIslemleri
            // 
            this.menuOgrenciIslemleri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOgrenciKayit,
            this.menuOgrenciListe});
            this.menuOgrenciIslemleri.Name = "menuOgrenciIslemleri";
            this.menuOgrenciIslemleri.Size = new System.Drawing.Size(108, 20);
            this.menuOgrenciIslemleri.Text = "Öğrenci İşlemleri";
            // 
            // menuOgrenciKayit
            // 
            this.menuOgrenciKayit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.denemeToolStripMenuItem});
            this.menuOgrenciKayit.Name = "menuOgrenciKayit";
            this.menuOgrenciKayit.Size = new System.Drawing.Size(180, 22);
            this.menuOgrenciKayit.Text = "Öğrenci Kayıt";
            this.menuOgrenciKayit.Click += new System.EventHandler(this.MenuOgrenciKayit_Click);
            // 
            // menuOgrenciListe
            // 
            this.menuOgrenciListe.Name = "menuOgrenciListe";
            this.menuOgrenciListe.Size = new System.Drawing.Size(180, 22);
            this.menuOgrenciListe.Text = "Öğrenci Listeleme";
            this.menuOgrenciListe.Click += new System.EventHandler(this.MenuOgrenciListe_Click);
            // 
            // öğretmenİşlemleriToolStripMenuItem
            // 
            this.öğretmenİşlemleriToolStripMenuItem.Name = "öğretmenİşlemleriToolStripMenuItem";
            this.öğretmenİşlemleriToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.öğretmenİşlemleriToolStripMenuItem.Text = "Öğretmen İşlemleri";
            // 
            // çıkışToolStripMenuItem
            // 
            this.çıkışToolStripMenuItem.Name = "çıkışToolStripMenuItem";
            this.çıkışToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.çıkışToolStripMenuItem.Text = "Çıkış";
            // 
            // denemeToolStripMenuItem
            // 
            this.denemeToolStripMenuItem.Name = "denemeToolStripMenuItem";
            this.denemeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.denemeToolStripMenuItem.Text = "deneme";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuOgrenciIslemleri;
        private System.Windows.Forms.ToolStripMenuItem menuOgrenciKayit;
        private System.Windows.Forms.ToolStripMenuItem menuOgrenciListe;
        private System.Windows.Forms.ToolStripMenuItem öğretmenİşlemleriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem çıkışToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem denemeToolStripMenuItem;
    }
}