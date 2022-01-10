using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class ProdavacKontakt : DomenskiObjekat.DomenskiObjekat
    {

        public int ProdavacId { get; set; }
        public string BrojTelefona { get; set; }
        public string EmailAdresa { get; set; }
        public Adresa Adresa { get; set; }

        [Browsable(false)]
        public string NazivTabele => "prodavac_kontakt";
        [Browsable(false)]
        public string InsertVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string Join => "p join adresa a on (p.broj = a.broj and p.ulicaid = a.ulicaid and p.postanskibroj = a.postanskibroj and p.drzavaid = a.drzavaid) join ulica u on (a.ulicaId = u.ulicaId) join grad g on (g.postanskiBroj = u.postanskibroj) join drzava d on (d.drzavaid = g.drzavaId)";
        [Browsable(false)]
        public string Where => throw new NotImplementedException();
        [Browsable(false)]
        public string SelectVrednosti => "*";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                ProdavacKontakt b = new ProdavacKontakt();
                b.ProdavacId = reader.GetInt32(0);
                b.BrojTelefona = reader.GetString(1);
                b.EmailAdresa = reader.GetString(2);
                Adresa adresa = new Adresa();
                adresa.Broj = reader.GetInt32(6);
                adresa.UlicaId = reader.GetInt32(3);
                adresa.NazivUlice = reader.GetString(12);
                adresa.GradId = reader.GetInt32(5);
                adresa.NazivGrada = reader.GetString(16);
                adresa.DrzavaId = reader.GetInt32(4);
                adresa.NazivDrzave = reader.GetString(19);
                b.Adresa = adresa;
                result.Add(b);
            }
            return result;
        }
    }
}
