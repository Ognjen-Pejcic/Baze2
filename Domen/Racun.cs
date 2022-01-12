using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class Racun : DomenskiObjekat.DomenskiObjekat
    {
        public string BrojRacuna { get; set; }  
        public Banka Banka { get; set; }
        public Prodavac Prodavac { get; set; }

        [Browsable(false)]
        public string SelectVrednosti => "r.brojRacuna, b.bankaId, r.NazivBanke, p.prodavacId, p.nazivProdavca, p.obelezja.PIB as Pib, p.obelezja.MaticniBroj";

        public string NazivBanke { get; set; }

        [Browsable(false)]
        string DomenskiObjekat.DomenskiObjekat.NazivTabele => "Racun";
        [Browsable(false)]
        string DomenskiObjekat.DomenskiObjekat.InsertVrednosti => $"'{BrojRacuna}', null,{Prodavac.ProdavacId}, {Banka.BankaId}";
        [Browsable(false)]
        string DomenskiObjekat.DomenskiObjekat.UpdateVrednosti => $" nazivBanke = '{NazivBanke}' ";

        [Browsable(false)]
        string DomenskiObjekat.DomenskiObjekat.Join => $" r join banka b on (r.bankaId = b.bankaId) join prodavac_pogled p on (r.prodavacId = p.prodavacId) ";
        [Browsable(false)]
        string DomenskiObjekat.DomenskiObjekat.Where => $"brojRacuna = '{BrojRacuna}' and bankaid = {Banka.BankaId} and  prodavacid = {Prodavac.ProdavacId}";
        [Browsable(false)]
        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Racun r = new Racun();
                r.BrojRacuna = reader.GetString(0);
                r.Banka = new Banka();
                r.Banka.BankaId = reader.GetInt32(1);
                r.NazivBanke = reader.GetString(2);
                r.Banka.NazivBanke = reader.GetString(2);
                r.Prodavac = new Prodavac();
                r.Prodavac.ProdavacId = reader.GetInt32(3);
               
                r.Prodavac.NazivProdavca = reader.GetString(4);
                r.Prodavac.PIB = reader.GetInt32(5);
                r.Prodavac.MaticniBroj = reader.GetInt32(6);

                result.Add(r);
            }
            return result;
        }
    }
}
