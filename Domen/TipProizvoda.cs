using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Domen
{
    public class TipProizvoda : DomenskiObjekat.DomenskiObjekat
    {
        public int TipProizvodaId { get; set; }
        public string NazivTipa { get; set; }

        public string NazivTabele => "tipProizvoda";

        public string InsertVrednosti => throw new NotImplementedException();

        public string UpdateVrednosti => throw new NotImplementedException();

        public string Join => "";

        public string Where => throw new NotImplementedException();

        public string SelectVrednosti => "*";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                TipProizvoda tip= new TipProizvoda();
                tip.NazivTipa = reader.GetString(1);
                tip.TipProizvodaId = reader.GetInt32(0);
                result.Add(tip);
            }
            return result;
        }

        public override string ToString()
        {
            return NazivTipa;
        }

    }
 

}