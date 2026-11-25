using EscolaAPI.Interfaces;
using EscolaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EscolaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {

        // Guardar o acesso às ruas -> Analogia do pedágio
        private readonly ICursoRepository _cursoRepository;


        // Injeção de dependência: API entrega o CursoRepository
        public CursoController(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }


        // GET api/curso
        [HttpGet]
        public IActionResult ListarTodos() // IActionResult -> Devolve um erro/retorno de ação concluída.
        {
            return Ok(_cursoRepository.ListarTodos());
        }


        [HttpPost]
        public IActionResult Cadastrar(Curso curso)
        {
            _cursoRepository.Cadastrar(curso);
            return Created(); // 201 -> criado!
        }



        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Curso curso)
        {
            // Consulta se o ID existe no Banco de Dados antes de atualizar.
            if (_cursoRepository.BuscarPorId(id) == null) 
            {
                return NotFound(); // 404
            }

            _cursoRepository.Atualizar(id, curso);

            return NoContent(); // 204
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            if (_cursoRepository.BuscarPorId(id) == null)
            {
                return NotFound();
            }

            _cursoRepository.Deletar(id);

            return NoContent();
        }



    }
}
