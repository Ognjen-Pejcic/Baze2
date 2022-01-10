using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class JedinicaMere : DomenskiObjekat.DomenskiObjekat
    {
        public int JedinicaMereId { get; set; }

        public string NazivJediniceMere { get; set; }

        public string NazivTabele => "jedinicaMere";
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
                JedinicaMere jedinicaMere = new JedinicaMere();  
                jedinicaMere.NazivJediniceMere = reader.GetString(1);
                jedinicaMere.JedinicaMereId = reader.GetInt32(0);
                result.Add(jedinicaMere);
            }
            return result;
        }
        public override string ToString()
        {
            return NazivJediniceMere;
        }
    }

  
}
