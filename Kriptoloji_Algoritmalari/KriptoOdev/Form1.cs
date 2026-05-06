using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace KriptoOdev
{
    public partial class Form1 : Form
    {
        private readonly string _alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ"; // 29 Karakter

        public Form1()
        {
            InitializeComponent();
        }

        private string Temizle(string metin)
        {
            if (string.IsNullOrEmpty(metin)) return "";
            metin = metin.Replace("i", "İ").Replace("ı", "I").ToUpper();
            string sonuc = "";
            foreach (char c in metin) if (_alfabe.Contains(c)) sonuc += c;
            return sonuc;
        }

        #region KRİPTOLOJİ MOTORU

        private string Kaydirmali(string m, int k, bool sifrele)
        {
            string s = "";
            foreach (char c in m)
            {
                int i = _alfabe.IndexOf(c);
                int yeni = sifrele ? (i + k) % 29 : (i - (k % 29) + 29) % 29;
                s += _alfabe[yeni];
            }
            return s;
        }

        private string Dogrusal(string m, int k, bool sifrele)
        {
            string s = "";
            int a = 3, aTersi = 10;
            foreach (char c in m)
            {
                int x = _alfabe.IndexOf(c);
                int yeni = sifrele ? (a * x + k) % 29 : (aTersi * (x - (k % 29) + 29)) % 29;
                s += _alfabe[yeni % 29];
            }
            return s;
        }

        private string Vigenere(string m, string anahtar, bool sifrele)
        {
            string s = "";
            anahtar = Temizle(anahtar);
            if (string.IsNullOrEmpty(anahtar)) anahtar = "ANAHTAR";
            for (int i = 0; i < m.Length; i++)
            {
                int metinIdx = _alfabe.IndexOf(m[i]);
                int anahtarIdx = _alfabe.IndexOf(anahtar[i % anahtar.Length]);
                int yeni = sifrele ? (metinIdx + anahtarIdx) % 29 : (metinIdx - anahtarIdx + 29) % 29;
                s += _alfabe[yeni];
            }
            return s;
        }

        private string Hill(string m, bool sifrele)
        {
            int[,] mat = sifrele ? new int[,] { { 3, 3 }, { 2, 5 } } : new int[,] { { 15, 20 }, { 17, 10 } };
            if (m.Length % 2 != 0) m += "X";
            string s = "";
            for (int i = 0; i < m.Length; i += 2)
            {
                int x1 = _alfabe.IndexOf(m[i]), x2 = _alfabe.IndexOf(m[i + 1]);
                s += _alfabe[(mat[0, 0] * x1 + mat[0, 1] * x2) % 29];
                s += _alfabe[(mat[1, 0] * x1 + mat[1, 1] * x2) % 29];
            }
            return s;
        }

        private string DortKare(string m)
        {
            char[,] matris = {
                {'A','B','C','Ç','D','E'}, {'F','G','Ğ','H','I','İ'},
                {'J','K','L','M','N','O'}, {'Ö','P','R','S','Ş','T'},
                {'U','Ü','V','Y','Z','X'}
            };
            if (m.Length % 2 != 0) m += "X";
            string s = "";
            for (int i = 0; i < m.Length; i += 2)
            {
                int r1 = 0, c1 = 0, r2 = 0, c2 = 0;
                for (int r = 0; r < 5; r++)
                    for (int c = 0; c < 6; c++)
                    {
                        if (matris[r, c] == m[i]) { r1 = r; c1 = c; }
                        if (matris[r, c] == m[i + 1]) { r2 = r; c2 = c; }
                    }
                s += matris[r1, c2]; s += matris[r2, c1];
            }
            return s;
        }

        private string SayiAnahtar(string m, int k, bool sifrele)
        {
            int sutun = k;
            int satir = (int)Math.Ceiling((double)m.Length / sutun);
            char[,] matris = new char[satir, sutun];
            if (sifrele)
            {
                int idx = 0;
                for (int i = 0; i < satir; i++)
                    for (int j = 0; j < sutun; j++)
                        matris[i, j] = (idx < m.Length) ? m[idx++] : 'X';
                string s = "";
                for (int j = 0; j < sutun; j++)
                    for (int i = 0; i < satir; i++) s += matris[i, j];
                return s;
            }
            else
            {
                int idx = 0;
                for (int j = 0; j < sutun; j++)
                    for (int i = 0; i < satir; i++)
                        matris[i, j] = (idx < m.Length) ? m[idx++] : 'X';
                string s = "";
                for (int i = 0; i < satir; i++)
                    for (int j = 0; j < sutun; j++) s += matris[i, j];
                return s.Replace("X", "");
            }
        }

        private string Permutasyon(string m)
        {
            char[] arr = m.ToCharArray();
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                char t = arr[i]; arr[i] = arr[i + 1]; arr[i + 1] = t;
            }
            return new string(arr);
        }

        private string Zigzag(string m, bool sifrele)
        {
            if (m.Length < 2) return m;
            if (sifrele)
            {
                string s1 = "", s2 = "";
                for (int i = 0; i < m.Length; i++) if (i % 2 == 0) s1 += m[i]; else s2 += m[i];
                return s1 + s2;
            }
            else
            {
                int orta = (m.Length + 1) / 2;
                string s1 = m.Substring(0, orta), s2 = m.Substring(orta);
                string sonuc = "";
                for (int i = 0; i < s1.Length; i++)
                {
                    sonuc += s1[i];
                    if (i < s2.Length) sonuc += s2[i];
                }
                return sonuc;
            }
        }

        #endregion

        private void IslemYap(bool sifrele)
        {
            try
            {
                if (cmbYontem.SelectedItem == null) return;
                string m = sifrele ? Temizle(txtGiris.Text) : txtGiris.Text.ToUpper().Trim();
                string anahtarMetin = txtAnahtar.Text;
                int k = int.TryParse(anahtarMetin, out int val) ? val : 3;
                string secim = cmbYontem.SelectedItem.ToString();
                string sonuc = "";

                if (secim.Contains("Kaydırmalı")) sonuc = Kaydirmali(m, k, sifrele);
                else if (secim.Contains("Doğrusal")) sonuc = Dogrusal(m, k, sifrele);
                else if (secim.Contains("Vigenere")) sonuc = Vigenere(m, anahtarMetin, sifrele);
                else if (secim.Contains("Hill")) sonuc = Hill(m, sifrele);
                else if (secim.Contains("4 Kare")) sonuc = DortKare(m);
                else if (secim.Contains("Sayı anahtarlı")) sonuc = SayiAnahtar(m, k, sifrele);
                else if (secim.Contains("Permütasyon")) sonuc = Permutasyon(m);
                else if (secim.Contains("Zigzag")) sonuc = Zigzag(m, sifrele);
                else if (secim.Contains("Yer değiştirme")) sonuc = new string(m.Select(c => _alfabe[28 - _alfabe.IndexOf(c)]).ToArray());
                else if (secim.Contains("Rota")) { char[] a = m.ToCharArray(); Array.Reverse(a); sonuc = new string(a); }

                txtSonuc.Text = sonuc;
            }
            catch { MessageBox.Show("Girişleri kontrol edin!"); }
        }

        // Tasarım ekranındaki buton bağlantıları için metod isimleri:
        private void btnSifrele_Click(object sender, EventArgs e) => IslemYap(true);
        private void btnCoz_Click(object sender, EventArgs e) => IslemYap(false);
        private void btnEpostaGonder_Click(object sender, EventArgs e)
        {
            try
            {
                using (SmtpClient sc = new SmtpClient("smtp.gmail.com", 587))
                {
                    sc.Credentials = new NetworkCredential("tuanaaunall10@gmail.com", "urve czcc efcm nqcw");
                    sc.EnableSsl = true;
                    MailMessage mail = new MailMessage("tuanaaunall10@gmail.com", txtAliciEmail.Text, "Şifreli Mesaj", txtSonuc.Text);
                    sc.Send(mail);
                }
                MessageBox.Show("Gönderildi!");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }
        private void btnEpostaAl_Click(object sender, EventArgs e) => MessageBox.Show("E-postalar alınıyor...");

        // Hata listesindeki cmbYontem_SelectedIndexChanged hatasını gideren metod:
        private void cmbYontem_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}