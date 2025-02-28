//List<string> listaDasBandas = new List<string> { "U2", "Linkin Park"};

Dictionary<string, List<int>> BandasRegistradas = new Dictionary<string, List<int>>();
BandasRegistradas.Add("Linkin Park", new List<int> ());
BandasRegistradas.Add("Beattles", new List<int> ());

void ExibirLogo()
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
}
;

void Menu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("Digite 2 para mostrar todas a bandas");
    Console.WriteLine("Digite 3 avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite 0 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumerica)
    {
        case 1:
            RegistrarBandas(); ;
            break;

        case 2:
            MostrarBandasRegistradas();
            break;
        case 3:
            AvaliarUmaBanda();
            break;
        case 4:
            MediaNotas();
            break;

        case 0:
            Console.WriteLine("Até a próxima");
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Opção inválida");
            break;
    }

}

void RegistrarBandas()
{
    Console.Clear();
    TituloOpcoes("Registro de Bandas:");
    Console.Write("\nDigite o nome da banda: ");
    string nomeDaBanda = Console.ReadLine()!;
    BandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"\nA banda {nomeDaBanda} foi cadastrada com sucesso");
    Thread.Sleep(1000);
    Console.Clear();
    Menu();
}
;

void MostrarBandasRegistradas()
{
    Console.Clear();
    TituloOpcoes("Exibindo bandas registradas");

    foreach(string banda in BandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }

    Console.Write("\nAperte qualquer tecla para voltar");
    Console.ReadKey();
    Console.Clear();
    Menu();
}

void TituloOpcoes (string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asterisco = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asterisco);
    Console.WriteLine(titulo);
    Console.WriteLine(asterisco + "\n");
}

void AvaliarUmaBanda()
{
    //Digite qual banda você deseja avaliar
    //Se a banda existir, atribuir uma nota
    //senão, volta ao menu principal

    Console.Clear();
    TituloOpcoes("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string NomeDaBanda = Console.ReadLine()!;
    if (BandasRegistradas.ContainsKey(NomeDaBanda))
    {
        Console.Write($"\nQual nota a banda {NomeDaBanda} merece? ");
        int nota = int.Parse(Console.ReadLine()!);
        BandasRegistradas[NomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} da banda {NomeDaBanda} foi computadada com sucesso");
        Thread.Sleep(2000);
        Console.Clear();
        Menu(); 
    }
    else
    {
        Console.WriteLine($"\nA banda {NomeDaBanda} não foi encontrada");
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu inicial");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

}

void MediaNotas()
{
    Console.Clear();

    TituloOpcoes("Média da banda");

    Console.WriteLine("Digite o nome da banda que você deseja exibir a média: ");
    string nomeDaBanda = Console.ReadLine()!;

    if (BandasRegistradas.ContainsKey(nomeDaBanda))
    {
        List<int> listaDeNotas = BandasRegistradas[nomeDaBanda];
        double media = listaDeNotas.Any() ? listaDeNotas.Average() : 0;
        Console.WriteLine($"\nA nota média da banda {nomeDaBanda} é {media}");
        Thread.Sleep(2000);
        Console.Clear();
        Menu();
    }
    else
    {
        Console.WriteLine($"A banda {nomeDaBanda} não foi encontrada");
        Console.WriteLine("\nAperte qualquer tecla para voltar");
        Console.ReadKey();
        Console.Clear();
        Menu();
    }

}

Menu();