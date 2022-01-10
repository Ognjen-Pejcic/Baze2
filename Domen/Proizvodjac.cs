using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public class Proizvodjac : DomenskiObjekat.DomenskiObjekat
    {
        public int ProizvodjacId { get; set; }
        public string NazivProizvodjaca { get; set; }

        public string NazivTabele => "Proizvodjac";

        public string InsertVrednosti => throw new NotImplementedException();

        public string UpdateVrednosti => $"NazivProizvodjaca = '{NazivProizvodjaca}'";

        public string Join => "";

        public string Where => $"ProizvodjacId = {ProizvodjacId}";

        public string SelectVrednosti => "*";

        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Proizvodjac b = new Proizvodjac();
                b.ProizvodjacId = reader.GetInt32(0);
                b.NazivProizvodjaca = reader.GetString(1);
                result.Add(b);
            }
            return result;
        }

        public override string ToString()
        {
            return NazivProizvodjaca;
        }
    }
}