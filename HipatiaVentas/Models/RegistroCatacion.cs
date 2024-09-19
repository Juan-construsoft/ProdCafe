namespace HipatiaVentas.Models
{
    public class RegistroCatacion : BaseEntity
    {
        public DateTime FechaPrueba { get; set; }
        public string? Predio { get; set; }
        public string? Lote { get; set; }
        public int VariedadId { get; set; }
        public int MetodoId { get; set; }
        public decimal FraganciaAroma { get; set; }
        public decimal Sabor { get; set; }
        public decimal SaborResidual { get; set; }
        public decimal Acidez { get; set; }
        public decimal Cuerpo { get; set; }
        public decimal Uniformidad { get; set; }
        public decimal Dulzor { get; set; }
        public decimal LimpiezaTaza { get; set; }
        public decimal Balance { get; set; }
        public decimal Global { get; set; }       
        public decimal Puntaje { get; set; }
        public string? Defectos { get; set; }
    }
}
