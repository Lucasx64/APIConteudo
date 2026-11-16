using EscolaAPI.Interfaces;
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
        public IActionResult ListarTodos()
        {
            return Ok(_cursoRepository.ListarTodos());
        }




    }
}
