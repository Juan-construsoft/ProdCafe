namespace HipatiaVentas.Models
{
    public class Proveedor : BaseEntity
    {
        public int? TipoDocumentoId { get; set; }
        public string? Numero { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public bool Estado { get; set; }
        public string? NombreRepresentante { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? SitioWeb { get; set; }
        public int? TipoPersonaId { get; set; }

        public virtual ICollection<Compra>? Compras { get; set; }
    }
}
