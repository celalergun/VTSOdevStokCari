using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTSOdevStokCari
{
    public partial class StokHareketForm : Form
    {
        public Veritabani VeriTabani { get; internal set; }

        private Stok _secilen = null;

        public StokHareketForm()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            using (StokListeForm sk = new StokListeForm())
            {
                sk.VeriTabani = VeriTabani;
                sk.Yukle();
                if (sk.ShowDialog() == DialogResult.OK)
                {
                    txtStokAdi.Text = sk.Secilen.StokAdi;
                    txtBirim.Text = sk.Secilen.Birim;
                    _secilen = sk.Secilen;
                    comboBox1.SelectedIndex = 0;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_secilen == null)
            {
                MessageBox.Show("Önce bir stok kartı seçmelisiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int tipi;
            if (comboBox1.SelectedIndex == 0)
                tipi = 1;
            else
                tipi = -1;

            decimal miktar = numericUpDown1.Value;
            DateTime tarih = DateTime.Now;

            string eklemeKodu = "INSERT INTO StokHareket (StokID, Miktar, Tipi, Tarih) VALUES (@StokID, @Miktar, @Tipi, @Tarih)";
            SqliteCommand komut = new SqliteCommand(eklemeKodu, VeriTabani.Baglanti);
            komut.Parameters.AddWithValue("@StokID", _secilen.StokID);
            komut.Parameters.AddWithValue("@Miktar", miktar);
            komut.Parameters.AddWithValue("@Tipi", tipi);
            komut.Parameters.AddWithValue("@Tarih", tarih);
            komut.Prepare();
            komut.ExecuteNonQuery();
            Close();
        }
    }
}
