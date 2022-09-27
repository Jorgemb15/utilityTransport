using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UtilityTransport_DLL.Logica;
using UtilityTransport_DLL.Models;

namespace UtilityTransport.Controllers
{
    public class loginController : Controller
    {
        // GET: Login
        public ActionResult Index(string strMensaje = null)
        {
            if (!string.IsNullOrEmpty(strMensaje))
            {
                this.ViewBag.strResultadoOperacion = strMensaje;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(loginModel modeloVista)
        {
            if (modeloVista is null || string.IsNullOrEmpty(modeloVista.strUsuario) || string.IsNullOrEmpty(modeloVista.strClave))
            {
                this.ViewBag.strResultadoOperacion = "Por favor ingrese usuario y Clave";
            }
            else
            {
                SP_Validar_Usuario_Result objUsuario = new SP_Validar_Usuario_Result();
                string strResultado = "";
                Boolean lblBVerificado = false;

                try
                {
                    autenticacionService authLogic = new autenticacionService();
                    objUsuario = authLogic.validarUsuario(modeloVista);

                    if (objUsuario != null)
                    {
                        lblBVerificado = true;
                        strResultado = "Bien";
                    }
                    else
                    {
                        strResultado = "Usuario o Clave Incorrectas";
                    }
                }
                catch (Exception Error)
                {
                    lblBVerificado = false;
                    strResultado = "Error : " + Error.Message;
                    if (Error.InnerException != null)
                    {
                        strResultado = "Alerta : " + Error.InnerException.Message;
                    }
                }
                finally
                {
                    if (lblBVerificado == true)
                    {
                        this.Session.Add("SesionIniciada", true);
                        this.Session.Add("DatosUsuario", objUsuario);
                        this.Session.Add("PrimerIngreso", true);
                        FormsAuthentication.Initialize();
                        FormsAuthentication.SetAuthCookie(objUsuario.Codigo, true);
                    }
                    else
                    {
                        ViewBag.strResultadoOperacion = strResultado.Replace("'", "");
                    }
                }

                if (lblBVerificado == true)
                {
                    return RedirectToAction("Index", "Menu");
                }
            }
            return View();
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult SesionExpirada()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index", new { strMensaje = "Sesion Expirada por favor ingrese nuevamente" });
        }

        public ActionResult AccesoDenegado()
        {
            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}