using EscolaAPI.Models;

namespace EscolaAPI.Interfaces
{
    public interface IAlunoRepository
    {

        List<Aluno> ListarTodos();

        void Cadastrar(Aluno aluno);

    }
}
