using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Autor;
using WebAPI.DTO.Livro;
using WebAPI.Models;
using WebAPI.Services.Autor;
using WebAPI.Services.Livro;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly ILivroInterface _livroInterface;

        public LivroController (ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("BuscarLivroPorId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscaLivroId(int idLivro)
        {
            var livroId = await _livroInterface.BuscaLivroId(idLivro);
            return Ok(livroId);
        }

        [HttpGet("BuscarLivroPorIdAutor/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarLivroPorIdAutor(int idLivro)
        {
            var livroId = await _livroInterface.BuscarLivroPorIdAutor(idLivro);
            return Ok(livroId);
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> ListarLivros()
        {
            var livros = await _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpPost("CriaLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroDTO livroDto)
        {
            var livros = await _livroInterface.CriarLivro(livroDto);
            return Ok(livros);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEditDTO livroEditDTO)
        {
            var livro = await _livroInterface.EditarLivro(livroEditDTO);
            return Ok(livro);
        }

        [HttpDelete("ExcluirLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ExcluirLivro(int livroId)
        {
            var autor = await _livroInterface.ExcluirLivro(livroId);
            return Ok(autor);
        }
    }
}
