using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{

    public class Serviser : DomenskiObjekat.DomenskiObjekat
    {
        public int ServiserId { get; set; }
        public string NazivServisera { get; set; }
        public string TelefonServisera{ get; set; }
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

        }
    
}