using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearTipoMovimientoDto
    {
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
