using EscolaAPI.Contexts;
using EscolaAPI.Interfaces;
using EscolaAPI.Models;

namespace EscolaAPI.Repositories
{

    public class AlunoRepository : IAlunoRepository
    {
        private readonly EscolaContext _context;

        public AlunoRepository(EscolaContext context)
        {
            _context = context;
        }
        public void Cadastrar(Aluno aluno)
        {
            _context.Aluno.Add(aluno);
            _context.SaveChanges();
        }

        public List<Aluno> ListarTodos()
        {
            return _context.Aluno.ToList();
        }
    }
}
