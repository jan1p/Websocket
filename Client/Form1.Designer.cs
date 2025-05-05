namespace Client
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestArtikel = new System.Windows.Forms.TextBox();
            this.SendenArtikel = new System.Windows.Forms.Button();
            this.Gegeben = new System.Windows.Forms.TextBox();
            this.SendenGegeben = new System.Windows.Forms.Button();
            this.Rueckgeld = new System.Windows.Forms.TextBox();
            this.SendenRueckgeld = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestArtikel
            // 
            this.TestArtikel.Location = new System.Drawing.Point(59, 60);
            this.TestArtikel.Name = "TestArtikel";
            this.TestArtikel.Size = new System.Drawing.Size(420, 20);
            this.TestArtikel.TabIndex = 0;
            this.TestArtikel.Text = "Kasse1#Apfelsaft#2#Liter#1,99#19";
            // 
            // SendenArtikel
            // 
            this.SendenArtikel.Location = new System.Drawing.Point(59, 96);
            this.SendenArtikel.Name = "SendenArtikel";
            this.SendenArtikel.Size = new System.Drawing.Size(75, 23);
            this.SendenArtikel.TabIndex = 1;
            this.SendenArtikel.Text = "Senden";
            this.SendenArtikel.UseVisualStyleBackColor = true;
            this.SendenArtikel.Click += new System.EventHandler(this.SendenArtikel_Click);
            // 
            // Gegeben
            // 
            this.Gegeben.Location = new System.Drawing.Point(59, 139);
            this.Gegeben.Name = "Gegeben";
            this.Gegeben.Size = new System.Drawing.Size(420, 20);
            this.Gegeben.TabIndex = 2;
            this.Gegeben.Text = "Kasse1#gegeben#25";
            // 
            // SendenGegeben
            // 
            this.SendenGegeben.Location = new System.Drawing.Point(59, 174);
            this.SendenGegeben.Name = "SendenGegeben";
            this.SendenGegeben.Size = new System.Drawing.Size(75, 23);
            this.SendenGegeben.TabIndex = 3;
            this.SendenGegeben.Text = "Senden";
            this.SendenGegeben.UseVisualStyleBackColor = true;
            this.SendenGegeben.Click += new System.EventHandler(this.SendenGegeben_Click);
            // 
            // Rueckgeld
            // 
            this.Rueckgeld.Location = new System.Drawing.Point(59, 212);
            this.Rueckgeld.Name = "Rueckgeld";
            this.Rueckgeld.Size = new System.Drawing.Size(420, 20);
            this.Rueckgeld.TabIndex = 4;
            this.Rueckgeld.Text = "Kasse1#rueckgeld#20,99";
            this.Rueckgeld.TextChanged += new System.EventHandler(this.Rueckgeld_TextChanged);
            // 
            // SendenRueckgeld
            // 
            this.SendenRueckgeld.Location = new System.Drawing.Point(59, 238);
            this.SendenRueckgeld.Name = "SendenRueckgeld";
            this.SendenRueckgeld.Size = new System.Drawing.Size(75, 23);
            this.SendenRueckgeld.TabIndex = 5;
            this.SendenRueckgeld.Text = "Senden";
            this.SendenRueckgeld.UseVisualStyleBackColor = true;
            this.SendenRueckgeld.Click += new System.EventHandler(this.SendenRueckgeld_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 286);
            this.Controls.Add(this.SendenRueckgeld);
            this.Controls.Add(this.Rueckgeld);
            this.Controls.Add(this.SendenGegeben);
            this.Controls.Add(this.Gegeben);
            this.Controls.Add(this.SendenArtikel);
            this.Controls.Add(this.TestArtikel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TestArtikel;
        private System.Windows.Forms.Button SendenArtikel;
        private System.Windows.Forms.TextBox Gegeben;
        private System.Windows.Forms.Button SendenGegeben;
        private System.Windows.Forms.TextBox Rueckgeld;
        private System.Windows.Forms.Button SendenRueckgeld;
    }
}

