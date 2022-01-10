using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Banka : DomenskiObjekat.DomenskiObjekat
    {
        public int BankaId { get; set; }
        public string NazivBanke { get; set; }

        [Browsable(false)]
        public string NazivTabele => "Banka";
        [Browsable(false)]
        public string InsertVrednosti => throw new NotImplementedException();
        [Browsable(false)]
        public string UpdateVrednosti => $"nazivbanke = '{NazivBanke}'";
        [Browsable(false)]
        public string Join => "";
        [Browsable(false)]
        public string Where => $"bankaId = {BankaId}";
        [Browsable(false)]
        public string SelectVrednosti => "*";
        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> result = new List<DomenskiObjekat.DomenskiObjekat>();
            while (reader.Read())
            {
                Banka b = new Banka();
                b.BankaId = reader.GetInt32(0);
                b.NazivBanke = reader.GetString(1);
                result.Add(b);
            }
            return result;
        }

        public override string ToString()
        {
            return NazivBanke;
        }
    }
}
