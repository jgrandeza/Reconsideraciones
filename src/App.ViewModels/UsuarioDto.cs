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
        public string Email { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombres { get; set; }
        public int UnidadEjecutoraId { get; set; }
        public string PerfilId { get; set; }
        public string AreaSigla { get; set; }
        public string Foto { get; set; }
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
