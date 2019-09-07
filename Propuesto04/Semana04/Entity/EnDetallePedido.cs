using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class EnDetallePedido
    {
        public int Idpedido { get; set; }
        public int Idproducto { get; set; }
        public decimal Preciounidad { get; set; }
        public int Cantidad { get; set; }
        public decimal Descuento { get; set; }

        public EnPedido EnPedido { get; set; }
    }
}
