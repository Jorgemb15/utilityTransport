using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityTransport_DLL.Logica;
using UtilityTransport_DLL.Models;

namespace UtilityTransport.Controllers
{
    [autorizacionService]
    public class menuController : Controller
    {
        private const string strIdPantalla = "1";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CargarNotificaciones()
        {
            return Json(new JsonResult());
        }

        public ActionResult CambiarClave()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CambiarClave(cambioClaveModel objCambioClave)
        {
            string strResultado = "";

            try
            {

                if (objCambioClave.strClave.Equals(objCambioClave.strClaveConfirma))
                {
                    SP_Validar_Usuario_Result datosUsuario = (SP_Validar_Usuario_Result)this.Session["DatosUsuario"];
                    autenticacionService authLogic = new autenticacionService();
                    objCambioClave.strUsuario = datosUsuario.Codigo;
                    objCambioClave.strClave = authLogic.cambioClave(objCambioClave);
                    if (objCambioClave.strClaveConfirma.Equals(objCambioClave.strClave))
                    {
                        strResultado = "Cambio de clave exitoso";
                    }
                    else
                    {
                        strResultado = "No se logro hacer el Cambio de Clave";
                    }
                }
                else
                {
                    strResultado = "La confirmacion de la contraseña no es la correcta";
                }
            }
            catch (Exception error)
            {
                strResultado = "Ocurrió un Error al Listar : " + error.Message;

                if (error.InnerException != null)
                {
                    strResultado = "Ocurrió un Error al Listar : " + error.InnerException.Message;
                }

            }
            finally
            {
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            return View();
        }
    }
}