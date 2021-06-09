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
        private List<Musteri> _musteriler = new List<Musteri>();
        
        public MusteriListe()
        {
            InitializeComponent();
            ListeyiYukle();
        }

        public Veritabani VeriTabani { get; internal set; }

        private void ListeyiYukle()
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
