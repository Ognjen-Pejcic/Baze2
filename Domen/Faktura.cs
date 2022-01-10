using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Faktura : DomenskiObjekat.DomenskiObjekat
    {
        public int FakturaId { get; set; }
        public string NacinPlacanja { get; set; }
        public DateTime DatumKnjizenja { get; set; }
        public double Medjuvrednost{ get; set; }
        public double UkupnaVrednost { get; set; }
        public Kupac Kupac { get; set; }
        public Prijemnica Prijemnica { get; set; }

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
