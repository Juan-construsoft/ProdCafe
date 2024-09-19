namespace HipatiaVentas.Models
{
    public class Result
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Result()
        {
            this.Success = false;
        }
    }
}
