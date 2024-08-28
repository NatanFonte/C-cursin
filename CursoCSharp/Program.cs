// See https://aka.ms/new-console-template for more information
using CursoCSharp;

//EntradaSaidaDados.LerArmazenar();
//TiposPrimitivos.ImprimirTipos();
//_03_OperadoresAritmeticos.EntradaSaida();

/*bool resultado;
resultado = _04_OperadoresLogicos.ELogico(false, true);
Console.WriteLine($"O resultado do operador logico E:{resultado}");
resultado = _04_OperadoresLogicos.Negacao(true);
Console.WriteLine($"O resultado do operador logico Negação:{resultado}");
resultado = _04_OperadoresLogicos.OULogico(true, true);
Console.WriteLine($"O resultado do operador logico OULogico:{resultado}");
resultado = _04_OperadoresLogicos.OUExclusivo(false, true);//diferente do OU normal esse só aceita um único verdadeiro
Console.WriteLine($"O resultado do operador logico OUExclusivo:{resultado}"); */

//_06_OperadoresComparacao.DemonstrarOperadores();

//_07_OperadorTernario.DemonstrarTernario();

//_08_Conversao.DemonstrarConversoes();

//_09_EstruturaCondicional.DemonstrarCondicionais();

//_10_EstruturaRepeticao.DemonstrarRepeticoes();

//_11_Array.DemonstrarArray();

//_12_ListExemplo.DemonstrarLista();

//objeto é a variável do tipo da classe que a gente quer trabalhar


/*Aluno vito = new Aluno();
Aluno atila = new Aluno();

vito.nome = "Joao Vito";
vito.matricula = "241415643634";
vito.curso = "tecnico";
atila.nome = "atila";
atila.matricula = "6364364323";
atila.curso = "tecnico";

Console.WriteLine($"O nome do aluno é, {vito.nome}, o curso do aluno, {vito.curso}, e a matricula {vito.matricula}");
Console.WriteLine($"O nome do aluno é, {atila.nome}, o curso do aluno, {atila.curso}, e a matricula {atila.matricula}");
*/

/*_13_EscopoVariavel es = new _13_EscopoVariavel();
es.Metodo1();
es.Metodo2();
es.Metodo3();
es.ExibirContadorGlobal();
*/

/*
//Mundo perfeito

_15_tratarexcecao tr = new _15_tratarexcecao();
tr.ExecutarDivisao(9, 3);

//Mundo inperfeito

_15_tratarexcecao tr1 = new _15_tratarexcecao();
tr1.ExecutarDivisao(2, 0);
*/


//Instância de classe é tipo criar uma nova versão, e objeto é a variável que criamos ao lado da classe por exemplo
//o "tr" na classe "_15_tratarexcecao, e lembrando que com o objeto de classe você chama os metodos"

/* _16_ConceitosPOO  bn = new _16_ConceitosPOO();
bn.ExplicarOrientacaoAObjetos();
bn.DiferencaEntreParadigmas();
bn.ExplicarPilares();
*/

/*
Pessoa pessoa1 = new Pessoa("Alice", 30);
Pessoa pessoa2 = new Pessoa("Bob", 25);

pessoa1.ExibirInformacoes();
pessoa2.ExibirInformacoes();

Pessoa.ExibirNumeroDePessoas();

Console.WriteLine($"Pessoa1: {pessoa1.Nome}, Idade: {pessoa1.Idade}");
Console.WriteLine($"Pessoa1: { pessoa1.Nome}, Idade: {pessoa1.Idade}");
Console.WriteLine($"Número total de pessoas: {Pessoa.NumeroDePessoas}");
*/

/*

// Instanciando a classe Produto usando o construtor padrão
Produto produto1 = new Produto();
produto1.ExibirInformacoes();

// Instanciando a classe Produto usando o construtor com parâmetros
Produto produto2 = new Produto("Smartphone", 1999.99m, 50);
produto2.ExibirInformacoes();

// Modificando atributos usando propriedades
produto1.Nome = "Notebook";
produto1.Preco = 2999.99m;
produto1.Estoque = 25;
produto1.ExibirInformacoes();

// Acessando método protegido através da classe derivada
ProdutoEspecial produtoEspecial = new ProdutoEspecial();
produtoEspecial.ExibirMetodoProtegido();

*/


Livro livro = new Livro("aasdsa","fafasfsa",2006,"fafsa",2000);
livro.ExibirDetalhes();

