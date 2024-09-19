using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class DetalleVentaDto
    {
        [Display(Name = "Venta")]
        public int VentaId { get; set; }

        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }       

        [Display(Name = "Precio Venta")]
        public decimal PrecioVenta { get; set; }

        [Display(Name = "Descuento")]
        public decimal Descuento { get; set; }

        [Display(Name = "Subtotal")]
        public decimal Subtotal { get; set; }

        [Display(Name = "Producto")]
        public string? NombreProducto { get; set; }
    }
}
