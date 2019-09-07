using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Data
{
    public class DDetallePedido
    {
        public List<EnDetallePedido> GetDetallePedidos (EnDetallePedido enDetallePedido)
        {
            SqlParameter[] parameters = null; //Necesario para sentencias
            string commandText = string.Empty; // la sentencia en si
            List<EnDetallePedido> detalleDePedido = null; // La lista vacia

            try
            {
                commandText = "USP_DetallesPedido";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idPedido", SqlDbType.Int);
                parameters[0].Value = enDetallePedido.EnPedido.IdPedido;
                detalleDePedido = new List<EnDetallePedido>();

                using (SqlDataReader dr = SqlHelper.ExecuteReader(SqlHelper.Connection, commandText, CommandType.StoredProcedure, parameters))
                {
                    while (dr.Read())
                    {
                        detalleDePedido.Add(new EnDetallePedido
                        {
                            Idpedido = dr["idpedido"] != null ? Convert.ToInt32(dr["idpedido"]) : 0,
                            Idproducto = dr["idproducto"] != null ? Convert.ToInt32(dr["idproducto"]) : 0,
                            Preciounidad = dr["preciounidad"] != null ? Convert.ToDecimal(dr["preciounidad"]) : 0,
                            Cantidad = dr["cantidad"] != null ? Convert.ToInt32(dr["cantidad"]) : 0,
                            Descuento = dr["descuento"] != null ? Convert.ToDecimal(dr["descuento"]) : 0
                        });
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }
    }
}
