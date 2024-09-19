using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class ProductoDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int Id { get; set; }

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
        public int? MarcaId { get; set; }

        [Display(Name = "Presentación")]
        public int? PresentacionId { get; set; }

        [Display(Name = "Categoría")]
        public int? CategoriaId { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Marca")]
        public string? NombreMarca {  get; set; }

        [Display(Name = "Presentación")]
        public string? NombrePresentacion { get; set; }

        [Display(Name = "Categoría")]
        public string? NombreCategoria { get; set; }        
    }

    public class ProductoPrecioDto
    {
        public int? Stock { get; set; }
        public decimal? PrecioVenta { get; set; }
    }
}
