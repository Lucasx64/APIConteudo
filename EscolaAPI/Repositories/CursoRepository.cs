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

        public void Atualizar(int id, Curso curso) // A rota chama o id e o curso para atualizar.
        {
            Curso? curso_encontrado = _context.Curso.Find(id); // Busca o id no Banco de Dados.

            // curso_encontrado = representa a linha do Banco de Dados.

            if (curso_encontrado != null)  // Se não for nulo passa para os comandos abaixo:
            {
                // Prepara para atualizar a linha no Banco de Dados.
                curso_encontrado.Nome = curso.Nome; // Depois do id localizado, recebe um novo nome.
                curso_encontrado.CargaHoraria = curso.CargaHoraria; // Recebe também uma nova carga horária.
                _context.SaveChanges(); // Salva as alterações no banco.
            }
        }


        // SELECT * FROM Curso WHERE IdCurso = @id
        public Curso? BuscarPorId(int id)
        {
            return _context.Curso.Find(id); // Find() -> Busca pela chave primária
        }


        // INSERT INTO Curso (no SQL Server). Aqui se torna ->
        public void Cadastrar(Curso curso)
        {
            _context.Curso.Add(curso); // Coloca na fila (marca para inserir).
            _context.SaveChanges(); // Grava a alteração no banco.
        }



        // DELETE * FROM Curso WHERE IdCurso = @id

        public void Deletar(int id)
        {
           Curso? curso_encontrado = _context.Curso.Find(id);

            if (curso_encontrado != null)
            {
                _context.Curso.Remove(curso_encontrado); // Coloca na fila/Prepara para excluir
                _context.SaveChanges(); // Grava a exclusão no banco.
            }
        }



        // SELECT * FROM Curso (no SQL Server). Aqui se torna ->
        public List<Curso> ListarTodos()
        {
            return _context.Curso.ToList(); // ToList(); -> Busca todos os registros.
        }
    }
}
