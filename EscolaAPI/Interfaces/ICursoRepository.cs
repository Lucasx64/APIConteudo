using EscolaAPI.Models;

namespace EscolaAPI.Interfaces
{
    /*
    public interface -> é um contrato (só diz que existe, sem implementar)

    List<Curso> -> devolve uma lista de cursos

    */

    public interface ICursoRepository
    {

        // R -> Read: devolve todos os cursos

        List<Curso> ListarTodos();


        // R -> Read: busca um curso por Id (ou null caso não ache)

        Curso? BuscarPorId(int id);


        // C -> Create: cadastrar um curso novo

        void Cadastrar(Curso curso);


        void Atualizar(int id, Curso curso);


        void Deletar(int id);
    }
}
