using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearDetalleCompraDto
    {
        [Display(Name = "CompraId")]
        public int? CompraId { get; set; }

        [Display(Name = "ProductoId")]
        public int? ProductoId { get; set; }

        [Display(Name = "proveedorId")]
        public int? ProveedorId { get; set; }

        [Display(Name = "Cantidad")]
        public int? Cantidad { get; set; }

        [Display(Name = "Precio")]
        public decimal? Precio { get; set; }

        [Display(Name = "Subtotal")]
        public decimal? Subtotal { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
