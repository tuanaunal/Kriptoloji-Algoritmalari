namespace KriptoOdev
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtSonuc = new System.Windows.Forms.RichTextBox();
            this.txtGiris = new System.Windows.Forms.RichTextBox();
            this.cmbYontem = new System.Windows.Forms.ComboBox();
            this.txtAnahtar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSifrele = new System.Windows.Forms.Button();
            this.btnCoz = new System.Windows.Forms.Button();
            this.txtAliciEmail = new System.Windows.Forms.TextBox();
            this.btnEpostaGonder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEpostaAl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtSonuc
            // 
            this.txtSonuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSonuc.Location = new System.Drawing.Point(248, 294);
            this.txtSonuc.Name = "txtSonuc";
            this.txtSonuc.Size = new System.Drawing.Size(542, 84);
            this.txtSonuc.TabIndex = 0;
            this.txtSonuc.Text = "";
            // 
            // txtGiris
            // 
            this.txtGiris.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtGiris.Location = new System.Drawing.Point(248, 23);
            this.txtGiris.Name = "txtGiris";
            this.txtGiris.Size = new System.Drawing.Size(542, 83);
            this.txtGiris.TabIndex = 1;
            this.txtGiris.Text = "";
            // 
            // cmbYontem
            // 
            this.cmbYontem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cmbYontem.FormattingEnabled = true;
            this.cmbYontem.Items.AddRange(new object[] {
            "Kaydırmalı şifreleme",
            "Doğrusal şifreleme",
            "Yer değiştirme şifreleme",
            "Sayı anahtarlı şifreleme",
            "Permütasyon şifreleme",
            "Rota şifreleme",
            "Zigzag şifreleme",
            "Vigenere şifreleme",
            "Hill şifreleme",
            "4 Kare şifreleme",
            "RSA şifreleme"});
            this.cmbYontem.Location = new System.Drawing.Point(248, 137);
            this.cmbYontem.Name = "cmbYontem";
            this.cmbYontem.Size = new System.Drawing.Size(237, 28);
            this.cmbYontem.TabIndex = 2;
            this.cmbYontem.SelectedIndexChanged += new System.EventHandler(this.cmbYontem_SelectedIndexChanged);
            // 
            // txtAnahtar
            // 
            this.txtAnahtar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAnahtar.Location = new System.Drawing.Point(248, 187);
            this.txtAnahtar.Name = "txtAnahtar";
            this.txtAnahtar.Size = new System.Drawing.Size(237, 27);
            this.txtAnahtar.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(159, 187);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Anahtar:";
            // 
            // btnSifrele
            // 
            this.btnSifrele.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnSifrele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSifrele.Location = new System.Drawing.Point(540, 238);
            this.btnSifrele.Name = "btnSifrele";
            this.btnSifrele.Size = new System.Drawing.Size(122, 28);
            this.btnSifrele.TabIndex = 5;
            this.btnSifrele.Text = "ŞİFRELE";
            this.btnSifrele.UseVisualStyleBackColor = false;
            this.btnSifrele.Click += new System.EventHandler(this.btnSifrele_Click);
            // 
            // btnCoz
            // 
            this.btnCoz.BackColor = System.Drawing.Color.PaleGreen;
            this.btnCoz.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCoz.Location = new System.Drawing.Point(668, 238);
            this.btnCoz.Name = "btnCoz";
            this.btnCoz.Size = new System.Drawing.Size(122, 28);
            this.btnCoz.TabIndex = 6;
            this.btnCoz.Text = "ÇÖZ";
            this.btnCoz.UseVisualStyleBackColor = false;
            this.btnCoz.Click += new System.EventHandler(this.btnCoz_Click);
            // 
            // txtAliciEmail
            // 
            this.txtAliciEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtAliciEmail.Location = new System.Drawing.Point(248, 420);
            this.txtAliciEmail.Name = "txtAliciEmail";
            this.txtAliciEmail.Size = new System.Drawing.Size(542, 27);
            this.txtAliciEmail.TabIndex = 8;
            // 
            // btnEpostaGonder
            // 
            this.btnEpostaGonder.BackColor = System.Drawing.Color.LightSalmon;
            this.btnEpostaGonder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEpostaGonder.Location = new System.Drawing.Point(584, 474);
            this.btnEpostaGonder.Name = "btnEpostaGonder";
            this.btnEpostaGonder.Size = new System.Drawing.Size(206, 28);
            this.btnEpostaGonder.TabIndex = 9;
            this.btnEpostaGonder.Text = "E-POSTA İLE GÖNDER";
            this.btnEpostaGonder.UseVisualStyleBackColor = false;
            this.btnEpostaGonder.Click += new System.EventHandler(this.btnEpostaGonder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(114, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Yöntem Seçin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(52, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(179, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Şifrelenecek Metin:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(64, 294);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(167, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Şifrelenmiş Metin:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(91, 423);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "E-posta İşlemleri:";
            // 
            // btnEpostaAl
            // 
            this.btnEpostaAl.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnEpostaAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEpostaAl.Location = new System.Drawing.Point(584, 518);
            this.btnEpostaAl.Name = "btnEpostaAl";
            this.btnEpostaAl.Size = new System.Drawing.Size(206, 28);
            this.btnEpostaAl.TabIndex = 14;
            this.btnEpostaAl.Text = "E-POSTALARI AL";
            this.btnEpostaAl.UseVisualStyleBackColor = false;
            this.btnEpostaAl.Click += new System.EventHandler(this.btnEpostaAl_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ClientSize = new System.Drawing.Size(835, 580);
            this.Controls.Add(this.btnEpostaAl);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnEpostaGonder);
            this.Controls.Add(this.txtAliciEmail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCoz);
            this.Controls.Add(this.btnSifrele);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAnahtar);
            this.Controls.Add(this.cmbYontem);
            this.Controls.Add(this.txtGiris);
            this.Controls.Add(this.txtSonuc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSonuc;
        private System.Windows.Forms.RichTextBox txtGiris;
        private System.Windows.Forms.ComboBox cmbYontem;
        private System.Windows.Forms.TextBox txtAnahtar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSifrele;
        private System.Windows.Forms.Button btnCoz;
        private System.Windows.Forms.TextBox txtAliciEmail;
        private System.Windows.Forms.Button btnEpostaGonder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEpostaAl;
    }
}

