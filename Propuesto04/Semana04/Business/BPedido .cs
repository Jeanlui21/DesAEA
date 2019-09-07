using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BPedido
    {
        private DPedido DPedido = null;

        public List<EnPedido> GetPedidosEntreFechas(DateTime FechaInicio, DateTime FechaFin)
        {
            List<EnPedido> pedidos = null;
            try
            {
                DPedido = new DPedido();
                pedidos = DPedido.GetPedidos(new EnPedido { FechaInicio = FechaInicio, FechaFin = FechaFin });
            }
            catch (Exception e)
            {
                throw e;
            }
            return pedidos;
        }
    }
}
