using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearClienteDto
    {
        [Display(Name = "Tipo Documento")]
        public int? TipoDocumentoId { get; set; }

        [Display(Name = "Numero")]
        public string? Numero { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Dirección")]
        public string? Direccion { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }

        [Display(Name = "Representante")]
        public string? NombreRepresentante { get; set; }

        [Display(Name = "Teléfono")]
        public string? Telefono { get; set; }

        [Display(Name = "Email")]
        public string? Email { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Tipo Persona")]
        public int? TipoPersonaId { get; set; }

        [Display(Name = "Sitio Web")]
        public string? SitioWeb { get; set; }
    }
}
