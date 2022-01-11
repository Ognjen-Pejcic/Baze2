using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class StavkaFakture : DomenskiObjekat.DomenskiObjekat
    {
        public int StavkaFaktureId { get; set; }
        public Faktura Faktura { get; set; }
        public decimal Kolicina{ get; set; }
        public decimal Iznos{ get; set; }
        public Proizvod Proizvod{ get; set; }

        [Browsable(false)]
        public string NazivTabele => "StavkaFakture";
        [Browsable(false)]
        public string InsertVrednosti => $"{Faktura.FakturaId},  {Kolicina}, {Iznos}, {Proizvod.ProizvodaId} ";
        [Browsable(false)]
        public string UpdateVrednosti => $"iznos = {Iznos}, kolicina = {Kolicina}";
        [Browsable(false)]
        public string Join => $"s join faktura f on (s.fakturaId = f.fakturaId) join proizvod p on (p.proizvodid = s.proizvodId) where s.fakturaId={Faktura.FakturaId}";
        [Browsable(false)]
        public string Where => $"stavkafaktureid = {StavkaFaktureId} and fakturaId = {Faktura.FakturaId}";
        [Browsable(false)]
        public string SelectVrednosti => "*";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                StavkaFakture s = new StavkaFakture();
                s.StavkaFaktureId = reader.GetInt32(0);
                Faktura f = new Faktura();
                f.FakturaId = reader.GetInt32(1);
                s.Faktura = f;

                s.Kolicina = reader.GetDecimal(2);
                s.Iznos = reader.GetDecimal(3); 

                Proizvod p = new Proizvod();
                p.ProizvodaId = reader.GetInt32(4);
                p.NazivProizvoda =reader.GetString(14);

                s.Proizvod = p;

                result.Add(s);
            }
            return result;
        }
    }
}
