namespace HipatiaVentas.Domain.Dtos
{
    public class CrearRegistroTostionDto
    {
        public string? NumeroLote { get; set; }
        public DateTime FechaProceso { get; set; }
        public decimal PesoPergamino { get; set; }
        public int TipoProcesoId { get; set; }
        public decimal PesoTrillado { get; set; }
        public decimal PesoTostado { get; set; }
        public int TipoMoliendaId { get; set; }
        public decimal ValorParcial { get; set; }
        public decimal ValorTotal { get; set; }
        public string? Observaciones { get; set; }
        public bool IsActive { get; set; }
    }
}
