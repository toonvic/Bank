using Domain.Entities;

var clientManager = new ClientManager(GetClients());
var accountManager = new AccountManager(GetBankAccounts());

var shouldRun = true;

while (shouldRun)
{
    PrintMenu();

    var opcao = Console.ReadLine();

    switch (Convert.ToInt32(opcao.Trim()))
    {
        // Search for a Client
        case 1:
            Console.Write("Digite o ID do cliente: ");
            var searchClientId = Console.ReadLine();
            Client searchClient = clientManager.GetClientById(Convert.ToInt32(searchClientId));

            if (searchClient != null)
            {
                Console.WriteLine(searchClient.ToString());
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }

            BreakLine();
            break;

        // Search for a Checkin Account
        case 2:
            Console.Write("Digite o ID da conta: ");
            var searchAccountId = Console.ReadLine();
            CheckinAccount searchAccount = accountManager.GetAccountById(Convert.ToInt32(searchAccountId));

            if (searchAccount != null)
            {
                Console.WriteLine(searchAccount.ToString());
            }
            else
            {
                Console.WriteLine("Conta não encontrada!");
            }

            BreakLine();
            break;

        // Set Client as Active
        case 3:

            Console.Write("Digite o ID do cliente: ");
            var setAsActiveClientId = Console.ReadLine();
            Client setAsActiveClient = clientManager.GetClientById(Convert.ToInt32(setAsActiveClientId));

            if (setAsActiveClient != null)
            {
                setAsActiveClient.IsActive = true;
                Console.WriteLine("Cliente ativado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }

            BreakLine();
            break;

        // Set Client as Inactive
        case 4:

            Console.Write("Digite o ID do cliente: ");
            var setAsInactiveClientId = Console.ReadLine();
            Client setAsInactiveClient = clientManager.GetClientById(Convert.ToInt32(setAsInactiveClientId));

            if (setAsInactiveClientId != null)
            {
                setAsInactiveClient.IsActive = false;
                Console.WriteLine("Cliente desativado com sucesso!");
            }
            else
            {
                Console.WriteLine("Cliente não encontrado!");
            }

            BreakLine();
            break;

        // Exit
        case 5:
            shouldRun = false;
            Console.WriteLine("################# Sistema encerrado #################");
            break;

        default:
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            break;

    }
}

void BreakLine()
{
    Console.WriteLine("\n");
}

void PrintMenu()
{

    Console.WriteLine("O que você deseja fazer? \n");
    Console.WriteLine("1) Consultar por um cliente");
    Console.WriteLine("2) Consultar por uma conta corrente");
    Console.WriteLine("3) Ativar um cliente");
    Console.WriteLine("4) Desativar um cliente");
    Console.WriteLine("5) Sair");
    Console.WriteLine();
}

List<Client> GetClients () =>
    new List<Client>()
    {
        new Client(1, "Victor do Amaral", 21, "victor@gmail.com", true, 1),
        new Client(2, "Rossana Rocha da Silva", 20, "rossana@gmail.com", true, 2)
    };

List<CheckinAccount> GetBankAccounts() =>
    new List<CheckinAccount>()
    {
        new CheckinAccount(1, 0, true),
        new CheckinAccount(2, 0, true)
    };
