using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity;

namespace Business
{
    public class BDetalleDePedido
    {
        private DDetallePedido DDetallePedido = null;

        public List<EnDetallePedido> GetEDetalleDePedidosPorId(int IdPedido)
        {
            List<EnDetallePedido> detalleDePedidos = null;
            try
            {
                DDetallePedido = new DDetallePedido();
                detalleDePedidos = DDetallePedido.GetDetallePedidos(new EnDetallePedido { EnPedido = new EnPedido { IdPedido = IdPedido } });
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DDetallePedido = null;
            }
            return detalleDePedidos;
        }

        public decimal GetDetalleTotalPorId(int IdPedido)
        {
            List<EnDetallePedido> DetalleDePedido = null;
            decimal total = 0;
            try
            {
                DDetallePedido = new DDetallePedido();
                DetalleDePedido = DDetallePedido.GetDetallePedidos(new EnDetallePedido { EnPedido = new EnPedido() { IdPedido = IdPedido } });

                foreach (var item in DetalleDePedido)
                {
                    total = total + item.Cantidad * item.Preciounidad - item.Descuento;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                DetalleDePedido = null;
            }
            return total;
        }
    }


}