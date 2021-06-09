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

        // Bağlantıyı Singleton olarak tanımlayacağız
        // İlk erişmeye çalıştığımızda geçerli bir bağlantı yoksa otomatik olarak yaratılacak

        private SqliteConnection _baglanti = null;
        public SqliteConnection Baglanti
        {
            get
            {
                if (_baglanti == null)
                {
                    Baglan();
                }

                return _baglanti;
            }
        }

        private void Baglan()
        {
            _baglanti = new SqliteConnection("Data Source=" + _veriTabaniDosyasi);
            _baglanti.Open();
        }

        private void SqlKoduCalistir(string kod)
        {
            var komut = new SqliteCommand(kod, Baglanti);
            komut.ExecuteNonQuery();
        }

        public void TablolariYarat()
        {
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

            sqlKodu = @"
                CREATE TABLE IF NOT EXISTS Musteri (
                MusteriID integer not null,
                MusteriUnvani varchar(100) not null,
                Adres varchar(100) not null,
                Bakiye numeric(8,2) default (0),
                PRIMARY KEY(MusteriID) 
                );";
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
                CREATE TRIGGER IF NOT EXISTS StokHareketBakiyeHesapla
                AFTER UPDATE ON StokHareket 
                BEGIN
                UPDATE STOK SET Miktar = Miktar - Old.Miktar;
                UPDATE STOK SET Miktar = Miktar + New.Miktar;
                END;";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"
                CREATE TRIGGER IF NOT EXISTS StokHareketBakiyedenDus
                AFTER DELETE ON StokHareket 
                BEGIN
                UPDATE STOK SET Miktar = Miktar - Old.Miktar;
                END;";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"
                CREATE TRIGGER IF NOT EXISTS StokHareketBakiyeEkle
                AFTER INSERT ON StokHareket 
                BEGIN
                UPDATE STOK SET Miktar = Miktar + New.Miktar;
                END;";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"
                CREATE TABLE IF NOT EXISTS CariHareket (
                CariHareketID integer not null,
                MusteriID integer not null,
                Tarih Datetime not null,
                Meblag numeric(8,2) not null,
                Tipi integer not null CHECK (Tipi = 1 OR Tipi = -1),
                PRIMARY KEY(CariHareketID),
                FOREIGN KEY (MusteriID) REFERENCES Musteri(MusteriID) ON DELETE CASCADE
                );";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_StokAdi ON Stok(StokAdi);";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_MusteriUnvani ON Musteri(MusteriUnvani);";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_StokHareketStokID ON StokHareket(StokID);";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_StokHareketTarih ON StokHareket(Tarih);";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_CariHareketMusteriID ON CariHareket(MusteriID);";
            SqlKoduCalistir(sqlKodu);

            sqlKodu = @"CREATE UNIQUE INDEX IF NOT EXISTS IX_CariHareketTarih ON CariHareket(Tarih);";
            SqlKoduCalistir(sqlKodu);
        }

        public List<Stok> Stoklar(string adFiltre)
        {
            List<Stok> sonuc = new List<Stok>();

            SqliteCommand komut;
            string sorgu = "SELECT * FROM Stok";
            if (adFiltre != "")
            {
                sorgu += " Where StokAdi Like @aranan";
                komut = new SqliteCommand(sorgu, Baglanti);
                komut.Parameters.AddWithValue("@aranan", $"%{adFiltre}%");
            }
            else
            {
                komut = new SqliteCommand(sorgu, Baglanti);
            }

            komut.Prepare();
            SqliteDataReader okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                var stok = new Stok();
                stok.StokID = okuyucu.GetInt32(0);
                stok.StokAdi = okuyucu.GetString(1);
                stok.Birim = okuyucu.GetString(2);
                stok.Miktar = okuyucu.GetDecimal(3);
                sonuc.Add(stok);
            }

            return sonuc;
        }

        public List<Musteri> Musteriler(string unvanFiltre)
        {
            List<Musteri> sonuc = new List<Musteri>();

            SqliteCommand komut;
            string sorgu = "SELECT * FROM Musteri";
            if (unvanFiltre != "")
            {
                sorgu += " Where MusteriUnvani Like @aranan";
                komut = new SqliteCommand(sorgu, Baglanti);
                komut.Parameters.AddWithValue("@aranan", $"%{unvanFiltre}%");
            }
            else
            {
                komut = new SqliteCommand(sorgu, Baglanti);
            }

            komut.Prepare();
            SqliteDataReader okuyucu = komut.ExecuteReader();

            while (okuyucu.Read())
            {
                var Musteri = new Musteri();
                Musteri.MusteriID = okuyucu.GetInt32(0);
                Musteri.MusteriUnvani = okuyucu.GetString(1);
                Musteri.Adres = okuyucu.GetString(2);
                Musteri.Bakiye = okuyucu.GetDecimal(3);
                sonuc.Add(Musteri);
            }

            return sonuc;
        }
    }
}
