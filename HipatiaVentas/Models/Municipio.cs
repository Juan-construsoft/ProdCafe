namespace HipatiaVentas.Models
{
    public class Municipio : BaseEntity
    {
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoUnificado { get; set; }
        public int DepartamentoId { get; set; }        
        

        public virtual Departamento? Departamentos { get; set; }

        public virtual ICollection<Cliente>? Clientes { get; set; }
    }
}
