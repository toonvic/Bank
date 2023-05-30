namespace Domain.Entities;

public class ClientManager
{
    public List<Client> Clients { get; set; }

    public ClientManager() =>
        Clients = new List<Client>();

    public ClientManager(List<Client> clients) =>
        Clients = clients;

    public Client GetClientById(int id) =>
        Clients.FirstOrDefault(client => client.Id == id);

    public void AddClient(Client client) =>
        Clients.Add(client);

    public bool RemoveClientById(int id)
    {
        bool ClientHasBeenRemoved = false;

        var client = Clients.FirstOrDefault(client => client.Id == id);

        if (client != null)
        {
            Clients.Remove(client);

            ClientHasBeenRemoved = true;
        }

        return ClientHasBeenRemoved;
    }

    public bool GetClientStatusById(int id)
    {
        var client = Clients.FirstOrDefault(account => account.Id == id);

        if (client != null)
        {
            return client.IsActive;
        }

        return false;
    }

    public void CleanList() =>
        Clients = new List<Client>();

    public static bool ValidateAge(int idade) =>
        idade < 18 || idade > 65 ?
        throw new AgeNotAllowedException() :
        true;
}
