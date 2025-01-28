namespace WebAPI.Models
{
    public class RespondeModel<T>

    {
        public T? Dados { get; set; }
        public string  Mensagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;



    }
}
