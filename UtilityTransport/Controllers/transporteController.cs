using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UtilityTransport_DLL.Logica;
using UtilityTransport_DLL.Models;

namespace UtilityTransport.Controllers
{
    public class transporteController : Controller
    {
        private transporteService transportService = new transporteService();
        private const string strIdPantallaRegistro = "6";
        private const string strIdPantallaDashboard = "7";
        private const string strIdPantallaPrioridad = "8";

        [autorizacionService(Roles = strIdPantallaRegistro)]
        public ActionResult Registrar(string strCodProceso = clsConstantes.strCodigoInsertar)
        {
            switch (strCodProceso)
            {
                case clsConstantes.strCodigoInsertar:
                    ViewBag.strCodProceso = clsConstantes.strCodigoInsertar;
                    break;
                case clsConstantes.strCodigoModificar:
                    ViewBag.strCodProceso = clsConstantes.strCodigoModificar;
                    break;
            }

            CargarChoferes();

            return View();
        }

        void CargarChoferes()
        {
            ViewBag.lstChoferes = transportService.ConsultaChofer();
        }

        [HttpPost]
        [autorizacionService(Roles = strIdPantallaRegistro)]
        public ActionResult Registrar(transporteModel objModeloVista)
        {
            string strResultado = null;

            try
            {
                SP_Validar_Usuario_Result DatosUsuario = (SP_Validar_Usuario_Result)this.Session["DatosUsuario"];

                if (!string.IsNullOrEmpty(Request["btnGuardar"]))
                {
                    switch (Request["CodProceso"].ToString())
                    {
                        case clsConstantes.strCodigoInsertar:
                            objModeloVista.UsuarioCrea = DatosUsuario.Codigo;
                            objModeloVista.FechaCrea = DateTime.Now;
                            objModeloVista.UsuarioModifica = DatosUsuario.Codigo;
                            objModeloVista.FechaModifica = DateTime.Now;
                            objModeloVista.FechaRegistro = DateTime.Now;
                            objModeloVista.Prioridad = 99;
                            objModeloVista.Codigo = transportService.actualizar(clsConstantes.strCodigoInsertar, objModeloVista);
                            strResultado = "Transporte Registrado Correctamente.";
                            break;
                        case clsConstantes.strCodigoModificar:
                            SP_Transporte_Obtener_NumFactura_Result objTrasporteFactura = transportService.obtenerxNumFactura(objModeloVista.NumFactura);

                            if(objTrasporteFactura is null)
                            {
                                strResultado = "El transporte no pudo ser actualizado, por favor contacte al Administrador.";
                                break;
                            }
                            objTrasporteFactura.Detalle = objModeloVista.Detalle;
                            objTrasporteFactura.Cliente = objModeloVista.Cliente;
                            objTrasporteFactura.DetallePago = objModeloVista.DetallePago;
                            objTrasporteFactura.IdChofer = objModeloVista.IdChofer;
                            objTrasporteFactura.UsuarioModifica = DatosUsuario.Codigo;
                            objTrasporteFactura.FechaModifica = DateTime.Now;
                            objModeloVista = JsonConvert.DeserializeObject<transporteModel>(JsonConvert.SerializeObject(objTrasporteFactura));

                            objModeloVista.Codigo = transportService.actualizar(clsConstantes.strCodigoModificar, objModeloVista);
                            strResultado = "Transporte Modificado Correctamente.";
                            break;
                    }
                    ViewBag.strCodProceso = clsConstantes.strCodigoInsertar;
                    
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
            
            CargarChoferes();

            return View();
        }

        [autorizacionService(Roles = strIdPantallaDashboard)]
        public ActionResult Dashboard(string strMensaje = null)
        {
            List<SP_Transporte_Consulta_Result> lstTransportes = null;
            transporteConsultaModel modeloVista = new transporteConsultaModel();
            string strResultado = "";

            if (!string.IsNullOrEmpty(strMensaje))
            {
                strResultado = strMensaje;
            }
            try
            {
                modeloVista.nCodigo = null;
                modeloVista.strCliente = null;
                modeloVista.nEstado = 0;
                modeloVista.dFechaDesde = DateTime.Now.AddDays(-5);
                modeloVista.dFechaHasta = DateTime.Now;
                lstTransportes = transportService.consulta(modeloVista);

                int nPrioridad = 0;
                foreach(SP_Transporte_Consulta_Result transporte in lstTransportes.OrderBy(x=> x.Prioridad).ThenBy(x=> x.FechaRegistro).ToList())
                {
                    if (transporte.Estado == 0)
                    {
                        nPrioridad = nPrioridad + 1;
                        transporte.Prioridad = nPrioridad;
                    }
                }
                lstTransportes = lstTransportes.OrderBy(x => x.Estado).ThenBy(x => x.Prioridad).ThenBy(x => x.FechaRegistro).ToList();
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
                if (lstTransportes == null)
                {
                    lstTransportes = new List<SP_Transporte_Consulta_Result>();
                }
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            ViewBag.lstTransportes = lstTransportes;

            
            return View(modeloVista);
        }

        [HttpPost]
        public ActionResult Dashboard(transporteConsultaModel objConsulta)
        {
            List<SP_Transporte_Consulta_Result> lstTransportes = null;
            string strResultado = "";

            try
            {
                lstTransportes = transportService.consulta(objConsulta);

                int nPrioridad = 0;
                foreach (SP_Transporte_Consulta_Result transporte in lstTransportes.OrderBy(x => x.Prioridad).ThenBy(x => x.FechaRegistro).ToList())
                {
                    if (transporte.Estado == 0)
                    {
                        nPrioridad = nPrioridad + 1;
                        transporte.Prioridad = nPrioridad;
                    }
                }
                lstTransportes = lstTransportes.OrderBy(x => x.Estado).ThenBy(x => x.Prioridad).ThenBy(x => x.FechaRegistro).ToList();
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
                if (lstTransportes == null)
                {
                    lstTransportes = new List<SP_Transporte_Consulta_Result>();
                }
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            ViewBag.lstTransportes = lstTransportes;

            return View(objConsulta);
        }

        public ActionResult obtenerFactura(string strNumFactura)
        {
            string strCliente = null;
            string strDetalle = null;
            decimal? nMonto = 0;
            string strVendedor = null;
            string strDetallePago = null;
            int nIdChofer = 0;
            Boolean lblRegistrada = false;
            Boolean lblEditable = false;
            SP_Transporte_Obtener_NumFactura_Result objTrasporte = transportService.obtenerxNumFactura(strNumFactura);

            if(objTrasporte is null)
            {
                SP_Transporte_Factura_Obtener_Result factura = transportService.ObtenerFactura(strNumFactura);
                if (factura != null)
                {
                    strCliente = factura.NOMBRE;
                    nMonto = factura.Total;
                    strVendedor = factura.Vendedor;
                }
            }
            else
            {
                lblRegistrada = true;
                strCliente = objTrasporte.Cliente;
                strDetalle = objTrasporte.Detalle;
                nMonto = objTrasporte.Monto;
                strVendedor = objTrasporte.Vendedor;
                strDetallePago = objTrasporte.DetallePago;
                nIdChofer = objTrasporte.IdChofer;
                lblEditable = objTrasporte.Estado == 0 ? true : false;
            }

            return new JsonResult()
            {
                Data = new
                {
                    lblRegistrada = lblRegistrada,
                    lblEditable = lblEditable,
                    strCliente = strCliente,
                    strDetalle = strDetalle,
                    nMonto = nMonto,
                    strVendedor = strVendedor,
                    nIdChofer = nIdChofer,
                    strDetallePago = strDetallePago
                }
            };
        }

        [AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        public ActionResult MostrarDetalleTransporte(int nCodigo, Boolean lblPuedeEnviar)
        {
            SP_Transporte_Obtener_Result ModeloVista = null;
            string strResultado = "";

            try
            {
                if (nCodigo > 0)
                {
                    ModeloVista = transportService.obtener(nCodigo);
                }
                else
                {
                    ModeloVista = null;
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
                if (ModeloVista == null)
                {
                    ModeloVista = new SP_Transporte_Obtener_Result();
                }
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            transporteInfoModel objModeloVista = JsonConvert.DeserializeObject<transporteInfoModel>(JsonConvert.SerializeObject(ModeloVista));
            objModeloVista.lblPuedeEnviar = lblPuedeEnviar;
            return this.Request.IsAjaxRequest()
                ? this.PartialView("InfoTransporte", objModeloVista)
                : this.View(objModeloVista) as ActionResult;
        }

        public ActionResult procesarTransporte(int nCodTransporte, string strClave)
        {
            string strResultado = null;
            Boolean lblResultado = false;

            if (!string.IsNullOrEmpty(strClave))
            {
                SP_Validar_Usuario_Result datosUsuario = (SP_Validar_Usuario_Result)this.Session["DatosUsuario"];

                transporteEnviarModel objModelo = new transporteEnviarModel();

                objModelo.CodUsuario = datosUsuario.Codigo;
                objModelo.CodTransporte = nCodTransporte;
                objModelo.IdPrograma = clsConstantes.strIdPrograma;
                objModelo.Clave = strClave;

                try
                {
                    transportService.enviarTransporte(objModelo);
                    lblResultado = true;
                    strResultado = "Transporte Enviado Correctamente.";
                }
                catch(Exception ex)
                {
                    strResultado = ex.InnerException.Message;
                }
            }
            else
            {
                strResultado = "Por favor digite la contraseña";
            }
            return new JsonResult()
            {
                Data = new
                {
                    strResultado = strResultado,
                    lblResultado = lblResultado
                }
            };
        }


        [autorizacionService(Roles = strIdPantallaPrioridad)]
        public ActionResult Prioridad()
        {
            List<SP_Transporte_Consulta_Result> lstTransportes = null;
            transporteConsultaModel objConsulta = new transporteConsultaModel();
            string strResultado = "";

            try
            {
                objConsulta.nCodigo = null;
                objConsulta.strCliente = null;
                objConsulta.nEstado = 0;
                objConsulta.dFechaDesde = DateTime.Now.AddMonths(-1);
                objConsulta.dFechaHasta = DateTime.Now;
                lstTransportes = transportService.consulta(objConsulta);

                int nPrioridad = 0;
                foreach (SP_Transporte_Consulta_Result transporte in lstTransportes.OrderBy(x => x.Prioridad).ThenBy(x => x.FechaRegistro).ToList())
                {
                    if (transporte.Estado == 0)
                    {
                        nPrioridad = nPrioridad + 1;
                        transporte.Prioridad = nPrioridad;
                    }
                }
                lstTransportes = lstTransportes.OrderBy(x => x.Estado).ThenBy(x => x.Prioridad).ThenBy(x => x.FechaRegistro).ToList();
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
                if (lstTransportes == null)
                {
                    lstTransportes = new List<SP_Transporte_Consulta_Result>();
                }
                ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
            }

            return View(lstTransportes);
        }

        [HttpPost]
        public ActionResult Prioridad(List<SP_Transporte_Consulta_Result> modeloVista)
        {
            string strMensaje = "";
            try
            {
                foreach (SP_Transporte_Consulta_Result transporte in modeloVista)
                {
                    transportService.AsignarPrioridad(transporte.Codigo, transporte.Prioridad);
                }
                strMensaje = "Nuevas Prioridades Asignadas, por favor verifique el Dashboard.";
            }
            catch (Exception ex)
            {
                strMensaje = "Error al asignar las prioridades, por favor verifique en en Dashboard.";
            }
            
            return RedirectToAction("Dashboard", new { @strMensaje = strMensaje });
        }
    }
}