using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityTransport_DLL.Models
{
    public class perfilService
    {
        utilityTransportEntities modeloBD = new utilityTransportEntities();
        public List<SP_Perfil_Consulta_Result> Consulta(perfilConsultaModel objPerfilConsulta)
        {
            return modeloBD.SP_Perfil_Consulta(objPerfilConsulta.nCodigo, objPerfilConsulta.strNombre).ToList();
        }

        public SP_Usuario_Perfil_Consulta_Result ObtenerPerfilUsuario(string strCodUsuario)
        {
            return modeloBD.SP_Usuario_Perfil_Consulta(strCodUsuario).FirstOrDefault();
        }
    }
}
