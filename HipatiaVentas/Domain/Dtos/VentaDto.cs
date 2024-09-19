using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class VentaDto
    {
        public int Id { get; set; }
        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public int CajaId { get; set; }
        public int TipoComprobanteId { get; set; }
        public string? NumeroComprobante { get; set; }        
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }

        [Display(Name = "Tipo Comprobante")]
        public string? NombreComprobante { get; set; }

        [Display(Name = "Cliente")]
        public string? NombreCliente { get; set; }

        [Display(Name = "Caja")]
        public string? NombreCaja { get; set; }

        [Display(Name = "Comprobante")]
        public string FullComprobante
        {
            get { return NombreComprobante + " - " + NumeroComprobante; }
        }
    }
}
