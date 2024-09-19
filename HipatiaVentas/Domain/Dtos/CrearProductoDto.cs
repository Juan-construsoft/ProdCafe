using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearProductoDto
    {
        [Display(Name = "Código")]
        public string? Codigo { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Stock")]
        public int? Stock { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Vencimiento")]
        public bool Vencimiento { get; set; }

        [Display(Name = "Fecha Vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        [Display(Name = "Foto")]
        public string? Foto { get; set; }

        [Display(Name = "Marca")]
        public string? MarcaId { get; set; }

        [Display(Name = "Presentación")]
        public string? PresentacionId { get; set; }

        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }
    }
}
