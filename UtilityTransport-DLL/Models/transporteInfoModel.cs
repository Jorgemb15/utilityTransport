using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityTransport_DLL.Models
{
    public class transporteInfoModel
    {
        public Boolean lblPuedeEnviar { get; set; }
        public int Codigo { get; set; }
        public string NumFactura { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public int Prioridad { get; set; }
        public string Cliente { get; set; }
        public string Detalle { get; set; }
        public string UsuarioCrea { get; set; }
        public System.DateTime FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public System.DateTime FechaModifica { get; set; }
        public Nullable<decimal> Monto { get; set; }
        public string Vendedor { get; set; }
        public string Chofer { get; set; }
        public string DetallePago { get; set; }
    }
}
