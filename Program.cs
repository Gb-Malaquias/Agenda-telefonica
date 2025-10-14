public class Contato
{
    public string Nome { get; set; }
    public string Telefone { get; set; }

    public Contato(string nome, string telefone)
    {
        Nome = nome;
        Telefone = telefone;
    }

}

public class Agenda
{
    public string Proprietario { get; set; }
    private readonly List<Contato> contatos;

    public Agenda(string Proprietario)
    {
        this.Proprietario = Proprietario;
        contatos = new List<Contato>();
    }

    public bool AdicionarContato(Contato contato)
    {
        if (contatos.Any(c => c.Nome == contato.Nome))
        {
            Console.WriteLine("Contato com o mesmo nome já existe.");
            return false;
        }
        contatos.Add(contato);
        return true;
    }

    public void ListarContatos()
    {
        Console.WriteLine($"Agenda de {Proprietario}:");
        Console.WriteLine("-------------------------");
        Console.WriteLine("Contatos: ");
        foreach (var c in contatos)
        {
            Console.WriteLine($"Nome: {c.Nome}, Telefone: {c.Telefone}");
        }

        Console.WriteLine("-------------------------");
        Console.WriteLine("total de contatos: " + contatos.Count);

    }


    public bool RemoverContato(string nome)
    {
        var contato = contatos.FirstOrDefault(c => c.Nome == nome);
        if (contato != null)
        {
            contatos.Remove(contato);
            return true;
        }
        return false; // Contato não encontrado
    }
}


public class Program
{
    public static void Main()
    {
        Agenda agenda = null;
        string opcao;





do{


        Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");


            if (agenda != null)
            {
                Console.WriteLine($"Agenda de {agenda.Proprietario}");
            }
            else
            {
            Console.WriteLine("bem vindo a agenda telefonica");
            }
            Console.WriteLine("Opções:");
            Console.WriteLine("1- Criar Agenda");
            Console.WriteLine("2- Adicionar Contato");
            Console.WriteLine("3- Listar Contatos");
            Console.WriteLine("4- Remover Contato");
            Console.WriteLine("5- Sair");
            Console.Write("Escolha uma opção: ");
            opcao = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");  


            switch (opcao)
            {
                case "1":
                    Console.Write("Digite o nome do proprietário da agenda: ");
                    string nomeProprietario = Console.ReadLine();
                    agenda = new Agenda(nomeProprietario);
                    Console.WriteLine("Agenda criada com sucesso!");
                    break;


                case "2":
                    if (agenda == null)
                    {
                        Console.WriteLine("Por favor, crie uma agenda primeiro.");
                        break;
                    }
                    Console.Write("Nome do contato: ");
                    string nomeContato = Console.ReadLine();
                    Console.Write("Telefone do contato: ");
                    string telefoneContato = Console.ReadLine();
                    bool adicionou = agenda.AdicionarContato(new Contato(nomeContato, telefoneContato));



                    if (!adicionou)
                    {

                    }
                    else
                    {
                        Console.WriteLine("Contato adicionado com sucesso!");
                    }
                    break;


                case "3":
                    if (agenda == null)
                    {
                        Console.WriteLine("Por favor, crie uma agenda primeiro.");
                        break;
                    }

                    agenda.ListarContatos();
                    break;




                case "4":
                    if (agenda == null)
                    {
                        Console.WriteLine("Por favor, crie uma agenda primeiro.");
                        break;
                    }

                    Console.Write("Nome do contato a ser removido: ");
                    string nomeParaRemover = Console.ReadLine();
                    if (agenda.RemoverContato(nomeParaRemover))
                    {
                        Console.WriteLine("Contato removido com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Contato não encontrado.");
                    }

                    break;

                case "5":
                    Console.WriteLine("Encerrando o programa. Até mais!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    return;
            }

            } while (opcao != "5") ;
        }

    }