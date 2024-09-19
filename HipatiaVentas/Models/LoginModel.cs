namespace HipatiaVentas.Models
{
    public class LoginModel
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    public class ChangePasswordModel
    {
        public string? Email { get; set; }
        public string? CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
        public string? ConfirmNewpassword { get; set; }
    }

    public class UserRoles
    {
        public static string? Admin = "Admin";
        public static string? User = "User";
    }
}
