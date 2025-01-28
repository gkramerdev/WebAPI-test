using WebAPI.Models;

namespace WebAPI.DTO.Livro
{
    public class LivroDTO
    {
        public string Titulo { get; set; }


        public AutorModel Autor { get; set; }
    }
}
