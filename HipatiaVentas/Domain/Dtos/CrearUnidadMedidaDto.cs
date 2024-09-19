using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearUnidadMedidaDto
    {       

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
