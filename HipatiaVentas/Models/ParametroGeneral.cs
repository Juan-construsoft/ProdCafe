namespace HipatiaVentas.Models
{
    public class ParametroGeneral : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int? TipoCategoriaId { get; set; }

        public virtual TipoCategoria? TipoCategorias { get; set; }
    }
}
