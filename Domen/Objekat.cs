﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public class Objekat : DomenskiObjekat.DomenskiObjekat
    {
        public int ObjekatId { get; set; }
        public string SifraObjekta { get; set; }
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

        List<DomenskiObjekat.DomenskiObjekat> DomenskiObjekat.DomenskiObjekat.GetReaderResult(SqlDataReader reader)
        {
            throw new System.NotImplementedException();
        }
        public override string ToString()
        {
            return SifraObjekta;
        }
    }
}