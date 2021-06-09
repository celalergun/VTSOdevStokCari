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
    public partial class MusteriListe : Form
    {
        private List<Musteri> _musteriler = null;
        
        public MusteriListe()
        {
            InitializeComponent();
            ListeyiYukle();
            BindingSource liste = new BindingSource();
            liste.DataSource = _musteriler;

            dataGridView1.DataSource = liste;
        }

        public Veritabani VeriTabani { get; internal set; }

        private void ListeyiYukle()
        {
            _musteriler = VeriTabani.Musteriler("");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _musteriler = VeriTabani.Musteriler(textBox1.Text);
        }
    }
}
