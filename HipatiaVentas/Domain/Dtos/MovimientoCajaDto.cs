using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class MovimientoCajaDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? Id { get; set; }
       
        [Display(Name = "CajaId")]
        public int? CajaId { get; set; }
        
        [Display(Name = "TipoMovimientoId")]
        public int? TipoMovimientoId { get; set; }
        
        [Display(Name = "CantidadEfectivo")]
        public decimal? CantidadEfectivo { get; set; }
        
        [Display(Name = "MotivoMovimiento")]
        public string? MotivoMovimiento { get; set; }
       
        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}