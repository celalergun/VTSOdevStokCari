using System;

namespace VTSOdevStokCari
{
    public class StokHareket
    {
        public int StokHareketID { get; set; }
        public int StokID { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Miktar { get; set; }
        public int Tipi { get; set; }
    }
}
