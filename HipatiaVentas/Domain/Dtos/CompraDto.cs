using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CompraDto
    {
        [HiddenInput]
        [Display(Name = "Id")]
        public int? Id { get; set; }

        [Display(Name = "Fecha Compra")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCompra { get; set; }

        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }

        [Display(Name = "Tipo Comprobante")]
        public int TipoComprobanteId { get; set; }

        [Display(Name = "Número Comprobante")]
        public string? NumeroComprobante { get; set; }

        [Display(Name = "Subtotal")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Subtotal { get; set; }

        [Display(Name = "Iva")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Iva { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? Total { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }


        [Display(Name = "Tipo Comprobante")]
        public string? NombreComprobante { get; set; }

        [Display(Name = "Proveedor")]
        public string? NombreProveedor { get; set; }

        [Display(Name = "Comprobante")]
        public string FullComprobante
        {
            get { return NombreComprobante + " - " + NumeroComprobante; }
        }
    }
}
