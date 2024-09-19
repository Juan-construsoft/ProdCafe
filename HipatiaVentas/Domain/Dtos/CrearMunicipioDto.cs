﻿using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearMunicipioDto
    {
        [Display(Name = "Codigo")]
        public string? Codigo { get; set; }

        [Display(Name = "Nombre")]
        public string? Nombre { get; set; }

        [Display(Name = "CodigoUnificado")]
        public string? CodigoUnificado { get; set; }

        [Display(Name = "DepartamentoId")]
        public int? DepartamentoId { get; set; }

        [Display(Name = "IsActive")]
        public bool IsActive { get; set; }
    }
}
