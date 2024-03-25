// Screen Sound
using System.Security.Principal;
using System.Xml;

string mensagemDeBoasVindas = "Boas vindas ao Screen Sound";
//List<string> listaDasBandas = new List<string> {"New Jeans", "BlackPink", "Calypso" };

Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Link Park", new List<int> { 10, 8, 6 });
bandasRegistradas.Add("The Beatles", new List<int>());

void ExibirLogo()
{
    Console.WriteLine(@"

░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
"); //O @ é para exibir a fonte de forma completa
    Console.WriteLine(mensagemDeBoasVindas);
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();
    Console.WriteLine("\nDigite 1 para registrar uma banda"); // \n é para fazer uma quebra de linha
    Console.WriteLine("Digite 2 para mostrar todas as bandas");
    Console.WriteLine("Digite 3 para avaliar uma banda");
    Console.WriteLine("Digite 4 para exibir a média de uma banda");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!; //Esclamação é para não retornar um valor nulo
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);
   
    switch (opcaoEscolhidaNumerica) //O switch pode ser ultilizado no lugar de if e Else quando estão relacionados logicamente
    {
        case 1: RegistrarBanda();
            break;
        case 2: MostrarBandasRegistradas();
            break;
        case 3: AvaliarUmaBanda();
            break;
        case 4: ExibirMedia();
            break;
        case -1: Console.WriteLine("Tchau tchau ^-^ ");
            break;
        default: Console.WriteLine("Opção invalida"); // Caso nenhuma das opçõas acima seja selecionada
            break;
    }
};

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibir titulo das bandas");
    Console.Write("Digite o nome da banda que deseja registrar: ");
    string nomeDaBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeDaBanda, new List<int>());
    Console.WriteLine($"A banda {nomeDaBanda} foi registrada com sucesso!"); // A interpolação de string é o "$" que faz com q possa colocar a variavel dentro das aspas
    Thread.Sleep(2000);
    Console.Clear(); /*Clear aqui faz com que limpe a tela e volte para a tela inicial*/
    ExibirOpcoesDoMenu();
}

void MostrarBandasRegistradas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Exibindo todas as bandas resgistradas");
    //for (int i = 0; i < listaDasBandas.Count; i++)
    //{
      //  Console.WriteLine($"Banda: {listaDasBandas[i]}");
    //}
    foreach (string banda in bandasRegistradas.Keys)
    {
        Console.WriteLine($"Banda: {banda}");
    }
    Console.WriteLine("\nDigite alguma tecla para voltar para o menu principal");
    Console.ReadKey(); //apertar qualquer tecla limpa e volta pro menu
    Console.Clear();
    ExibirOpcoesDoMenu();
}

void ExibirTituloDaOpcao(string titulo)
{
    int quantidadeDeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeDeLetras, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");
}

void AvaliarUmaBanda()
{
    //digite qal banda deseja avaliar
    //Se existir a banda no dicionario -> atribuir nota, senão, vota ao menu principal

    Console.Clear();
    ExibirTituloDaOpcao("Avaliar banda");
    Console.Write("Digite o nome da banda que deseja avaliar: ");
    string nomeDaBanda = Console.ReadLine()!;
    if (bandasRegistradas.ContainsKey(nomeDaBanda))
    {
        Console.Write($"Qual a nota que a banda {nomeDaBanda} merece: ");
        int nota = int.Parse(Console.ReadLine()!);
        bandasRegistradas[nomeDaBanda].Add(nota);
        Console.WriteLine($"\nA nota {nota} foi registrada com sucesso");
        Thread.Sleep(4000);
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
        Console.WriteLine("Digite alguma tecla para voltar para o menu principal");
        Console.ReadKey();
        Console.Clear();
        ExibirOpcoesDoMenu();
    }
}

void ExibirMedia()
{
 Console.Clear();
 ExibirTituloDaOpcao("Média da banda");
 Console.Write("Digite o nome da banda que queira ver a nota: ");
 string nomeDaBanda = Console.ReadLine()!;
 if (bandasRegistradas.ContainsKey(nomeDaBanda))
 {
     List<int> notasDaBanda = bandasRegistradas[nomeDaBanda];
     Console.WriteLine($"\nA média da banda {nomeDaBanda} é { notasDaBanda.Average()}.");
     Console.WriteLine("Digite alguma tecla para voltar para o menu principal");
     Console.ReadKey();
     Console.Clear();
     ExibirOpcoesDoMenu();
 
 }
 else
 {
     Console.WriteLine($"\nA banda {nomeDaBanda} não foi encontrada!");
     Console.WriteLine("Digite alguma tecla para voltar para o menu principal");
     Console.ReadKey();
     Console.Clear();
     ExibirOpcoesDoMenu();
 }
}




ExibirOpcoesDoMenu();