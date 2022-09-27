using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityTransport_DLL.Models;

namespace UtilityTransport_DLL.Logica
{
    public class ubicacionService
    {
        utilityTransportEntities modeloBD = new utilityTransportEntities();
        public List<SP_Provincia_Consulta_Result> consultaProvincia(provinciaConsultaModel objConsultaProvincia)
        {
            return modeloBD.SP_Provincia_Consulta(objConsultaProvincia.nCodigo, objConsultaProvincia.strNombre).ToList();
        }

        public List<SP_Canton_Consulta_Result> consultaCanton(cantonConsultaModel objcantonConsulta)
        {
            return modeloBD.SP_Canton_Consulta(objcantonConsulta.nCodigo, objcantonConsulta.strNombre, objcantonConsulta.nCodProvincia).ToList();
        }

        public List<SP_Distrito_Consulta_Result> consultaDistrito(distritoConsultaModel objdistritoConsulta)
        {
            return modeloBD.SP_Distrito_Consulta(objdistritoConsulta.nCodigo, objdistritoConsulta.strNombre, objdistritoConsulta.nCodCanton).ToList();
        }

        public SP_Ubicacion_Obtener_Result CargarUbicacionCliente(int nCodDistrito)
        {
            return modeloBD.SP_Ubicacion_Obtener(nCodDistrito).FirstOrDefault();
        }
    }
}
