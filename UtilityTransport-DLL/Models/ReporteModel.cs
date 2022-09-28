using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityTransport_DLL.Models
{
    public class ReporteModel
    {
        public DataTable ObtenerDatosReporte(string sqlQuery, params DbParameter[] parameters)
        {
            utilityTransportEntities ModeloBD = new utilityTransportEntities();
            DataTable dataTable = new DataTable();
            DbConnection connection = ModeloBD.Database.Connection;
            DbProviderFactory dbFactory = DbProviderFactories.GetFactory(connection);
            using (var cmd = dbFactory.CreateCommand())
            {
                cmd.Connection = connection;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sqlQuery;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                using (DbDataAdapter adapter = dbFactory.CreateDataAdapter())
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }


    }
}