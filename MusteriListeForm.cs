﻿using System;
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

        public Veritabani VeriTabani { get; internal set; }

        public MusteriListeForm()
        {
            InitializeComponent();
            Yukle();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _musteriler = VeriTabani.Musteriler(textBox1.Text);
            dataGridView1.Refresh();
        }

        internal void Yukle()
        {
            _musteriler = VeriTabani.Musteriler("");
            BindingSource liste = new BindingSource();
            liste.DataSource = _musteriler;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = liste;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
