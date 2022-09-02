using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace App.Models
{
    public class Persona
    {
        [Key]
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
        public bool? PerteneceEmpresa { get; set; }
        public int? TipoColegiaturaId { get; set; }
        public string? NroColegiatura { get; set; }
        public DateTime? FechaDesignacion { get; set; }
        public string? FotoBase64 { get; set; }
        public string TipoPersona { get; set; }

    }
}
