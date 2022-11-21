using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.ViewModels
{
    public class UsuarioLoginDto
    {
        
        public string Email { get; set; }
       
        public string password { get; set; }
       
        public bool Recordar { get; set; }
        
    }
    public class UsuarioClaimsDto
    {
        public int Id { get; set; }
        public string V_V_USU_EMAIL { get; set; }
        public string USU_USUARIO { get; set; }
        public string USU_UE { get; set; }
        public string USU_PPDD { get; set; }
        public string USU_ODSIS { get; set; }
        public string USU_OBLIGACAMBIARCLAVE { get; set; }
        public string USU_NOMBREUSUARIO { get; set; }
        public string USU_N_TIPODOCUMENTO { get; set; }
        public string USU_IDLUGARTRABAJO { get; set; }
        public string USU_IDCENTRODIGITACION { get; set; }
        public string USU_ID_REDES { get; set; }
        public string USU_ID_CONTRATOIPRESS { get; set; }
        public string USU_ID { get; set; }
        public string USU_GMR_DESCRIPCION { get; set; }
        public string USU_EMAILINSTITUCIONAL { get; set; }
        public string USU_DNI { get; set; }
        public string USU_DISA { get; set; }
        public string USU_ACCESOAFILIACION { get; set; }
        public string UE_DESCRIPCION { get; set; }
        public string TOKENSESION { get; set; }
        public string TOKENSALIDA { get; set; }
        public string SID_APP { get; set; }
        public string ROL_DESCRIPCION { get; set; }
        public string RESPUESTATOKENSESION { get; set; }
        public string RED_DESCRIPCION { get; set; }
        public string PPDD_DESCRIPCION { get; set; }
        public string ODSIS_DESCRIPCION { get; set; }
        public string MENSAJE { get; set; }
        public string LUGARTRAB_DESC { get; set; }
        public string IDROL { get; set; }
        public string ID_SUBMODULO { get; set; }
        public string ID_RESULTADO { get; set; }
        public string ID_MACROREGION { get; set; }
        public string FLAG_NUEVO_CONVENIO { get; set; }
        public string ESTABLECIMIENTO_DESC { get; set; }
        public string ES_DIRESA { get; set; }
        public string EESS_IDESTABLECIMIENTO { get; set; }
        public string EESS_CODIGOSIS { get; set; }
        public string DISA_DESCRIPCION { get; set; }
        public string DEP_IDDEPARTAMENTO { get; set; }
        public string DEP_DESCRIPCION { get; set; }
        public string CI_V_DESCRIPCION { get; set; }
        public string CED_DESCRIPCION { get; set; }
        public string Foto { get; set; }
        public string Name { get; set; }
        public string PROGRAMADOR { get; set; }
        
    }
    public class UsuarioDto
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmacion { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
        public int PersonaId { get; set; }
        public int UnidadEjecutoraId { get; set; }
        public string Foto { get; set; }
        public string Nombres { get; set; }
        public bool Recordar { get; set; }
        public PerfilDto Perfil { get; set; }
        public PersonaDto Persona { get; set; }
        public UnidadEjecutora UnidadEjecutora { get; set; }
    }

    public class PerfilDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }

    public class PersonaDto
    {
        public int Id { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public string Nombres { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NroDocumento { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public bool Estado { get; set; }
        public int TipoPersonaId { get; set; }

        public string? NroRuc { get; set; }
        public string? NroDni { get; set; }
        public string? RazonSocial { get; set; }
        public string ResTipcol { get; set; }
        public bool? PerteneceEmpresa { get; set; }
        public int? TipoColegiaturaId { get; set; }
        public string? NroColegiatura { get; set; }
        public DateTime? FechaDesignacion { get; set; }
        public string? FotoBase64 { get; set; }
        public string TipoPersona { get; set; }
            
        public int ProyectoId { get; set; }
        public int CUI { get; set; }

        public bool? ResInduei { get; set; }
        public bool? ResIndjpr { get; set; }
        public bool? ResIndsup { get; set; }

        public int? IndRes { get; set; }

        public IFormFile file { get; set; }
        public int ProfesionId { get; set; }

    }

    public class UnidadEjecutora
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string DistritoId { get; set; }
        public int TipoUnidadEjecutoraId { get; set; }
    }

    public class UsuarioCreateUpdateDto
    {
        public int Accion { get; set; }
        public int usuarioId { get; set; }
        public int PersonaId { get; set; }
        public int PerfilId { get; set; }
        public string Nombres { get; set; }
        public string ApePaterno { get; set; }
        public string ApeMaterno { get; set; }
        public string Dni { get; set; }
        public string Celular { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int UnidadEjecutoraId { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public int EstadoUsuario { get; set; }

    }

    public class UsuarioChangePassDto
    {
        public string ContraseniaAnt { get; set; }
        public string Contrasenia { get; set; }

    }
}
