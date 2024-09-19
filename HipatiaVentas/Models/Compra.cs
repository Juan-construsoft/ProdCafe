namespace HipatiaVentas.Models
{
    public class Compra : BaseEntity
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public DateTime FechaCompra { get; set; }
        public int ProveedorId { get; set; }
        public int TipoComprobanteId { get; set; }
        public string? NumeroComprobante { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Iva { get; set; }
        public decimal Total { get; set; }

        public virtual Proveedor? proveedores { get; set; }

        public virtual ICollection<DetalleCompra>? DetalleCompras { get; set; }
    }
}
