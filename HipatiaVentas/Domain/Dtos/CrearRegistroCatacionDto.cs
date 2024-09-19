using System.ComponentModel.DataAnnotations;

namespace HipatiaVentas.Domain.Dtos
{
    public class CrearRegistroCatacionDto
    {
        [Display(Name = "Fecha Prueba")]       
        public DateTime FechaPrueba { get; set; }

        [Display(Name = "Predio")]
        public string? Predio { get; set; }

        [Display(Name = "Lote")]
        public string? Lote { get; set; }

        [Display(Name = "Variedad")]
        public int VariedadId { get; set; }

        [Display(Name = "Método")]
        public int MetodoId { get; set; }

        [Display(Name = "Fragancia/Aroma")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal FraganciaAroma { get; set; }

        [Display(Name = "Sabor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Sabor { get; set; }

        [Display(Name = "Sabor Residual")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal SaborResidual { get; set; }

        [Display(Name = "Acidéz")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Acidez { get; set; }

        [Display(Name = "Cuerpo")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Cuerpo { get; set; }

        [Display(Name = "Uniformidad")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Uniformidad { get; set; }

        [Display(Name = "Dulzor")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Dulzor { get; set; }

        [Display(Name = "Limpieza Taza")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal LimpiezaTaza { get; set; }

        [Display(Name = "Balance")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Balance { get; set; }

        [Display(Name = "Global")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Global { get; set; }        

        [Display(Name = "Puntaje")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal Puntaje { get; set; }

        [Display(Name = "Defectos")]        
        public string? Defectos { get; set; }

        [Display(Name = "Activo")]
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }
    }
}
