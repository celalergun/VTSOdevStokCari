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
    public partial class StokKartForm : Form
    {
        private List<Stok> _stoklar = null;
        BindingSource liste = null;
        public Veritabani VeriTabani { get; internal set; }
        public StokKartForm()
        {
            InitializeComponent();
        }

        internal void Yukle()
        {
            _stoklar = VeriTabani.Stoklar("");
            dataGridView1.Refresh();
            liste = new BindingSource();
            liste.DataSource = _stoklar;
            liste.CurrentChanged += Liste_CurrentChanged;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = liste;
            Liste_CurrentChanged(null, null);
        }

        private void Liste_CurrentChanged(object sender, EventArgs e)
        {
            if (liste.Current == null)
                return;

            txtStokAdi.Text = ((Stok)liste.Current).StokAdi;
            txtBirim.Text = ((Stok)liste.Current).Birim;
            txtMiktar.Text = ((Stok)liste.Current).Miktar.ToString("N2");
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            string eklemeKodu = "INSERT INTO Stok (StokAdi, Birim, Miktar) VALUES (@StokAdi, @Birim, 0)";
            SqliteCommand komut = new SqliteCommand(eklemeKodu, VeriTabani.Baglanti);
            komut.Parameters.AddWithValue("@StokAdi", txtStokAdi.Text);
            komut.Parameters.AddWithValue("@Birim", txtBirim.Text);
            komut.Prepare();
            komut.ExecuteNonQuery();
            Yukle();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (liste.Current == null)
                return;

            string adi = ((Stok)liste.Current).StokAdi;
            DialogResult sonuc = MessageBox.Show($"{adi} kaydı silinecek, emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (sonuc != DialogResult.Yes)
                return;

            int id = ((Stok)liste.Current).StokID;
            string silmeKodu = "DELETE FROM Stok WHERE StokID = @StokID";
            SqliteCommand komut = new SqliteCommand(silmeKodu, VeriTabani.Baglanti);
            komut.Parameters.AddWithValue("@StokID", id);
            komut.Prepare();
            komut.ExecuteNonQuery();
            Yukle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (liste.Current == null)
                return;

            int id = ((Stok)liste.Current).StokID;
            string guncellemeKodu = "UPDATE Stok SET StokAdi = @MustesiUnvani, Birim = @Birim WHERE StokID = @StokID";
            SqliteCommand komut = new SqliteCommand(guncellemeKodu, VeriTabani.Baglanti);
            komut.Parameters.AddWithValue("@StokID", id);
            komut.Parameters.AddWithValue("@StokAdi", txtStokAdi.Text);
            komut.Parameters.AddWithValue("@Birim", txtBirim.Text);
            komut.Prepare();
            komut.ExecuteNonQuery();
            Yukle();
        }
    }
}
