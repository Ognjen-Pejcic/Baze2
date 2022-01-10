using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public class Prijemnica : DomenskiObjekat.DomenskiObjekat
    {
        public int PrijemnicaId { get; set; }
        public string SifraPrijemnice { get; set; }
        public DateTime DatumKnjizenja { get; set; }
        public DateTime DatumPreuzimanja { get; set; }
        public string Napomena { get; set; }
        public Dobavljac Dobavljac { get; set; }    
        public Porudzbina Porudzbina { get; set; }

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