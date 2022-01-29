using System;
using DIO.Series;

namespace DIO.Series
{
    class Program
    {
        static SerieRepository repo = new SerieRepository();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
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
                OpcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilzar nossos serviços!!!");
            Console.ReadLine();
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries:");

            var lista = repo.Lista();

            if(lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada...");

                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} | {2}", serie.retornaId(), serie.retornaTitulo(), (excluido ? "*Excluído*" : ""));
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            // Retornar Nome e opções com GetName e GetValues
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as demais opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repo.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repo.insere(novaSerie);            
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Digite o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            // Retornar Nome e opções com GetName e GetValues
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o gênero entre as demais opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.WriteLine("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(id: repo.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repo.Atualiza(indiceSerie, atualizaSerie);         
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Inserir o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            repo.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.WriteLine("Inserir o id da série");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repo.RetornaId(indiceSerie);
            Console.WriteLine(serie);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar séries");
            Console.WriteLine("2 - Inserir nova série");
            Console.WriteLine("3 - Atualizar nova série");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("C - Limpar Tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();
            
            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }
    }
}
