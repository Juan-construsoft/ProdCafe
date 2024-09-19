using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class DepartamentoDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? Id { get; set; }
       
        [Display(Name = "Codigo")]
        public string? Codigo { get; set; }
        
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
       
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}

