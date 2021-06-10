using Microsoft.Data.Sqlite;
using System;
using System.Windows.Forms;

namespace VTSOdevStokCari
{
    public partial class CariHareketForm : Form
    {
        public Veritabani VeriTabani { get; internal set; }

        private Musteri _secilen = null;

        public CariHareketForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (MusteriListeForm ml = new MusteriListeForm())
            {
                ml.VeriTabani = VeriTabani;
                ml.Yukle();
                if (ml.ShowDialog() == DialogResult.OK)
                {
                    txtUnvan.Text = ml.Secilen.MusteriUnvani;
                    txtAdres.Text = ml.Secilen.Adres;
                    _secilen = ml.Secilen;
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_secilen == null)
            {
                MessageBox.Show("Önce bir müşteri kartı seçmelisiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tipi;
            if (comboBox1.SelectedIndex == 0)
                tipi = 1;
            else
                tipi = -1;

            decimal miktar = numericUpDown1.Value;
            DateTime tarih = DateTime.Now;

            string eklemeKodu = "INSERT INTO CariHareket (MusteriID, Meblag, Tipi, Tarih) VALUES (@MusteriID, @Meblag, @Tipi, @Tarih)";
            SqliteCommand komut = new SqliteCommand(eklemeKodu, VeriTabani.Baglanti);
            komut.Parameters.AddWithValue("@MusteriID", _secilen.MusteriID);
            komut.Parameters.AddWithValue("@Meblag", miktar);
            komut.Parameters.AddWithValue("@Tipi", tipi);
            komut.Parameters.AddWithValue("@Tarih", tarih);
            komut.Prepare();
            komut.ExecuteNonQuery();
            Close();
        }
    }
}