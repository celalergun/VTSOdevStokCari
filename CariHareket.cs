using System;

namespace VTSOdevStokCari
{
    public class CariHareket
    {
        public int CariHareketID { get; set; }
        public int MusteriID { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Meblag { get; set; }
        public int Tipi { get; set; }
    }
}
