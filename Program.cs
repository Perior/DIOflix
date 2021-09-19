using System;

namespace DIOflix
{
    class Program
    {
        static FilmeRepository filmRep = new FilmeRepository();
        static SerieRepository serieRep = new SerieRepository();

        static void Main(string[] args)
        {
            string command = UserCommand();

            while(command.ToUpper() != "X"){
                
                switch(command)
                {
                    case "1":
                        ListarTudo();
                        HoldUp();
                        break;
                    case "2":
                        ListarFilmes();
                        HoldUp();
                        break;
                    case "3":
                        ListarSeries();
                        HoldUp();
                        break;
                    case "4":
                        AddFilme();
                        HoldUp();
                        break;
                    case "5":
                        AddSerie();
                        HoldUp();
                        break;
                    case "6":
                        AttFilme();
                        HoldUp();
                        break;
                    case "7":
                        AttSerie();
                        HoldUp();
                        break;
                    case "8":
                        ExcluirFilme();
                        HoldUp();
                        break;
                    case "9":
                        ExcluirSerie();
                        HoldUp();
                        break;
                    case "10":
                        Visualizar();
                        HoldUp();
                        break;
                    default:
                        Console.WriteLine("Entrada inválida. Tente novamente.");
                        HoldUp();
                        break;

                }

                command = UserCommand();
            }
            
        }

        private static void HoldUp(){
            Console.WriteLine("Aperte uma tecla para continuar...");
            Console.ReadLine();
            //Console.Clear();
        }


        private static void ListarTudo()
        {
            var filmeList = filmRep.Lista();
            var serieList = serieRep.Lista();

            if(filmeList.Count == 0 && serieList.Count == 0){
                Console.WriteLine("Nada no catálogo.");
                return;
            }

            Console.WriteLine("======Catálogo======");

            Console.WriteLine("Filmes:");
            foreach (var filme in filmeList)
            {
                Console.WriteLine("#ID {0}: {1}", filme.RetornaId(), filme.RetornaTitulo());    
            }

            Console.WriteLine("Séries:");
            foreach (var serie in serieList)
            {
                Console.WriteLine("#ID {0}: {1}", serie.RetornaId(), serie.RetornaTitulo());    
            }
        }

        private static Filme EstruturaFilme(bool add, int indice){

            foreach (int i in Enum.GetValues(typeof(EGenero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(EGenero), i));
            }
            Console.WriteLine("Escolha um dos gêneros acima e digite o valor escolhido:");
            int genrer = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título do filme:");
            string title = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome da atriz principal (se houver):");
            string actress = Console.ReadLine();

            Console.WriteLine("Digite o nome do ator principal (se houver):");
            string actor = Console.ReadLine();

            Console.WriteLine("Digite a sinopse do filme:");
            string sinopse = Console.ReadLine();

            Filme novoFilme;

            if(add){
                novoFilme = new Filme(id: filmRep.ProximoId(),
                                        genero: (EGenero)genrer,
                                        titulo: title,
                                        ano: year,
                                        actressLead: actress,
                                        actorLead: actor,
                                        sinopse: sinopse);

                return novoFilme;
            }

            novoFilme = new Filme(id: indice,
                                    genero: (EGenero)genrer,
                                    titulo: title,
                                    ano: year,
                                    actressLead: actress,
                                    actorLead: actor,
                                    sinopse: sinopse);

            return novoFilme;
        }

        private static Serie EstruturaSerie(bool add, int indice){

            foreach (int i in Enum.GetValues(typeof(EGenero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(EGenero), i));
            }
            Console.WriteLine("Escolha um dos gêneros acima e digite o valor escolhido:");
            int genrer = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o título da série:");
            string title = Console.ReadLine();

            Console.WriteLine("Digite o ano de lançamento:");
            int year = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome da atriz principal (se houver):");
            string actress = Console.ReadLine();

            Console.WriteLine("Digite o nome do ator principal (se houver):");
            string actor = Console.ReadLine();

            Console.WriteLine("Digite a sinopse da série:");
            string sinopse = Console.ReadLine();

            Console.WriteLine("Digite o número de episódios:");
            int eps = int.Parse(Console.ReadLine());

            Serie novaSerie;

            if(add){
                novaSerie = new Serie(id: serieRep.ProximoId(),
                                        genero: (EGenero)genrer,
                                        titulo: title,
                                        ano: year,
                                        actressLead: actress,
                                        actorLead: actor,
                                        sinopse: sinopse,
                                        numEpisodes: eps);

                return novaSerie;
            }

            novaSerie = new Serie(id: indice,
                                    genero: (EGenero)genrer,
                                    titulo: title,
                                    ano: year,
                                    actressLead: actress,
                                    actorLead: actor,
                                    sinopse: sinopse,
                                    numEpisodes: eps);

            return novaSerie;
        }

        private static void ListarFilmes()
        {
            var filmeList = filmRep.Lista();

            if(filmeList.Count == 0){
                Console.WriteLine("Nenhum filme no catálogo.");
            }
            
            Console.WriteLine("Filmes:");
            foreach (var filme in filmeList)
            {
                Console.WriteLine("{0} #ID - {1}: {2}", filme.RetornaDelete(), filme.RetornaId(), filme.RetornaTitulo());    
            }
        }

        private static void ListarSeries()
        {
            var serieList = serieRep.Lista();

            if(serieList.Count == 0){
                Console.WriteLine("Nenhuma série no catálogo.");
            }

            Console.WriteLine("Séries:");
            foreach (var serie in serieList)
            {
                Console.WriteLine("{0} #ID - {1}: {2}", serie.RetornaDelete(), serie.RetornaId(), serie.RetornaTitulo());    
            }
        }

        private static void AddFilme()
        {
            Console.WriteLine("======Inserção de Filme======");
            filmRep.Insere(EstruturaFilme(true, 0));
        }

        private static void AddSerie()
        {
            Console.WriteLine("======Inserção de Série======");
            serieRep.Insere(EstruturaSerie(true, 0));
        }

        private static void AttFilme()
        {
            Console.WriteLine("======Atualização de Filme======");
            ListarFilmes();
            Console.WriteLine("Digite o ID do filme que deseja alterar:");

            int id = int.Parse(Console.ReadLine());
            
            filmRep.Atualiza(id, EstruturaFilme(false, id));            
        }

        private static void AttSerie()
        {
            Console.WriteLine("======Atualização de Série======");
            ListarSeries();
            Console.WriteLine("Digite o ID da série que deseja alterar:");

            int id = int.Parse(Console.ReadLine());
            
            serieRep.Atualiza(id, EstruturaSerie(false, id)); 
        }

        private static void ExcluirFilme()
        {
            Console.WriteLine("======Remoção de Filme======");
            ListarFilmes();
            Console.WriteLine("Digite o ID do filme que deseja remover:");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja mesmo remover {0}?", filmRep.RetornaPorId(id).RetornaTitulo());
            Console.WriteLine("Digite S para confirmar ou qualquer outra tecla para voltar.");
            string confirm = Console.ReadLine();

            if(confirm.ToUpper() == "S"){
                filmRep.Exclui(id);
            }
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("======Remoção de Série======");
            ListarSeries();
            Console.WriteLine("Digite o ID da série que deseja remover:");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Deseja mesmo remover {0}?", serieRep.RetornaPorId(id).RetornaTitulo());
            Console.WriteLine("Digite S para confirmar ou qualquer outra tecla para voltar.");
            string confirm = Console.ReadLine();

            if(confirm.ToUpper() == "S"){
                serieRep.Exclui(id);
            }
        }

        private static void Visualizar()
        {
            Console.WriteLine("======Visualizar======");
            ListarTudo();

            Console.WriteLine("Deseja visualizar informações de uma série(1) ou filme(2)?");
            Console.WriteLine();
            Console.WriteLine("1 - Filme");
            Console.WriteLine("2 - Série");

            string choice = Console.ReadLine();
            Console.WriteLine();
            int id;

            switch(choice){
                case "1":
                    Console.WriteLine("Digite o ID do item que deseja visualizar:");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    var fItem = filmRep.RetornaPorId(id);
                    Console.WriteLine(fItem);
                    break;
                case "2":
                    Console.WriteLine("Digite o ID do item que deseja visualizar:");
                    id = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    var sItem = serieRep.RetornaPorId(id);
                    Console.WriteLine(sItem);
                    break;
            }
        }

        private static string UserCommand(){
            Console.WriteLine();
            Console.WriteLine("TUDUM");
            Console.WriteLine("Bem vindo à DIOFlix!");
            Console.WriteLine("Informe a operação desejada: ");

            Console.WriteLine("1 - Listar tudo.");
            Console.WriteLine("2 - Listar Filmes.");
            Console.WriteLine("3 - Listar Séries.");
            Console.WriteLine("4 - Adicionar novo Filme.");
            Console.WriteLine("5 - Adicionar nova Série.");
            Console.WriteLine("6 - Atualizar Filme.");
            Console.WriteLine("7 - Atualizar Série.");
            Console.WriteLine("8 - Excluir Filme.");
            Console.WriteLine("9 - Excluir Série.");
            Console.WriteLine("10 - Visualizar por Id.");
            Console.WriteLine("X - Sair.");
            Console.WriteLine();

            string command = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return command;

        }
    }
}
