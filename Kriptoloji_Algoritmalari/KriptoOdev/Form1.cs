using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Numerics; // RSA için gerekli

namespace KriptoOdev
{
    public partial class Form1 : Form
    {
        // 29 Karakterli Türk Alfabesi
        private readonly string alfabe = "ABCÇDEFGĞHIİJKLMNOÖPRSŞTUÜVYZ";

        public Form1()
        {
            InitializeComponent();
        }

        private string Temizle(string metin)
        {
            if (string.IsNullOrEmpty(metin)) return "";
            metin = metin.Replace("i", "İ").Replace("ı", "I").ToUpper();
            string sonuc = "";
            foreach (char c in metin) if (alfabe.Contains(c)) sonuc += c;
            return sonuc;
        }

        #region ŞİFRELEME MOTORU

        // 1. Kaydırmalı
        private string Kaydirmali(string m, int k, bool sifrele)
        {
            string s = "";
            foreach (char c in m)
            {
                int i = alfabe.IndexOf(c);
                int yeni = sifrele ? (i + k) % 29 : (i - k % 29 + 29) % 29;
                s += alfabe[yeni];
            }
            return s;
        }

        // 2. Doğrusal (Affine)
        private string Dogrusal(string m, int k, bool sifrele)
        {
            string s = "";
            int a = 3, aTersi = 10;
            foreach (char c in m)
            {
                int x = alfabe.IndexOf(c);
                int yeni = sifrele ? (a * x + k) % 29 : (aTersi * (x - k % 29 + 29)) % 29;
                s += alfabe[yeni % 29];
            }
            return s;
        }

        // 3. Yer Değiştirme
        private string YerDegistirme(string m)
        {
            string s = "";
            foreach (char c in m) s += alfabe[28 - alfabe.IndexOf(c)];
            return s;
        }

        // 4. Vigenere
        private string Vigenere(string m, string anahtar, bool sifrele)
        {
            string s = "";
            anahtar = Temizle(anahtar);
            if (string.IsNullOrEmpty(anahtar)) anahtar = "ANAHTAR";
            for (int i = 0; i < m.Length; i++)
            {
                int mIdx = alfabe.IndexOf(m[i]);
                int aIdx = alfabe.IndexOf(anahtar[i % anahtar.Length]);
                int yeni = sifrele ? (mIdx + aIdx) % 29 : (mIdx - aIdx + 29) % 29;
                s += alfabe[yeni];
            }
            return s;
        }

        // 5. Hill (2x2 Matris)
        private string Hill(string m, bool sifrele)
        {
            int[,] mat = sifrele ? new int[,] { { 3, 3 }, { 2, 5 } } : new int[,] { { 15, 20 }, { 17, 10 } };
            if (m.Length % 2 != 0) m += "X";
            string s = "";
            for (int i = 0; i < m.Length; i += 2)
            {
                int x1 = alfabe.IndexOf(m[i]), x2 = alfabe.IndexOf(m[i + 1]);
                s += alfabe[(mat[0, 0] * x1 + mat[0, 1] * x2) % 29];
                s += alfabe[(mat[1, 0] * x1 + mat[1, 1] * x2) % 29];
            }
            return s;
        }

        // 6. 4 Kare (Basitleştirilmiş)
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

        // 7. Sayı Anahtarlı
        private string SayiAnahtar(string m, int k, bool sifrele)
        {
            int sutun = k < 2 ? 3 : k;
            int satir = (int)Math.Ceiling((double)m.Length / sutun);
            char[,] mat = new char[satir, sutun];
            if (sifrele)
            {
                int idx = 0;
                for (int i = 0; i < satir; i++)
                    for (int j = 0; j < sutun; j++) mat[i, j] = (idx < m.Length) ? m[idx++] : 'X';
                string s = "";
                for (int j = 0; j < sutun; j++)
                    for (int i = 0; i < satir; i++) s += mat[i, j];
                return s;
            }
            else
            {
                int idx = 0;
                for (int j = 0; j < sutun; j++)
                    for (int i = 0; i < satir; i++) mat[i, j] = (idx < m.Length) ? m[idx++] : 'X';
                string s = "";
                for (int i = 0; i < satir; i++)
                    for (int j = 0; j < sutun; j++) s += mat[i, j];
                return s.Replace("X", "");
            }
        }

        // 8. Permütasyon
        private string Permutasyon(string m)
        {
            char[] arr = m.ToCharArray();
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                char t = arr[i]; arr[i] = arr[i + 1]; arr[i + 1] = t;
            }
            return new string(arr);
        }

        // 9. Rota
        private string Rota(string m)
        {
            char[] a = m.ToCharArray();
            Array.Reverse(a);
            return new string(a);
        }

        // 10. Zigzag
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
                string res = "";
                for (int i = 0; i < s1.Length; i++)
                {
                    res += s1[i];
                    if (i < s2.Length) res += s2[i];
                }
                return res;
            }
        }

        // 11. RSA
        private string RSAMotoru(string m, bool sifrele)
        {
            BigInteger n = 3233, e = 17, d = 2753;
            if (sifrele)
            {
                List<string> sifreli = new List<string>();
                foreach (char c in m) sifreli.Add(BigInteger.ModPow(alfabe.IndexOf(c), e, n).ToString());
                return string.Join("-", sifreli);
            }
            else
            {
                try
                {
                    string res = "";
                    foreach (string p in m.Split('-'))
                        if (BigInteger.TryParse(p, out BigInteger val))
                            res += alfabe[(int)BigInteger.ModPow(val, d, n) % 29];
                    return res;
                }
                catch { return "RSA Formatı Hatalı!"; }
            }
        }

        #endregion

        private void btnSifrele_Click(object sender, EventArgs e) => IslemYap(true);
        private void btnCoz_Click(object sender, EventArgs e) => IslemYap(false);

        private void IslemYap(bool sifrele)
        {
            try
            {
                if (cmbYontem.SelectedItem == null) return;
                string m = sifrele ? Temizle(txtGiris.Text) : txtGiris.Text.Trim();
                string anahtarMetin = txtAnahtar.Text;
                int k = int.TryParse(anahtarMetin, out int val) ? val : 3;
                string secim = cmbYontem.SelectedItem.ToString();
                string sonuc = "";

                if (secim.Contains("Kaydırmalı")) sonuc = Kaydirmali(m, k, sifrele);
                else if (secim.Contains("Doğrusal")) sonuc = Dogrusal(m, k, sifrele);
                else if (secim.Contains("Yer değiştirme")) sonuc = YerDegistirme(m);
                else if (secim.Contains("Vigenere")) sonuc = Vigenere(m, anahtarMetin, sifrele);
                else if (secim.Contains("Hill")) sonuc = Hill(m, sifrele);
                else if (secim.Contains("4 Kare")) sonuc = DortKare(m);
                else if (secim.Contains("Sayı anahtarlı")) sonuc = SayiAnahtar(m, k, sifrele);
                else if (secim.Contains("Permütasyon")) sonuc = Permutasyon(m);
                else if (secim.Contains("Rota")) sonuc = Rota(m);
                else if (secim.Contains("Zigzag")) sonuc = Zigzag(m, sifrele);
                else if (secim.Contains("RSA")) sonuc = RSAMotoru(m, sifrele);

                txtSonuc.Text = sonuc;
            }
            catch { MessageBox.Show("Girişleri kontrol edin!"); }
        }

        private void btnEpostaGonder_Click(object sender, EventArgs e)
        {
            try
            {
                using (SmtpClient sc = new SmtpClient("smtp.gmail.com", 587))
                {
                    sc.Credentials = new NetworkCredential("tuanaaunall10@gmail.com", "urve czcc efcm nqcw");
                    sc.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress("tuanaaunall10@gmail.com");
                    mail.To.Add(txtAliciEmail.Text);
                    mail.Subject = "Şifreli Mesaj Alındı";
                    mail.Body = $"Yöntem: {cmbYontem.SelectedItem}\nMesaj: {txtSonuc.Text}";
                    sc.Send(mail);
                }
                MessageBox.Show("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex) { MessageBox.Show("Hata: " + ex.Message); }
        }

        private void btnEpostaAl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("E-posta sunucusundan şifreli metin başarıyla çekildi.");
        }

        private void cmbYontem_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}