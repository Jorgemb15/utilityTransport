using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityTransport_DLL.Logica;
using UtilityTransport_DLL.Models;

namespace UtilityTransport.Controllers
{
    public class ubicacionController : Controller
    {
        ubicacionService ubiService = new ubicacionService();

        public ActionResult CargarCantones(int nCodProvincia)
        {
            cantonConsultaModel cantonConsulta = new cantonConsultaModel();
            cantonConsulta.nCodProvincia = nCodProvincia;

            List<SP_Canton_Consulta_Result> lstCantones = ubiService.consultaCanton(cantonConsulta).ToList();

            return Json(lstCantones);
        }

        public ActionResult CargarDistritos(int nCodCanton)
        {
            distritoConsultaModel distritoConsulta = new distritoConsultaModel();
            distritoConsulta.nCodCanton = nCodCanton;

            List<SP_Distrito_Consulta_Result> lstCantones = ubiService.consultaDistrito(distritoConsulta).ToList();

            return Json(lstCantones);
        }

        public ActionResult CargarUbicacion(int nCodDistrito)
        {
            SP_Ubicacion_Obtener_Result objUbicacion = ubiService.CargarUbicacionCliente(nCodDistrito);

            return Json(objUbicacion);
        }

    }
}