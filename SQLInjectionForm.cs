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
    public partial class SQLInjectionForm : Form
    {
        public SQLInjectionForm()
        {
            InitializeComponent();
        }

        public Veritabani VeriTabani { get; internal set; }

        public List<Musteri> Musteriler(string unvanFiltre)
        {
            List<Musteri> sonuc = new List<Musteri>();

            SqliteCommand komut;
            string sorgu = "SELECT * FROM Musteri";
            if (unvanFiltre != "")
            {
                sorgu += $" Where MusteriUnvani Like '{unvanFiltre}'";
                komut = new SqliteCommand(sorgu, VeriTabani.Baglanti);
            }
            else
            {
                komut = new SqliteCommand(sorgu, VeriTabani.Baglanti);
            }

            SqliteDataReader okuyucu = komut.ExecuteReader();

            while (okuyucu.Read())
            {
                var Musteri = new Musteri();
                Musteri.MusteriID = okuyucu.GetInt32(0);
                Musteri.MusteriUnvani = okuyucu.GetString(1);
                Musteri.Adres = okuyucu.GetString(2);
                Musteri.Bakiye = okuyucu.GetDecimal(3);
                sonuc.Add(Musteri);
            }

            return sonuc;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            var liste = Musteriler(txtMusteriUnvani.Text);
            dataGridView1.DataSource = liste;
        }
    }
}
