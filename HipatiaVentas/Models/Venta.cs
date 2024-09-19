namespace HipatiaVentas.Models
{
    public class Venta : BaseEntity
    {
        public Venta()
        {
            DetalleVentas = new HashSet<DetalleVenta>();
        }

        public DateTime FechaVenta { get; set; }
        public int ClienteId { get; set; }
        public int CajaId { get; set; }
        public int TipoComprobanteId { get; set; }
        public string? NumeroComprobante { get; set; }       
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public virtual Caja? Cajas { get; set; }
        public virtual Cliente? Clientes { get; set; }

        public virtual ICollection<DetalleVenta>? DetalleVentas { get; set; }
    }
}
