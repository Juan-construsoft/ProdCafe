namespace HipatiaVentas.Models
{
    public class Producto : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int? Stock { get; set; }
        public string? Descripcion { get; set; }
        public bool Vencimiento { get; set; }
        public DateTime? FechaVencimiento { get; set; }
        public string? Foto { get; set; }
        public int? MarcaId { get; set; }
        public int? PresentacionId { get; set; }
        public int? CategoriaId { get; set; }

        public virtual Proveedor? Proveedores { get; set; }

        public virtual ICollection<DetalleCompra>? DetalleCompras { get; set; }
        public virtual ICollection<DetalleVenta>? DetalleVenta { get; set; }
    }
}
