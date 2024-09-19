using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearDepartamentoDto
    {
        [Display(Name = "Codigo")]
        public string? Codigo { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
