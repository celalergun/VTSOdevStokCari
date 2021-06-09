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
    public partial class StokListeForm : Form
    {
        private List<Musteri> _musteriler = null;

        public Veritabani VeriTabani { get; internal set; }

        public StokListeForm()
        {
            InitializeComponent();
        }

        private void ListeyiYukle()
        {
            _musteriler = VeriTabani.Musteriler("");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
