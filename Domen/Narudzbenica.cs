using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public class Narudzbenica : DomenskiObjekat.DomenskiObjekat
    {
        public int NarudzbenicaId { get; set; }
        public string ReferencaNarudzbenice { get; set; }
        public DateTime DatumNarucivanja { get; set; }
        public double UkupnaVrednostPorudzbine { get; set; }
        public Kupac Kupac { get; set; }
        public Adresa Adresa { get; set; }
        public Prodavac Prodavac{ get; set; }

        public string NazivTabele => throw new NotImplementedException();

        public string InsertVrednosti => throw new NotImplementedException();

        public string UpdateVrednosti => throw new NotImplementedException();

        public string Join => throw new NotImplementedException();

        public string Where => throw new NotImplementedException();

        public string SelectVrednosti => throw new NotImplementedException();

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }

        List<DomenskiObjekat.DomenskiObjekat> DomenskiObjekat.DomenskiObjekat.GetReaderResult(SqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}