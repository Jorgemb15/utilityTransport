﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UtilityTransport_DLL.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class utilityTransportEntities : DbContext
    {
        public utilityTransportEntities()
            : base("name=utilityTransportEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual ObjectResult<string> SP_Cambio_Clave(string pCodUsuario, string pClave, string pIdprograma)
        {
            var pCodUsuarioParameter = pCodUsuario != null ?
                new ObjectParameter("pCodUsuario", pCodUsuario) :
                new ObjectParameter("pCodUsuario", typeof(string));
    
            var pClaveParameter = pClave != null ?
                new ObjectParameter("pClave", pClave) :
                new ObjectParameter("pClave", typeof(string));
    
            var pIdprogramaParameter = pIdprograma != null ?
                new ObjectParameter("pIdprograma", pIdprograma) :
                new ObjectParameter("pIdprograma", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_Cambio_Clave", pCodUsuarioParameter, pClaveParameter, pIdprogramaParameter);
        }
    
        public virtual ObjectResult<SP_Canton_Consulta_Result> SP_Canton_Consulta(Nullable<int> pCodigo, string pNombre, Nullable<int> pCodProvincia)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pCodProvinciaParameter = pCodProvincia.HasValue ?
                new ObjectParameter("pCodProvincia", pCodProvincia) :
                new ObjectParameter("pCodProvincia", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Canton_Consulta_Result>("SP_Canton_Consulta", pCodigoParameter, pNombreParameter, pCodProvinciaParameter);
        }
    
        public virtual ObjectResult<SP_Chofer_Consulta_Result> SP_Chofer_Consulta()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Chofer_Consulta_Result>("SP_Chofer_Consulta");
        }
    
        public virtual ObjectResult<SP_Distrito_Consulta_Result> SP_Distrito_Consulta(Nullable<int> pCodigo, string pNombre, Nullable<int> pCodCanton)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pCodCantonParameter = pCodCanton.HasValue ?
                new ObjectParameter("pCodCanton", pCodCanton) :
                new ObjectParameter("pCodCanton", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Distrito_Consulta_Result>("SP_Distrito_Consulta", pCodigoParameter, pNombreParameter, pCodCantonParameter);
        }
    
        public virtual ObjectResult<SP_Obtener_Permisos_Usuario_Result> SP_Obtener_Permisos_Usuario(string pUsuario)
        {
            var pUsuarioParameter = pUsuario != null ?
                new ObjectParameter("pUsuario", pUsuario) :
                new ObjectParameter("pUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Obtener_Permisos_Usuario_Result>("SP_Obtener_Permisos_Usuario", pUsuarioParameter);
        }
    
        public virtual ObjectResult<SP_Perfil_Consulta_Result> SP_Perfil_Consulta(Nullable<int> pCodigo, string pNombre)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Perfil_Consulta_Result>("SP_Perfil_Consulta", pCodigoParameter, pNombreParameter);
        }
    
        public virtual ObjectResult<SP_Permiso_Consulta_Result> SP_Permiso_Consulta(Nullable<int> pCodigo, string pNombre)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Permiso_Consulta_Result>("SP_Permiso_Consulta", pCodigoParameter, pNombreParameter);
        }
    
        public virtual ObjectResult<SP_Provincia_Consulta_Result> SP_Provincia_Consulta(Nullable<int> pCodigo, string pNombre)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Provincia_Consulta_Result>("SP_Provincia_Consulta", pCodigoParameter, pNombreParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_Transporte_Asignar_Prioridad(Nullable<int> pCodigo, Nullable<int> pPrioridad)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            var pPrioridadParameter = pPrioridad.HasValue ?
                new ObjectParameter("pPrioridad", pPrioridad) :
                new ObjectParameter("pPrioridad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_Transporte_Asignar_Prioridad", pCodigoParameter, pPrioridadParameter);
        }
    
        public virtual ObjectResult<SP_Transporte_Consulta_Result> SP_Transporte_Consulta(Nullable<int> pCodigo, string pCliente, Nullable<int> pEstado, Nullable<System.DateTime> pFechaDesde, Nullable<System.DateTime> pFechaHasta)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            var pClienteParameter = pCliente != null ?
                new ObjectParameter("pCliente", pCliente) :
                new ObjectParameter("pCliente", typeof(string));
    
            var pEstadoParameter = pEstado.HasValue ?
                new ObjectParameter("pEstado", pEstado) :
                new ObjectParameter("pEstado", typeof(int));
    
            var pFechaDesdeParameter = pFechaDesde.HasValue ?
                new ObjectParameter("pFechaDesde", pFechaDesde) :
                new ObjectParameter("pFechaDesde", typeof(System.DateTime));
    
            var pFechaHastaParameter = pFechaHasta.HasValue ?
                new ObjectParameter("pFechaHasta", pFechaHasta) :
                new ObjectParameter("pFechaHasta", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Transporte_Consulta_Result>("SP_Transporte_Consulta", pCodigoParameter, pClienteParameter, pEstadoParameter, pFechaDesdeParameter, pFechaHastaParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_Transporte_Enviar(string pParametros)
        {
            var pParametrosParameter = pParametros != null ?
                new ObjectParameter("pParametros", pParametros) :
                new ObjectParameter("pParametros", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_Transporte_Enviar", pParametrosParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> SP_Transporte_Mantenimiento(string pProceso, string pParametros)
        {
            var pProcesoParameter = pProceso != null ?
                new ObjectParameter("pProceso", pProceso) :
                new ObjectParameter("pProceso", typeof(string));
    
            var pParametrosParameter = pParametros != null ?
                new ObjectParameter("pParametros", pParametros) :
                new ObjectParameter("pParametros", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("SP_Transporte_Mantenimiento", pProcesoParameter, pParametrosParameter);
        }
    
        public virtual ObjectResult<SP_Transporte_Obtener_Result> SP_Transporte_Obtener(Nullable<int> pCodigo)
        {
            var pCodigoParameter = pCodigo.HasValue ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Transporte_Obtener_Result>("SP_Transporte_Obtener", pCodigoParameter);
        }
    
        public virtual ObjectResult<SP_Transporte_Obtener_NumFactura_Result> SP_Transporte_Obtener_NumFactura(string pNumFactura)
        {
            var pNumFacturaParameter = pNumFactura != null ?
                new ObjectParameter("pNumFactura", pNumFactura) :
                new ObjectParameter("pNumFactura", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Transporte_Obtener_NumFactura_Result>("SP_Transporte_Obtener_NumFactura", pNumFacturaParameter);
        }
    
        public virtual ObjectResult<SP_Ubicacion_Obtener_Result> SP_Ubicacion_Obtener(Nullable<int> pCodDistrito)
        {
            var pCodDistritoParameter = pCodDistrito.HasValue ?
                new ObjectParameter("pCodDistrito", pCodDistrito) :
                new ObjectParameter("pCodDistrito", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Ubicacion_Obtener_Result>("SP_Ubicacion_Obtener", pCodDistritoParameter);
        }
    
        public virtual ObjectResult<SP_Usuario_Consulta_Result> SP_Usuario_Consulta(string pCodigo, string pNombre, string pCedula)
        {
            var pCodigoParameter = pCodigo != null ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(string));
    
            var pNombreParameter = pNombre != null ?
                new ObjectParameter("pNombre", pNombre) :
                new ObjectParameter("pNombre", typeof(string));
    
            var pCedulaParameter = pCedula != null ?
                new ObjectParameter("pCedula", pCedula) :
                new ObjectParameter("pCedula", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Usuario_Consulta_Result>("SP_Usuario_Consulta", pCodigoParameter, pNombreParameter, pCedulaParameter);
        }
    
        public virtual ObjectResult<string> SP_Usuario_Mantenimiento(string pProceso, string pParametros)
        {
            var pProcesoParameter = pProceso != null ?
                new ObjectParameter("pProceso", pProceso) :
                new ObjectParameter("pProceso", typeof(string));
    
            var pParametrosParameter = pParametros != null ?
                new ObjectParameter("pParametros", pParametros) :
                new ObjectParameter("pParametros", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("SP_Usuario_Mantenimiento", pProcesoParameter, pParametrosParameter);
        }
    
        public virtual ObjectResult<SP_Usuario_Obtener_Result> SP_Usuario_Obtener(string pCodigo)
        {
            var pCodigoParameter = pCodigo != null ?
                new ObjectParameter("pCodigo", pCodigo) :
                new ObjectParameter("pCodigo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Usuario_Obtener_Result>("SP_Usuario_Obtener", pCodigoParameter);
        }
    
        public virtual ObjectResult<SP_Usuario_Perfil_Consulta_Result> SP_Usuario_Perfil_Consulta(string pCodUsuario)
        {
            var pCodUsuarioParameter = pCodUsuario != null ?
                new ObjectParameter("pCodUsuario", pCodUsuario) :
                new ObjectParameter("pCodUsuario", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Usuario_Perfil_Consulta_Result>("SP_Usuario_Perfil_Consulta", pCodUsuarioParameter);
        }
    
        public virtual ObjectResult<SP_Validar_Usuario_Result> SP_Validar_Usuario(string pTipoAutenticacion, string pUsuario, string pClave, string pIdPrograma)
        {
            var pTipoAutenticacionParameter = pTipoAutenticacion != null ?
                new ObjectParameter("pTipoAutenticacion", pTipoAutenticacion) :
                new ObjectParameter("pTipoAutenticacion", typeof(string));
    
            var pUsuarioParameter = pUsuario != null ?
                new ObjectParameter("pUsuario", pUsuario) :
                new ObjectParameter("pUsuario", typeof(string));
    
            var pClaveParameter = pClave != null ?
                new ObjectParameter("pClave", pClave) :
                new ObjectParameter("pClave", typeof(string));
    
            var pIdProgramaParameter = pIdPrograma != null ?
                new ObjectParameter("pIdPrograma", pIdPrograma) :
                new ObjectParameter("pIdPrograma", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SP_Validar_Usuario_Result>("SP_Validar_Usuario", pTipoAutenticacionParameter, pUsuarioParameter, pClaveParameter, pIdProgramaParameter);
        }
    }
}