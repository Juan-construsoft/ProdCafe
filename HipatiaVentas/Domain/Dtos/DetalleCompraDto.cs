using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class DetalleCompraDto
    {
        [Display(Name = "Compra")]
        public int CompraId { get; set; }

        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        
        [Display(Name = "Precio Compra")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PrecioCompra { get; set; }

        
        [Display(Name = "Precio Venta")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PrecioVenta { get; set; }

        
        [Display(Name = "Precio Mayoreo")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal PrecioMayoreo { get; set; }

        
        [Display(Name = "Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Subtotal { get; set; }


        [Display(Name = "Producto")]
        public string? NombreProducto { get; set; }
    }
}
