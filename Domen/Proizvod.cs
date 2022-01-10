using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Proizvod : DomenskiObjekat.DomenskiObjekat
    { 
        public int ProizvodaId { get; set; }
        public string NazivProizvoda { get; set; }
        public decimal Cena { get; set; }
        public string OpisProizvoda { get; set; }
        public string OznakaModela { get; set; }
        public TipProizvoda TipProizvoda { get; set; }
        public JedinicaMere JedinicaMere{ get; set; }
        public Proizvodjac Proizvodjac { get; set; }
        public string NazivProizvojdaca { get; set; }

        public string NazivTabele => "Proizvod";

        public string InsertVrednosti => $"'{NazivProizvoda}', '{OpisProizvoda}', {Cena}, '{OznakaModela}', {TipProizvoda.TipProizvodaId}, {JedinicaMere.JedinicaMereId}, {Proizvodjac.ProizvodjacId}, ''";


        public string UpdateText { get; set; }
        public string UpdateVrednosti => UpdateText;

        public string Join => "p join tipProizvoda t on (p.tipProizvodaId = t.tipProizvodaId) join jedinicaMere j on (j.jedinicaMereId = p.jedinicaMereId) ";

        public string Where => $"proizvodid = {ProizvodaId}";

        public string SelectVrednosti => "*";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Proizvod p = new Proizvod();
                p.ProizvodaId = reader.GetInt32(0);
                p.NazivProizvoda = reader.GetString(1);
                p.OpisProizvoda = reader.GetString(2);
                p.Cena =  reader.GetDecimal(3);
                p.OznakaModela = reader.GetString(4);   

                TipProizvoda tip = new TipProizvoda();
                tip.NazivTipa = reader.GetString(10);
                p.TipProizvoda = tip;   

                JedinicaMere jedinicaMere =  new JedinicaMere();    
                jedinicaMere.NazivJediniceMere = reader.GetString(13);
                p.JedinicaMere = jedinicaMere;

                p.NazivProizvojdaca = reader.GetString(8);

                result.Add(p);
            }
            return result;
        }
        public override string ToString()
        {
            return NazivProizvoda;
        }
    }
}
