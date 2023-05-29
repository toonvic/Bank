using System.Text;

namespace Domain.Entities;

public class Client
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
    public int CheckinAccountId { get; set; }

    public Client(
        int id,
        string name,
        int age,
        string email,
        bool isActive,
        int checkinAccountId
    )
    {
        Id = id;
        Name = name;
        Age = age;
        Email = email;
        IsActive = isActive;
        CheckinAccountId = checkinAccountId;
    }

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("========================");
        stringBuilder.AppendLine("Id: " + Id);
        stringBuilder.AppendLine("Nome: " + Name);
        stringBuilder.AppendLine("Email: " + Email);
        stringBuilder.AppendLine("Idade: " + Age);
        stringBuilder.AppendLine("Status: " + (IsActive ? "Ativa" : "Inativa"));
        stringBuilder.AppendLine("========================");

        return stringBuilder.ToString();
    }
}
