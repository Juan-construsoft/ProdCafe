namespace HipatiaVentas.Models
{
    public class DetalleCompra : BaseEntity
    {
        public int CompraId { get; set; }
        public int ProductoId { get; set; }       
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal PrecioMayoreo { get; set; }
        public decimal Subtotal { get; set; }
       
        public virtual Producto? Productos { get; set; }
        public virtual Compra? Compras { get; set; }
    }
}
