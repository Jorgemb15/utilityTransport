using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UtilityTransport_DLL.Logica
{
    public class clsConstantes
    {
        public const string strCodigoInsertar = "I";
        public const string strCodigoModificar = "M";
        public const string strCodigoEliminar = "E";
        public const string strCodigoVisualizar = "V";
        public const string strCodigoConsulta = "C";
        public const string strCodigoLimpiar = "L";
        public const string strCodigoWindowsAutentication = "W";
        public const string strCodigoSqlAutentication = "S";
        public static readonly string strIdPrograma = ConfigurationManager.AppSettings["IdPrograma"];

        public string RetornaXML<T>(object pObjeto)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            MemoryStream m = new MemoryStream();
            ser.Serialize(m, pObjeto);
            m.Position = 0;
            string xml = new StreamReader(m).ReadToEnd();
            return xml;
        }

    }
}
