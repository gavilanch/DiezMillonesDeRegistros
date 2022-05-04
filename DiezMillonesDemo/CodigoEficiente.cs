using Microsoft.Data.SqlClient;
using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiezMillonesDemo
{
    public class CodigoEficiente
    {
        public static void InsertarDatos(string ruta)
        {
            var connString = "Server=.;Database=MillonesDeRegistrosDB;Integrated Security=true;TrustServerCertificate=True";
            using (var conexion = new SqlConnection(connString))
            {
                using (var comando = new SqlCommand("Valores_InsertarListado", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    SqlParameter parametro = new SqlParameter("@ListadoValores", SqlDbType.Structured);
                    parametro.TypeName = "dbo.ListadoValores";
                    parametro.Value = ObtenerContenidoArchivo(ruta);
                    comando.Parameters.Add(parametro);
                    conexion.Open();
                    comando.ExecuteNonQuery();
                }
            }
        }

        private static IEnumerable<SqlDataRecord> ObtenerContenidoArchivo(string ruta)
        {
            SqlMetaData[] esquema = new SqlMetaData[] {
      new SqlMetaData("valor", SqlDbType.NVarChar, 100)
   };
            SqlDataRecord _DataRecord = new SqlDataRecord(esquema);
            using (StreamReader? reader = new StreamReader(ruta))
            {
                while (!reader.EndOfStream)
                {
                    _DataRecord.SetString(0, reader.ReadLine());
                    yield return _DataRecord;
                }
            }
        }

    }
}
