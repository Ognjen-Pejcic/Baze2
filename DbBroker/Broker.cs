using Domen.DomenskiObjekat;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbBroker
{
    public class Broker
    {
        private SqlTransaction transaction;
        private SqlConnection connection;

        public Broker()
        {
            connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Baze2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        public void OpenConnection()
        {
            connection.Open();
        }
        public void CloseConnection()
        {
            connection.Close();
        }
        public void BeginTransaction()
        {
            transaction = connection.BeginTransaction();
        }
        public void Commit()
        {
            transaction?.Commit();
        }
        public void Rollback()
        {
            transaction?.Rollback();
        }
        public int Sacuvaj(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"Insert into {domenskiObjekat.NazivTabele} values ({domenskiObjekat.InsertVrednosti})";
            return command.ExecuteNonQuery();
        }

        public List<DomenskiObjekat> VratiSve(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"SELECT {domenskiObjekat.SelectVrednosti} FROM {domenskiObjekat.NazivTabele} {domenskiObjekat.Join}";
            SqlDataReader reader = command.ExecuteReader();
            List<DomenskiObjekat> rezultat = domenskiObjekat.GetReaderResult(reader);
            reader.Close();
            return rezultat;

        }
        public int VratiMaxID(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"SELECT max({domenskiObjekat.NazivTabele}id) FROM {domenskiObjekat.NazivTabele}";
            object id = command.ExecuteScalar();
            if (id == DBNull.Value) return 1;
            else return (int)id;

        }

        public int Azuriraj(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"Update {domenskiObjekat.NazivTabele} set {domenskiObjekat.UpdateVrednosti} where {domenskiObjekat.Where}";
            int rez = command.ExecuteNonQuery();
            return rez;
        }

        public int Izbrisi(DomenskiObjekat domenskiObjekat)
        {
            SqlCommand command = new SqlCommand("", connection, transaction);
            command.CommandText = $"Delete from {domenskiObjekat.NazivTabele} where {domenskiObjekat.Where}";
            int rez = command.ExecuteNonQuery();
            return rez;
        }
    }
}