using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CompraVM
    {
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Comprobante")]
        public int TipoComprobanteId { get; set; }
    }
}
