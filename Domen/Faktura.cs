using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Faktura : DomenskiObjekat.DomenskiObjekat
    {
        public int FakturaId { get; set; }
        public string NacinPlacanja { get; set; }
        public DateTime DatumKnjizenja { get; set; }
        public decimal Medjuvrednost{ get; set; }
        public decimal UkupnaVrednost { get; set; }
        public Kupac Kupac { get; set; }

        public Prodavac Prodavac { get; set; }
        [Browsable(false)]
        public Prijemnica Prijemnica { get; set; }
        public List<StavkaFakture> Stavke { get; set; }

        [Browsable(false)]
        public string NazivTabele => "Faktura";
        [Browsable(false)]
        public string InsertVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateVrednosti => $"ukupno = {UkupnaVrednost}";
        [Browsable(false)]
        public string Join => "f join prodavac p on (f.prodavacId = p.prodavacId) join kupac k on (k.kupacId = f.kupacId)";
        [Browsable(false)]
        public string Where => $"fakturaId = {FakturaId}";
        [Browsable(false)]
        public string SelectVrednosti => "*";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> fakture = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Faktura f = new Faktura();
                f.FakturaId = reader.GetInt32(0);
                f.NacinPlacanja = reader.GetString(1);  
                f.DatumKnjizenja = reader.GetDateTime(2);
                f.Medjuvrednost =reader.GetDecimal(3);
                f.UkupnaVrednost =reader.GetDecimal(4);

                Prodavac p = new Prodavac
                {
                    ProdavacId = reader.GetInt32(5),
                    NazivProdavca = reader.GetString(9)
                };
                f.Prodavac =p;

                Kupac k = new Kupac
                {
                    KupacId = reader.GetInt32(6),
                    ImeKupca = reader.GetString(18),
                    PrezimeKupca = reader.GetString(19)
                };
                f.Kupac =k;
                fakture.Add(f);
            }
            return fakture;
        }
        public override string ToString()
        {
            return FakturaId.ToString();
        }
    }
}
