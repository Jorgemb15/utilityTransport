using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityTransport_DLL.Models
{
    public class transporteConsultaModel
    {
        public int? nCodigo { get; set; }
        public string strCliente { get; set; }
        public int? nEstado { get; set; }
        public DateTime dFechaDesde { get; set; }
        public DateTime dFechaHasta { get; set; }
    }
}
