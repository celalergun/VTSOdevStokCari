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
        private BindingSource _liste;

        public Musteri Secilen { get; set; }

        public Veritabani VeriTabani { get; internal set; }

        public MusteriListeForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _musteriler = VeriTabani.Musteriler(textBox1.Text);
            dataGridView1.Refresh();
        }

        internal void Yukle()
        {
            _musteriler = VeriTabani.Musteriler("");
            _liste = new BindingSource();
            _liste.DataSource = _musteriler;
            _liste.CurrentChanged += Liste_CurrentChanged;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = _liste;
            Liste_CurrentChanged(null, null);
        }

        private void Liste_CurrentChanged(object sender, EventArgs e)
        {
            if (_liste.Current == null)
                return;

            Text = ((Musteri)_liste.Current).MusteriUnvani + " seçildi";
            Secilen = ((Musteri)_liste.Current);
        }
    }
}
