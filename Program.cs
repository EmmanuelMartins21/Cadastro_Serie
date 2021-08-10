using System;
using Cadastro_Serie.Classes;

namespace Cadastro_Serie
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "E")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                            ListarSeries();
                            break;
                    case "2":
                            InserirSeries();
                            break;
                    case "3":
                            AtualizarSeries();
                            break;
                    case "4":
                             ExcluirSeries();
                            break;
                    case "5":
                            VisualizarSerie();
                            break;
                    case "C":
                            Console.Clear();
                            break;    
                    default:
                            throw new ArgumentOutOfRangeException(); 
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Agradecemos por utilizar nossos serviços.");
		    Console.ReadLine(); 
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			var serie = repositorio.RetornaPorId(indiceSerie);

			Console.WriteLine(serie);
        }

        private static void ExcluirSeries()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceSerie);
        }

        private static void AtualizarSeries()
        {
            Console.Write("Digite o id da série: ");
			int indiceSerie = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título da Série: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Ano de Início da Série: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a Descrição da Série: ");
			string entradaDescricao = Console.ReadLine();

			Series atualizaSerie = new Series(id: indiceSerie,
										genero: (Genero)entradaGenero,
										titulo: entradaTitulo,
										ano: entradaAno,
										descrição: entradaDescricao);

			repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void InserirSeries()
        {
            //Varre as opções pré cadastradas no enum
            foreach(int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine( "{0}: + {1}", i, Enum.GetName(typeof(Genero),i));
            }
            Console.WriteLine("Digite o genero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o titulo da serie: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano da serie: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da serie: ");
            string entradaDescricao = Console.ReadLine();

            // aqui cria a serie passando os parametros informados

            Series novaSerie = new Series(id: repositorio.ProximoId(),
                                          genero: (Genero)entradaGenero,
                                          titulo: entradaTitulo,
                                          descrição: entradaDescricao,
                                          ano: entradaAno);

            repositorio.Insere(novaSerie);

        }

        private static void ListarSeries()
        {
            var lista = repositorio.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Lista vazia");
                return ;
            }

            //Forma de imprimir uma lista de series
            foreach(var serie in lista)
            {
                var excluido = serie.retornaExcluido();
               
                Console.WriteLine( "#ID {0}: - {1}  {2}", serie.RetornaId(), serie.retornaTitulo(), (excluido?"*Excluido*": ""));
            }
        }

        public static string ObterOpcaoUsuario()
        {
            Console.WriteLine("Seja bem vindo ao Series Martins !!!");
            Console.WriteLine("Como podemos te ajudar?");
            Console.WriteLine("1- Listar series disponiveis");
            Console.WriteLine("2- Inserir nova serie");
            Console.WriteLine("3- Atualizar serie");
            Console.WriteLine("4- Excluir serie");
            Console.WriteLine("5- Visualizar serie determinada");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("E - Sair");
            string opcaoUsuario =  Console.ReadLine();
            return opcaoUsuario;

        }
    }
}
