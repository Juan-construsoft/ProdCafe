namespace HipatiaVentas.Domain.Dtos
{
    public class CrearCompraDto
    {
        public CompraDto? oCompra { get; set; }
        public List<DetalleCompraDto>? oDetalleCompra { get; set; }
    }
}
