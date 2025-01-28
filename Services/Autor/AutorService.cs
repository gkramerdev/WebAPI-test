﻿using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services.Autor
{
    public class AutorService : IAutorInterface

    {

        private readonly AppDbContext _context;
    
        public AutorService(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<ResponseModel<AutorModel>> BuscaAutorId(int idAutor)

        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autorId = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);
                if(autorId == null)
                {
                    resposta.Mensagem = "Nenhum autor encontrado";
                    return resposta;
                }

                resposta.Dados = autorId;
                resposta.Mensagem = "Autor encontrado";
                return resposta;

            }catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autorIdLivro = await _context.Livros
                    .Include(a => a.Autor)
                    .FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
                if (autorIdLivro == null)
                {
                    resposta.Mensagem = ("Nenhum registro encontrado");
                    return resposta;

                }

                resposta.Dados = autorIdLivro.Autor;
                resposta.Mensagem = ("Autor encontrado");
                return resposta;



            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {

            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();   
            try
            {

                var autores = await _context.Autores.ToListAsync();   
                resposta.Dados = autores;
                resposta.Mensagem = "Autores coletados";

                return resposta;
                


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
