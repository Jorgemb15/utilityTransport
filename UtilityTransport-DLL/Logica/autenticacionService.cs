using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityTransport_DLL.Models;

namespace UtilityTransport_DLL.Logica
{
    public class autenticacionService
    {
        utilityTransportEntities modeloBD = new utilityTransportEntities();

        public SP_Validar_Usuario_Result validarUsuario(loginModel objLogin)
        {
            return modeloBD.SP_Validar_Usuario(clsConstantes.strCodigoSqlAutentication, objLogin.strUsuario, objLogin.strClave, clsConstantes.strIdPrograma).FirstOrDefault();
        }

        public string cambioClave(cambioClaveModel objcambioClave)
        {
            return modeloBD.SP_Cambio_Clave(objcambioClave.strUsuario, objcambioClave.strClave, clsConstantes.strIdPrograma).FirstOrDefault();
        }
    }
}
