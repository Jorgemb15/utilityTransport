using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityTransport_DLL.Logica;
using UtilityTransport_DLL.Models;

namespace UtilityTransport.Controllers
{
    [autorizacionService]
    public class usuarioController : Controller
    {
        private usuarioService userService = new usuarioService();
        private perfilService perService = new perfilService();
        private const string strIdPantallaLista = "3";
        private const string strIdPantallaMantenimiento = "4";

        [autorizacionService(Roles = strIdPantallaLista)]
        public ActionResult Lista()
        {

            List<SP_Usuario_Consulta_Result> modeloVista = null;
            string strResultado = "";

            try
            {
                modeloVista = userService.consulta(new usuarioConsultaModel());
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
                if (modeloVista == null)
                {
                    modeloVista = new List<SP_Usuario_Consulta_Result>();
                }
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            return View(modeloVista);
        }

        [HttpPost]
        [autorizacionService(Roles = strIdPantallaLista)]
        public ActionResult Lista(usuarioConsultaModel objModeloVista)
        {
            List<SP_Usuario_Consulta_Result> ModeloVista = null;
            string strResultado = "";

            try
            {
                ModeloVista = userService.consulta(objModeloVista);
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
                if (ModeloVista == null)
                {
                    ModeloVista = new List<SP_Usuario_Consulta_Result>();
                }
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            return View(ModeloVista);
        }

        [autorizacionService(Roles = strIdPantallaMantenimiento)]
        public ActionResult Mantenimiento(string strCodProceso = clsConstantes.strCodigoInsertar, string strCodigo = "")
        {
            usuarioModel ModeloVista = new usuarioModel();

            string strResultado = "";

            try
            {
                switch (strCodProceso)
                {
                    case clsConstantes.strCodigoInsertar:
                        ViewBag.strCodProceso = clsConstantes.strCodigoInsertar;
                        break;
                    case clsConstantes.strCodigoModificar:
                        ViewBag.strCodProceso = clsConstantes.strCodigoModificar;
                        ModeloVista = JsonConvert.DeserializeObject<usuarioModel>(JsonConvert.SerializeObject(userService.obtener(strCodigo)));
                        SP_Usuario_Perfil_Consulta_Result perfilUsuario = perService.ObtenerPerfilUsuario(ModeloVista.Codigo);
                        if(perfilUsuario  != null)
                        {
                            ModeloVista.Cod_Perfil = perfilUsuario.CodPerfil;
                        }
                        break;
                }
            }
            catch (Exception error)
            {
                strResultado = "Ocurrió un Error al Obtener : " + error.Message;

                if (error.InnerException != null)
                {
                    strResultado = "Ocurrió un Error al Obtener : " + error.InnerException.Message;
                }
            }
            finally
            {
                if (ModeloVista == null)
                {
                    ModeloVista = new usuarioModel();
                }
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");

            }

            CargarDatosVista();

            return View(ModeloVista);
        }

        [HttpPost]
        [autorizacionService(Roles = strIdPantallaMantenimiento)]
        public ActionResult Mantenimiento(usuarioModel objModeloVista)
        {
            SP_Validar_Usuario_Result DatosUsuario = (SP_Validar_Usuario_Result)this.Session["DatosUsuario"];

            string strResultado = "";

            try
            {
                
                if (!string.IsNullOrEmpty(Request["btnGuardar"]))
                {
                    switch (Request["CodProceso"].ToString())
                    {
                        case clsConstantes.strCodigoInsertar:
                            objModeloVista.UsuarioCrea = DatosUsuario.Codigo;
                            objModeloVista.FechaCrea = DateTime.Now;
                            objModeloVista.UsuarioModifica = DatosUsuario.Codigo;
                            objModeloVista.FechaModifica = DateTime.Now;
                            objModeloVista.Codigo = userService.actualizar(clsConstantes.strCodigoInsertar, objModeloVista);
                            break;
                        case clsConstantes.strCodigoModificar:
                            objModeloVista.UsuarioModifica = DatosUsuario.Codigo;
                            objModeloVista.FechaModifica = DateTime.Now;
                            objModeloVista.Codigo = userService.actualizar(clsConstantes.strCodigoModificar, objModeloVista);
                            break;
                    }
                    ViewBag.strCodProceso = clsConstantes.strCodigoModificar;
                    strResultado = "Actualización de Registro Exitosa";
                }
            }
            catch (Exception error)
            {
                strResultado = "Ocurrió un Error  : " + error.Message;
                if (error.InnerException != null)
                {
                    strResultado = error.InnerException.Message;
                }
                ViewBag.strCodProceso = Request["CodProceso"].ToString();
            }
            finally
            {
                if (objModeloVista == null)
                {
                    objModeloVista = new usuarioModel();
                }

                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            CargarDatosVista();

            return View(objModeloVista);
        }

        private void CargarDatosVista()
        {
            ubicacionService ubiService = new ubicacionService();
            ViewBag.lstProvincia = ubiService.consultaProvincia(new provinciaConsultaModel());
            ViewBag.lstPerfil = perService.Consulta(new perfilConsultaModel());
        }

    }
}