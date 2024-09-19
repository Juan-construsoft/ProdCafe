using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class VentaVM
    {
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Display(Name = "Comprobante")]
        public int TipoComprobanteId { get; set; }

        [Display(Name = "Caja")]
        public int CajaId { get; set; }
    }
}
