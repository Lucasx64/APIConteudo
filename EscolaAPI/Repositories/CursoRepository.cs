using EscolaAPI.Contexts;
using EscolaAPI.Interfaces;
using EscolaAPI.Models;

namespace EscolaAPI.Repositories
{
    public class CursoRepository : ICursoRepository
    {

        // Responsável por se comunicar diretamente com o banco de dados

        /* 
        
        Injetar o context -> Uma cozinha precisa de fogão (EscolaContext)
        Em vez de criar a classe Context sozinha, ela pede no construtor da API para entregar pronto.
        Isso se chama injeção de dependência.

        _context -> Convenção do C# para campo privado da classe.

        */

        private readonly EscolaContext _context;

        // Injeção de dependência -> a API entrega o EscolaContext pronto.

       public CursoRepository(EscolaContext context)
        {
            _context = context;
        }


        // INSERT INTO CURSO (no SQL Server). Aqui se torna ->
        public void Cadastrar(Curso curso)
        {
            _context.Curso.Add(curso); // Coloca na fila (marca para inserir).
            _context.SaveChanges(); // Grava no banco.
        }



        // SELECT * FROM CURSO (no SQL Server). Aqui se torna ->
        public List<Curso> ListarTodos()
        {
            return _context.Curso.ToList(); // ToList(); -> Busca todos os registros.
        }
    }
}
