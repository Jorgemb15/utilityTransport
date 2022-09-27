using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityTransport_DLL.Models;

namespace UtilityTransport_DLL.Logica
{
    public class usuarioService
    {
        utilityTransportEntities modeloBD = new utilityTransportEntities();
        public List<SP_Usuario_Consulta_Result> consulta(usuarioConsultaModel objUsuarioConsulta)
        {
            return modeloBD.SP_Usuario_Consulta(objUsuarioConsulta.strCodigo, objUsuarioConsulta.strNombre, objUsuarioConsulta.strCedula).ToList();
        }

        public SP_Usuario_Obtener_Result obtener(string strCodigo)
        {
            return modeloBD.SP_Usuario_Obtener(strCodigo).FirstOrDefault();
        }

        public string actualizar(string strProceso, usuarioModel objUsuario)
        {
            clsConstantes clsConst = new clsConstantes();
            string ObjetoProceso = "";
            objUsuario.IdPrograma = clsConstantes.strIdPrograma;
            ObjetoProceso = clsConst.RetornaXML<usuarioModel>(objUsuario);
            return modeloBD.SP_Usuario_Mantenimiento(strProceso, ObjetoProceso).FirstOrDefault();
        }
    }
}
