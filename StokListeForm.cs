using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VTSOdevStokCari
{
    public partial class StokListeForm : Form
    {
        private List<Stok> _stoklar = null;
        private BindingSource liste = null;

        public Stok Secilen { get; set; }

        public Veritabani VeriTabani { get; internal set; }

        public StokListeForm()
        {
            InitializeComponent();
            Secilen = new Stok();
            Secilen.StokID = -1;
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

            Text = ((Stok)liste.Current).StokAdi + " seçildi";
            Secilen = ((Stok)liste.Current);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _stoklar = VeriTabani.Stoklar(txtArama.Text);
            dataGridView1.Refresh();
        }
    }
}