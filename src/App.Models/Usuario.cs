using System;
using System.Collections.Generic;
using System.Text;

namespace App.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int PerfilId { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmacion { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public int PersonaId { get; set; }
        public int UnidadEjecutoraId { get; set; }
        public string Foto { get; set; }
        public string Nombres { get; set; }
    }
}
