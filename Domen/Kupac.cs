using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public class Kupac : DomenskiObjekat.DomenskiObjekat
    {
        public int KupacId { get; set; }
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }
        public string BrojTelefona{ get; set; }
        public Adresa Adresa { get; set; }

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
            throw new System.NotImplementedException();
        }
    }
}