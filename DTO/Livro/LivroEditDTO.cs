using WebAPI.Models;

namespace WebAPI.DTO.Livro
{
    public class LivroEditDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }


        public AutorModel Autor { get; set; }
    }
}
