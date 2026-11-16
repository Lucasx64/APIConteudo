// Cria o "construtor" da aplicação.
// Ler o appsettings.json
// E prepara a lista de serviços que a API vai utilizar.

using EscolaAPI.Contexts;
using EscolaAPI.Interfaces;
using EscolaAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// PARTE 1 - REGISTRAR OS SERVIÇOS DA API (o que a API vai ter de DISPONÍVEL)

// Habilitar o uso de Controllers na API (as classes da pasta Controllers)

builder.Services.AddControllers();

// Registra o EscolaContext (a "ponte" com o banco) para a API poder usá-lo

builder.Services.AddDbContext<EscolaContext>( options =>

        options.UseSqlServer( builder.Configuration.GetConnectionString("Escola"))
    
    // ^ Dizer que o banco é SQL Server e busca a connection string chamada "Escola".
    // Dentro da seção ConnectionString do appsettings.json

 );


// NOVO: Quando alguém pedir ICursoRepository, a API entrega um CursoRepository

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();




// ^ Monta a aplicação com tudo que foi registrado acima.
// Daqui pra baixo não dá mais para registrar serviços.


var app = builder.Build();



// PARTE 2 - O CAMINHO DE CADA REQUISIÇÃO (pipeline)

// Se o usuário acessar o endereço http, a API redireciona para https (mais seguro)

app.UseHttpsRedirection();


// Irá verificar as permissões de acesso (será utilizado quando tivermos login)

app.UseAuthorization();


// Ligar as rotas definidas nos Controllers.

app.MapControllers();



app.MapGet("/api/cursos", (EscolaContext db) => db.Curso.ToList());


// Liga a API e deixa ela esperando as requisições

app.Run();



// Interface = Contrato
// -> Assinatura (escopo obrigatório)
// 