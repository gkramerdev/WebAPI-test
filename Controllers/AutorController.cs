using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.DTO.Autor;
using WebAPI.Models;
using WebAPI.Services.Autor;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;

        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;   
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();    
            return Ok(autores);
        }


        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autorId = await _autorInterface.BuscaAutorId(idAutor);
            return Ok(autorId);
        }

        [HttpGet("BuscarAutorPorIdLivro/{idLivro}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorIdLivro(int idLivro)
        {
            var autorIdLivro = await _autorInterface.BuscarAutorPorIdLivro(idLivro);
            return Ok(autorIdLivro);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorDTO autorDTO)
        {
            var autores = await _autorInterface.CriarAutor(autorDTO);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEditDTO autorDTO)
        {
            var autor = await _autorInterface.EditarAutor(autorDTO);
            return Ok(autor);
        }

        [HttpDelete("ExcluirAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int autorId)
        {
            var autor = await _autorInterface.ExcluirAutor(autorId);
            return Ok(autor);
        }
    }
}
  