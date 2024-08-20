namespace WebAPI_Funcionarios.Models
{
    public class ServiceResponse<T>
    {
        public T? data { get; set; }
        public string message { get; set; } = string.Empty;
        public bool success { get; set; } = true;
    }
}
