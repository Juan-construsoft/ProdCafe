namespace HipatiaVentas.Domain.Dtos
{
    public class CrearVentaDto
    {
        public VentaDto? oVenta { get; set; }
        public List<DetalleVentaDto>? oDetalleVenta { get; set; }
    }
}
