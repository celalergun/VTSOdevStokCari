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
    public partial class MusteriListeForm : Form
    {
        private List<Musteri> _musteriler = null;
        
        public MusteriListeForm()
        {
            InitializeComponent();
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

        internal void Yukle()
        {
            ListeyiYukle();
            BindingSource liste = new BindingSource();
            liste.DataSource = _musteriler;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = liste;
        }
    }
}
