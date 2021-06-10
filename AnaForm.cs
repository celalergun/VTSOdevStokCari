using System;
using System.Windows.Forms;

namespace VTSOdevStokCari
{
    public partial class AnaForm : Form
    {
        private Veritabani _veritabani { get; set; }

        public AnaForm()
        {
            InitializeComponent();

            // Uygulama bellekte çalıştırıldıktan sonra veri tabanı kontrolleri yapılır
            // 1. Veri tabanı dosyası yoksa yaratılır
            // 2. İçerideki tablo, indeks, trigger ve fonksiyonlar kontrol edilir, yoksa yaratılır

            VeritabaninaBaglan();
        }

        private void VeritabaninaBaglan()
        {
            _veritabani = new Veritabani();
            _veritabani.TablolariYarat();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (MusteriKartForm ml = new MusteriKartForm())
            {
                ml.VeriTabani = _veritabani;
                ml.Yukle();
                ml.ShowDialog();
            }
        }

        private void stokKartlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StokKartForm sk = new StokKartForm())
            {
                sk.VeriTabani = _veritabani;
                sk.Yukle();
                sk.ShowDialog();
            }
        }

        private void malHareketiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StokHareketForm sh = new StokHareketForm())
            {
                sh.VeriTabani = _veritabani;
                sh.ShowDialog();
            }
        }

        private void stokListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StokListeForm sk = new StokListeForm())
            {
                sk.VeriTabani = _veritabani;
                sk.Yukle();
                sk.ShowDialog();
            }
        }

        private void müşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (MusteriListeForm ml = new MusteriListeForm())
            {
                ml.VeriTabani = _veritabani;
                ml.Yukle();
                ml.ShowDialog();
            }
        }

        private void paraHareketiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CariHareketForm ch = new CariHareketForm())
            {
                ch.VeriTabani = _veritabani;
                ch.ShowDialog();
            }
        }

        private void sQLInjectionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SQLInjectionForm si = new SQLInjectionForm())
            {
                si.VeriTabani = _veritabani;
                si.ShowDialog();
            }
        }
    }
}