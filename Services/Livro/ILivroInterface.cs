using WebAPI.DTO.Autor;
using WebAPI.DTO.Livro;
using WebAPI.Models;

namespace WebAPI.Services.Livro
{
    public interface ILivroInterface
    {

        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<LivroModel>> BuscaLivroId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDTO livroDTO);

        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEditDTO livroEditDTO);
        Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro);
    }
}
