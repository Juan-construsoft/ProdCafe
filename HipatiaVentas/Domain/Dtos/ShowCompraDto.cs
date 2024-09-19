namespace HipatiaVentas.Domain.Dtos
{
    public class ShowCompraDto
    {
        public CompraDto? oCompra { get; set; }
        public List<DetalleCompraDto>? oDetalleCompra { get; set; }
    }
}
