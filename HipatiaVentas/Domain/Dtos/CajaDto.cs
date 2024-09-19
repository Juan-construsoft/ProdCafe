using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CajaDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? Id { get; set; }
       
        [Display(Name = "Codigo")]
        public string? Codigo { get; set; }
        
        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }
        
        [Display(Name = "Efectivo")]
        public decimal? Efectivo { get; set; }

        [Display(Name = "Estado")]
        public bool Estado { get; set; }
       
        [Display(Name = "Activa")]
        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }
    }
}

