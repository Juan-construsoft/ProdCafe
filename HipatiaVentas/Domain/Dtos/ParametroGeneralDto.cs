using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class ParametroGeneralDto
    {
        public int Id { get; set; }

        [Display(Name = "Código")]
        public string? Codigo { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "Tipo Categoría")]
        public int? TipoCategoriaId { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }

        [Display(Name = "Tipo Categoría")]
        public string? NombreTipoCategoria { get; set; }
    }
}
