using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilityTransport_DLL.Models
{
    public class usuarioModel
    {
        public string Codigo { get; set; }
        public string UsuarioWindows { get; set; }
        public string Clave { get; set; }
        public string Clave_Confirma { get; set; }
        public string Estado { get; set; }
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Genero { get; set; }
        public System.DateTime Fecha_Nacimiento { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Correo { get; set; }
        public int Cod_Distrito { get; set; }
        public string UsuarioCrea { get; set; }
        public Nullable<System.DateTime> FechaCrea { get; set; }
        public string UsuarioModifica { get; set; }
        public Nullable<System.DateTime> FechaModifica { get; set; }
        public int Cod_Perfil { get; set; }
        public string IdPrograma { get; set; }

}
}
