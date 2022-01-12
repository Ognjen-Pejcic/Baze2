using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public string SerijskiBroj { get;set; }
        public Proizvod Proizvod { get; set; }

        [Browsable(false)]
        public string NazivTabele => "StavkaGarancije";
        [Browsable(false)]
        public string InsertVrednosti => $"{StavkaGarancijeId}, {GarantniList.GarantniListId}, '{DatumOd}', '{DatumDo}', '{SerijskiBroj}', {Proizvod.ProizvodaId}";
        [Browsable(false)]
        public string UpdateVrednosti => $"datumdo = '{DatumDo}'";
        [Browsable(false)]
        public string Join => "s join proizvod p on (p.proizvodid = s.proizvodId)";
        [Browsable(false)]
        public string Where => $"stavkaid = {StavkaGarancijeId} and garancijaId = {GarantniList.GarantniListId}";
        [Browsable(false)]
        public string SelectVrednosti => "*";
        [Browsable(false)]
        public List<DomenskiObjekat.DomenskiObjekat> GetReaderResult(SqlDataReader reader)
        {
            List<DomenskiObjekat.DomenskiObjekat> stavke = new List<DomenskiObjekat.DomenskiObjekat>();

            while (reader.Read())
            {
                StavkaGarancije s = new StavkaGarancije();
                s.StavkaGarancijeId = reader.GetInt32(0);
                s.GarantniList = new GarantniList
                {
                    GarantniListId = reader.GetInt32(1),
                };
                s.DatumOd = reader.GetDateTime(2);
                s.DatumDo = reader.GetDateTime(3);
                s.SerijskiBroj = reader.GetString(4);
                s.Proizvod = new Proizvod
                {
                    ProizvodaId = reader.GetInt32(5)
                    ,NazivProizvoda = reader.GetString(7)
                };
                stavke.Add(s);
            }
            return stavke;
        }
    }
}
