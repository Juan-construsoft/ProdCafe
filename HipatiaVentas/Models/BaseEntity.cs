namespace HipatiaVentas.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } 
        public DateTime ModifiedDate { get; set; } 
        public string? CreateUser { get; set; }
        public string? ModifiedUser { get; set; }
        public bool IsActive { get; set; }
    }
}
