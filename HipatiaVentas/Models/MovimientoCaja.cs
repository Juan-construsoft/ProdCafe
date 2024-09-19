namespace HipatiaVentas.Models
{
    public class MovimientoCaja : BaseEntity
    {
        public int CajaId { get; set; }
        public int TipoMovimientoId { get; set; }
        public decimal? CantidadEfectivo { get; set; }
        public string? MotivoMovimiento { get; set; }

        public virtual Caja? Cajas { get; set; }        
    }
}
