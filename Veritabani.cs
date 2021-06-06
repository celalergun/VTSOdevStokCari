using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSOdevStokCari
{
    public class Veritabani
    {
        private const string _veriTabaniDosyasi = "StokCari.db3";
        public SqliteConnection Baglanti { get; set; } = null;

        public void Baglan()
        {
            Baglanti = new SqliteConnection("Data Source=" + _veriTabaniDosyasi);
            Baglanti.Open();
        }

        private void SqlKoduCalistir(string kod)
        {
            var komut = new SqliteCommand(kod, Baglanti);
            komut.ExecuteNonQuery();
        }

        public void TablolariYarat()
        {
            if (Baglanti == null)
                throw new Exception("Veri tabanı bağlı değilken tablo yaratma işlemi yapılamaz");

            string sqlKodu;
            sqlKodu = @"
                CREATE TABLE IF NOT EXISTS Stok (
                StokID integer not null,
                StokAdi varchar(50) not null,
                Birim varchar(5),
                Miktar numeric(8,2),
                PRIMARY KEY(StokID)
                );";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_StokAdi ON Stok(StokAdi);";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"
                CREATE TABLE IF NOT EXISTS Musteri (
                MusteriID integer not null,
                MusteriUnvani varchar(100) not null,
                Adres varchar(100) not null,
                Bakiye numeric(8,2) default (0),
                PRIMARY KEY(MusteriID) 
                );";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_MusteriUnvani ON Musteri(MusteriUnvani);";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"
              CREATE TABLE IF NOT EXISTS StokHareket (
                StokHareketID integer not null,
                StokID integer not null,
                Tarih Datetime not null,
                Miktar numeric(8,2) not null,
                Tipi integer not null CHECK (Tipi = 1 OR Tipi = -1),
                PRIMARY KEY(StokHareketID),
                FOREIGN KEY (StokID) REFERENCES Stok(StokID) ON DELETE CASCADE
                );";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"
              CREATE TABLE IF NOT EXISTS CariHareket (
                CariHareketID integer not null,
                MusteriID integer not null,
                Tarih Datetime not null,
                Meblag numeric(8,2) not null,
                Tipi integer not null CHECK (Tipi = 1 OR Tipi = -1),
                PRIMARY KEY(StokHareketID),
                FOREIGN KEY (StokID) REFERENCES Stok(StokID) ON DELETE CASCADE
                );";
            SqlKoduCalistir(sqlKodu);
        }
    }
}
