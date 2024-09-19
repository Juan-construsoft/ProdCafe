namespace HipatiaVentas.Models
{
    public class Caja : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public float Efectivo { get; set; }
        public bool Estado { get; set; }

        public virtual ICollection<MovimientoCaja>? MovimientoCajas { get; set; }
        public virtual ICollection<Venta>? Ventas { get; set; }
    }
}
