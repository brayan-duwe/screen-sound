using System.Globalization;

string boasVindas = "\nBoas vindas ao Screen Sound!";
Dictionary<string, List<int>> artistasRegistrados = new Dictionary<string, List<int>>();
artistasRegistrados.Add("Matuê", new List<int> { 10, 8, 9 });
artistasRegistrados.Add("Konai", new List<int> { 9, 10 });
    

void Logo() 
{
    Console.WriteLine(@"
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░");
    Console.WriteLine(boasVindas);
}

void OpcoesDoMenu() 
{
    Console.WriteLine("\nDigite 1 para registrar uma banda ou artista");
    Console.WriteLine("Digite 2 para mostrar todos os artistas");
    Console.WriteLine("Digite 3 para avaliar um artista");
    Console.WriteLine("Digite 4 para exibir a média de um artista");
    Console.WriteLine("Digite -1 para sair");

    Console.WriteLine("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumero = int.Parse(opcaoEscolhida);

    switch (opcaoEscolhidaNumero) {
        case 1 : RegistrarArtista();
            break;
        case 2 : MostrarArtistas();
            break;
        case 3 : AvaliarArtista();
            break;
        case 4 : MediaDoArtista();
            break;
        case -1 : 
        Console.Clear();
        Console.WriteLine("Até logo, tchau!\n");
            break;
        default: Console.WriteLine("Opção inválida");
            break;
    }
}

void RegistrarArtista()
{
    Console.Clear();
    TituloDaOpcao("Registro de artistas:");
    Console.Write("Digite o nome do artista que deseja registrar: ");
    string nomeDoArtista = Console.ReadLine()!;

    if(artistasRegistrados.ContainsKey(nomeDoArtista))
    {
        Console.WriteLine($"\nO artista {nomeDoArtista} já existe.");
        Console.WriteLine("\nPressione uma tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        OpcoesDoMenu();
    }

    else
    {
        Console.WriteLine($"o Artista {nomeDoArtista} foi registrado com sucesso!");
        artistasRegistrados.Add(nomeDoArtista, new List<int>());
        Thread.Sleep(2000);
        Console.Clear();
        OpcoesDoMenu();
    }
}

void MostrarArtistas()
{
    Console.Clear();
    TituloDaOpcao("Exibindo todos os artistar registrados");
    foreach (string artista in artistasRegistrados.Keys){
        Console.WriteLine($"Artista: {artista}");
    }

    Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal: ");
    Console.ReadKey();
    Console.Clear();
    OpcoesDoMenu();
}


void AvaliarArtista() 
{
    Console.Clear();
    TituloDaOpcao("Avaliar um artista:");
    Console.Write("Digite o nome do artista que deseja avaliar: ");
    string artistaAvaliar = Console.ReadLine()!;

    if(artistasRegistrados.ContainsKey(artistaAvaliar)) 
    {
        Console.Write($"\nDe 0 a 10, qual nota você deseja dar para o artista {artistaAvaliar}? ");
        int nota = int.Parse(Console.ReadLine()!); 
        Console.WriteLine($"\nA nota foi atribuída com sucesso a {artistaAvaliar}!");
        artistasRegistrados[artistaAvaliar].Add(nota);
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        OpcoesDoMenu();
    }
    else 
    {
        Console.WriteLine($"O artista {artistaAvaliar} ainda não foi registrado.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        OpcoesDoMenu();
    }
}

void MediaDoArtista() 
{
    Console.Clear();
    TituloDaOpcao("Média dos aArtistas:");
    Console.Write("Digite o nome do artista que deseja registrar: ");
    string nomeDoArtista = Console.ReadLine()!;

    if(artistasRegistrados.ContainsKey(nomeDoArtista))
    {
        List<int> notaDoArtista = artistasRegistrados[nomeDoArtista];
        Console.WriteLine($"\nA nota do artista {nomeDoArtista} é {notaDoArtista.Average()}.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        OpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"O artista {nomeDoArtista} ainda não foi registrado.");
        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal: ");
        Console.ReadKey();
        Console.Clear();
        OpcoesDoMenu();
    }
}

void TituloDaOpcao (string titulo)
{
    int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

Logo();
OpcoesDoMenu();