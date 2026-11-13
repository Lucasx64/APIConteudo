using EscolaAPI.Models;

namespace EscolaAPI.Interfaces
{
    /*
    public interface -> é um contrato (só diz que existe, sem implementar)

    List<Curso> -> devolve uma lista de cursos

    */

    public interface ICursoRepository
    {

        // R -> read -> devolve todos os cursos

        List<Curso> ListarTodos();

        // Create -> cadastrar um curso novo

        void Cadastrar(Curso curso);



    }
}
