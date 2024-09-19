﻿using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearMovimientoCajaDto
    {
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