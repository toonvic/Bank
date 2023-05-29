using Domain.Entities;
using FluentAssertions;

namespace Test.UnitTests;

public class AccountManagerTest
{
    #region GetAccountById

    [Fact]
    public void GetAccountById_WhenThereIsCheckinAccountAccordingToGivenId_ShouldReturnCheckinAccountAccordingToId()
    {
        //arrange
        var checkinAccount = GetAccount();

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);

        //act
        var result = accountManager.GetAccountById(checkinAccount.Id);

        //assert
        result.Should().BeEquivalentTo(checkinAccount);
    }

    [Fact]
    public void GetAccountById_WhenThereIsNoCheckinAccountAccordingToGivenId_ShouldReturnCheckinAccountAccordingToId()
    {
        //arrange
        var checkinAccount = GetAccount();

        var accountManager = new AccountManager();

        //act
        var result = accountManager.GetAccountById(checkinAccount.Id);

        //assert
        result.Should().BeNull();
    }

    #endregion 

    #region AddAccount

    [Fact]
    public void AddAccount_WhenThereIsCheckinAccountAccordingToGivenId_ShouldReturnCheckinAccountAccordingToId()
    {
        //arrange
        var checkinAccount = GetAccount();

        var accountManager = new AccountManager();

        //act
        accountManager.AddAccount(checkinAccount);

        //assert
        accountManager
            .CheckinAccounts
            .First()
            .Should()
            .BeEquivalentTo(checkinAccount);
    }

    #endregion 

    #region RemoveAccount

    [Fact]
    public void RemoveAccount_WhenIdCorrespondingToExistingCheckinAccountIsGiven_ShouldReturnTrueRemoveCheckinAccount()
    {
        //arrange
        var checkinAccount = GetAccount();

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);

        //act
        accountManager.RemoveAccountById(checkinAccount.Id);

        //assert
        accountManager
            .CheckinAccounts
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void RemoveAccount_WhenIdCorrespondingToNotExistingCheckinAccountIsGiven_ShouldReturnFalseAndDoNotRemoveCheckinAccount()
    {
        //arrange
        var checkinAccount = GetAccount();

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);

        //act
        accountManager.RemoveAccountById(2);

        //assert
        accountManager
            .CheckinAccounts
            .Should()
            .Contain(checkinAccount);
    }

    #endregion 

    #region GetAccountStatusById

    [Fact]
    public void GetAccountStatusById_WhenAccountIsNotActive_ShouldReturnFalse()
    {
        //arrange
        var checkinAccount = GetAccount();
        checkinAccount.IsActive = false;

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);

        //act
        var result = accountManager.GetAccountStatusById(checkinAccount.Id);

        //assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetAccountStatusById_WhenAccountIsActive_ShouldReturntrue()
    {
        //arrange
        var checkinAccount = GetAccount();

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);

        //act
        var result = accountManager.GetAccountStatusById(checkinAccount.Id);

        //assert
        result.Should().BeTrue();
    }

    #endregion 

    #region TransferAmount

    [Fact]
    public void TransferAmount_WhenOriginAccountDoesNotHaveEnoughAmountToTranfer_ShouldReturnFalse()
    {
        //arrange
        var checkinAccount = GetAccount();
        var otherCheckinAccount = GetOtherAccount();

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);
        accountManager.AddAccount(otherCheckinAccount);

        //act
        var result = accountManager.TransferAmount(
            checkinAccount.Id,
            otherCheckinAccount.Id,
            1001
        );

        //assert
        result.Should().BeFalse();
    }

    [Fact]
    public void TransferAmount_WhenOriginAccountHasEnoughAmountToTranfer_ShouldReturnTrueAndTransferAmount()
    {
        //arrange
        var checkinAccount = GetAccount();
        var otherCheckinAccount = GetOtherAccount();

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);
        accountManager.AddAccount(otherCheckinAccount);

        //act
        var result = accountManager.TransferAmount(
            checkinAccount.Id,
            otherCheckinAccount.Id,
            1000
        );

        //assert
        result.Should().BeTrue();
        checkinAccount.Amount.Should().Be(0);
        otherCheckinAccount.Amount.Should().Be(3000);
    }

    [Fact]
    public void TransferAmount_WhenAccountIsActive_ShouldReturntrue()
    {
        //arrange
        var checkinAccount = GetAccount();

        var accountManager = new AccountManager();

        accountManager.AddAccount(checkinAccount);

        //act
        var result = accountManager.GetAccountStatusById(checkinAccount.Id);

        //assert
        result.Should().BeTrue();
    }

    #endregion 

    private Client GetClient() =>
        new(1, "Yu Narukami", 16, "mytrueself@gmail.com", true, 1);

    private CheckinAccount GetAccount() =>
        new(1, 1000, true);

    private CheckinAccount GetOtherAccount() =>
        new(2, 2000, true);
}