namespace HipatiaVentas.Models
{
    public class DetalleVenta : BaseEntity
    {
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }

        public virtual Producto? Productos { get; set; }
        public virtual Venta? Ventas { get; set; }
    }
}
