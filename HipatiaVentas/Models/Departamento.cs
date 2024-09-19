namespace HipatiaVentas.Models
{
    public class Departamento : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }

        public virtual ICollection<Municipio>? Ciudades { get; set; }
        public virtual ICollection<Cliente>? Clientes { get; set; }
    }
}
