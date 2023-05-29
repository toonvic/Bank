using System.Text;

namespace Domain.Entities;

public class CheckinAccount
{
    public int Id { get; set; }
    public double Amount { get; set; }
    public bool IsActive { get; set; }

    public CheckinAccount(
        int id,
        double amount,
        bool isActive
    )
    {
        Id = id;
        Amount = amount;
        IsActive = isActive;
    }

    public string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("========================");
        stringBuilder.AppendLine("Id: " + this.Id);
        stringBuilder.AppendLine("Saldo: " + this.Amount);
        stringBuilder.AppendLine("Status: " + (this.IsActive ? "Ativa" : "Inativa"));
        stringBuilder.AppendLine("========================");

        return stringBuilder.ToString();
    }
}
