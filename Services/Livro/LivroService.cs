using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.DTO.Autor;
using WebAPI.DTO.Livro;
using WebAPI.Models;

namespace WebAPI.Services.Livro
{
    public class LivroService : ILivroInterface

        

    {
        private readonly AppDbContext _context;

        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<LivroModel>> BuscaLivroId(int idLivro)
        {
            ResponseModel<LivroModel> resposta = new ResponseModel<LivroModel>();

            try
            {
                var livro = await _context.Livros.FirstOrDefaultAsync(livroId => livroId.Id == idLivro);
                if(livro == null)
                {
                    resposta.Mensagem = "Livro não encontrado";
                    return resposta;
                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro encontrado";
                return resposta;
                


            } catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
            
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {

                var livro = await _context.Livros.Include(a => a.Autor)
                .Where(livroBanco => livroBanco.Autor.Id == idAutor).ToListAsync();

                if(livro == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;

                }

                resposta.Dados = livro;
                resposta.Mensagem = "Livro encontrado com sucesso";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem=ex.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroDTO livroDTO)
        {
           ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
               
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroDTO.Autor.Id);
                if(autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor localizado";
                    return resposta;
                }

                var livro = new LivroModel()
                {
                    Titulo = livroDTO.Titulo,
                    Autor = autor
                };

                _context.Add(livro);
                await _context.SaveChangesAsync();
                
                resposta.Dados = await _context.Livros.Include(a=>a.Autor).ToListAsync();
                return resposta;


            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status=false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEditDTO livroEditDTO)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == livroEditDTO.Id);

                var autor = await _context.Autores
                    .FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEditDTO.Autor.Id);

                if (autor == null)
                {
                    resposta.Mensagem = "Nenhum registro de autor encontrado";
                    return resposta;
                }

                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum registro de livro encontrado";
                    return resposta;
                }

                livro.Titulo = livroEditDTO.Titulo;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Livros.ToListAsync();

                return resposta;





            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        
        }

        public async Task<ResponseModel<List<LivroModel>>> ExcluirLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livro = await _context.Livros
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (livro == null)
                {
                    resposta.Mensagem = "Nenhum livro encontrado";
                    return resposta;
                }
                _context.Remove(livro);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Livros.ToListAsync();
                resposta.Mensagem = "Livro removido com sucesso";
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> resposta = new ResponseModel<List<LivroModel>>();

            try
            {
                var livros = await _context.Livros
                    .Include(a => a.Autor)                    
                    .ToListAsync();
                resposta.Dados = livros;
                resposta.Mensagem = "Todos os livros listados";
                return resposta;

            }catch(Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status=false;
                return resposta;
            }
        }
    }
}
