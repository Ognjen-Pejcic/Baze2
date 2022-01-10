using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class StavkaGarancije : DomenskiObjekat.DomenskiObjekat
    {
        public int StavkaGarancijeId { get; set; }
        public GarantniList GarantniList { get; set; }  
        public DateTime DatumKupovine { get; set; }
        public DateTime DatumDo { get; set; }
        public string SerijskiBroj { get;set; }
        public Proizvod Proizvod { get; set; }

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
