using System.Data.SqlClient;

namespace Domen.DomenskiObjekat
{
    public interface DomenskiObjekat
    {
        string NazivTabele { get; }
        string InsertVrednosti { get; }
        string UpdateVrednosti { get; }
        string Join { get; }
        string Where { get; }
        string SelectVrednosti { get; }

        List<DomenskiObjekat> GetReaderResult(SqlDataReader reader);
    }
}
