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
    public partial class MusteriKartForm : Form
    {
        private List<Musteri> _musteriler = null;
        BindingSource liste = null;
        public Veritabani VeriTabani { get; internal set; }
        public MusteriKartForm()
        {
            InitializeComponent();
        }

        private void Liste_CurrentChanged(object sender, EventArgs e)
        {
            txtUnvan.Text = ((Musteri)liste.Current).MusteriUnvani;
            txtAdres.Text = ((Musteri)liste.Current).Adres;
            txtBakiye.Text = ((Musteri)liste.Current).Bakiye.ToString("N2");
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string eklemeKodu = "INSERT INTO Musteri (MusteriUnvani, Adres, Bakiye) VALUES (@MusteriUnvani, @Adres, 0)";
            SqliteCommand komut = new SqliteCommand(eklemeKodu, VeriTabani.Baglanti);
            komut.Parameters.AddWithValue("@MusteriUnvani", txtUnvan.Text);
            komut.Parameters.AddWithValue("@Adres", txtAdres.Text);
            komut.Prepare();
            komut.ExecuteNonQuery();
            Yukle();
        }

        internal void Yukle()
        {
            _musteriler = VeriTabani.Musteriler("");
            dataGridView1.Refresh();
            liste = new BindingSource();
            liste.DataSource = _musteriler;
            liste.CurrentChanged += Liste_CurrentChanged;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = liste;
            Liste_CurrentChanged(null, null);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (liste.Current == null)
                return;

            string unvan = ((Musteri)liste.Current).MusteriUnvani;
            DialogResult sonuc = MessageBox.Show($"{unvan} kaydı silinecek, emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (sonuc != DialogResult.Yes)
                return;

            int id = ((Musteri)liste.Current).MusteriID;
            string silmeKodu = "DELETE FROM Musteri WHERE MusteriID = @MusteriID";
            SqliteCommand komut = new SqliteCommand(silmeKodu, VeriTabani.Baglanti);
            komut.Parameters.AddWithValue("MusteriID", id);
            komut.Prepare();
            komut.ExecuteNonQuery();
            Yukle();
        }
    }
}
