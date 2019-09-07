using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Data
{
   public class DPedido
    {
        public List<EnPedido> GetPedidos(EnPedido pedido)
        {
            SqlParameter[] parameters = null;
            string commandText = string.Empty;
            List<EnPedido> pedidos = null;

            try
            {
                commandText = "usp_dateToDate";
                parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("@date1", SqlDbType.DateTime);
                parameters[0].Value = pedido.FechaInicio;
                parameters[1] = new SqlParameter("@date2", SqlDbType.DateTime);
                parameters[1].Value = pedido.FechaFin;
                pedidos = new List<EnPedido>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, "usp_dateToDate", CommandType.StoredProcedure, parameters))
                {
                    while (reader.Read())
                    {
                        pedidos.Add(new EnPedido
                        {
                            IdPedido = reader["IdPedido"] != null ? Convert.ToInt32(reader["IdPedido"]) : 0,
                            IdCliente = reader["IdCliente"] != null ? Convert.ToString(reader["IdCliente"]) : string.Empty,
                            IdEmpleado = reader["IdEmpleado"] != null ? Convert.ToInt32(reader["IdEmpleado"]): 0,
                            FechaPedido = reader["FechaPedido"] != null ? Convert.ToDateTime(reader["FechaPedido"]) : DateTime.MinValue,
                            FechaEntrega = reader["FechaEntrega"] != null ? Convert.ToDateTime(reader["FechaEntrega"]) : DateTime.MinValue,
                            FechaEnvio = reader["FechaEnvio"] != null ? Convert.ToDateTime(reader["FechaEnvio"]) : DateTime.MinValue,
                            FormaEnvio = reader["FormaEnvio"] != null ? Convert.ToInt32(reader["FormaEnvio"]): 0,
                            Cargo = reader["Destinatario"] == null ? Convert.ToInt32(reader["FormaEnvio"]): 0,
                            Destinatario = reader["Destinatario"] != null ? Convert.ToString(reader["Destinatario"]): string.Empty,
                            DireccionDestinatario = reader["CiudadDestinatario"] != null ? Convert.ToString(reader["CiudadDestinatario"]) : string.Empty,
                            RegionDestinatario = reader["RegionDestinatario"] != null ? Convert.ToString(reader["RegionDestinatario"]): string.Empty,
                            CodPostalDestinatario = reader["CodPostalDestinatario"] != null ? Convert.ToString(reader["CodPostalDestinatario"]):  string.Empty,
                            PaisDestinatario = reader["PaisDestinatario"] != null ? Convert.ToString(reader["PaisDestinatario"]): string.Empty
                        });
                    }
                }

            }catch(Exception ex)
            {
                throw ex;
            }
            return pedidos;
        }
    }
}
