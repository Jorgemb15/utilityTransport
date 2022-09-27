using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityTransport_DLL.Models;

namespace UtilityTransport_DLL.Logica
{
    public class transporteService
    {
        utilityTransportEntities modeloBD = new utilityTransportEntities();
        SoftlandEntities modeloBDSoftland = new SoftlandEntities();

        public List<SP_Transporte_Consulta_Result> consulta(transporteConsultaModel objUsuarioConsulta)
        {
            return modeloBD.SP_Transporte_Consulta(objUsuarioConsulta.nCodigo, objUsuarioConsulta.strCliente, objUsuarioConsulta.nEstado, objUsuarioConsulta.dFechaDesde, objUsuarioConsulta.dFechaHasta).ToList();
        }

        public List<SP_Chofer_Consulta_Result> ConsultaChofer()
        {
            return modeloBD.SP_Chofer_Consulta().ToList();
        }

        public SP_Transporte_Obtener_Result obtener(int nCodigo)
        {
            return modeloBD.SP_Transporte_Obtener(nCodigo).FirstOrDefault();
        }

        public SP_Transporte_Obtener_NumFactura_Result obtenerxNumFactura(string strNumFactura)
        {
            return modeloBD.SP_Transporte_Obtener_NumFactura(strNumFactura).FirstOrDefault();
        }

        public SP_Transporte_Factura_Obtener_Result ObtenerFactura(string objNumFactura)
        {
            return modeloBDSoftland.SP_Transporte_Factura_Obtener(objNumFactura).FirstOrDefault();
        }

        public int? actualizar(string strProceso, transporteModel objModelo)
        {
            clsConstantes clsConst = new clsConstantes();
            string ObjetoProceso = "";
            ObjetoProceso = clsConst.RetornaXML<transporteModel>(objModelo);
            return modeloBD.SP_Transporte_Mantenimiento(strProceso, ObjetoProceso).FirstOrDefault();
        }


        public void enviarTransporte(transporteEnviarModel objEnviarTranspoorte)
        {
            clsConstantes clsConst = new clsConstantes();
            string ObjetoProceso = "";
            ObjetoProceso = clsConst.RetornaXML<transporteEnviarModel>(objEnviarTranspoorte);
            modeloBD.SP_Transporte_Enviar(ObjetoProceso);
        }

        public int? AsignarPrioridad(int nCodigo, int nPrioridad)
        {
            return modeloBD.SP_Transporte_Asignar_Prioridad(nCodigo, nPrioridad).FirstOrDefault();
        }
    }
}
