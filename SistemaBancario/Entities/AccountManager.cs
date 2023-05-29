namespace Domain.Entities;

public class AccountManager
{
    public List<CheckinAccount> CheckinAccounts { get; set; }

	public AccountManager()
	{
		CheckinAccounts = new List<CheckinAccount>();
	}

	public AccountManager(List<CheckinAccount> checkinAccounts) =>
		CheckinAccounts = checkinAccounts;
	
	public CheckinAccount GetAccountById(int id) =>
        CheckinAccounts.FirstOrDefault(account => account.Id == id);

    public void AddAccount(CheckinAccount account) =>
		CheckinAccounts.Add(account);

	public bool RemoveAccountById(int id)
	{
		bool AccountHasBeenRemoved = false;

		var account = CheckinAccounts.FirstOrDefault(account => account.Id == id);

		if (account != null)
		{
			CheckinAccounts.Remove(account);

            AccountHasBeenRemoved = true;
        }

        return AccountHasBeenRemoved;
	}

	public bool GetAccountStatusById(int id)
	{
		var account = CheckinAccounts.FirstOrDefault(account => account.Id == id);

		if (account != null)
		{
			return account.IsActive;
		}

		return false;
	}

	public bool TransferAmount(int originAccountId, int destinationAccountId, double amount)
	{
		var success = false;

		var originAccount = GetAccountById(originAccountId);
		var destinationAccount = GetAccountById(destinationAccountId);

		if (originAccount.Amount >= amount)
		{
			destinationAccount.Amount += amount;
			originAccount.Amount -= amount;

			success = true;
        }

		return success;
	}
}
