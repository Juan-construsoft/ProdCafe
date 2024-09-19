namespace HipatiaVentas.Domain.Dtos
{
    public class ShowVentaDto
    {
        public VentaDto? oVenta { get; set; }
        public List<DetalleVentaDto>? oDetalleVenta { get; set; }
    }
}
