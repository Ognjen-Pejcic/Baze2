using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class GarantniList : DomenskiObjekat.DomenskiObjekat
    {
        public int GarantniListId { get; set; }
        public string Napomena { get; set; }
        public Faktura Faktura{ get; set; }
        public Serviser Serviser{ get; set; }
        public Adresa Adresa { get; set; }
        public Prodavac Prodavac { get; set; }

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
