using Domain.Entities;
using FluentAssertions;
using FluentAssertions.Specialized;

namespace Test.UnitTests;

public class ClientManagerTest
{
    #region GetClientById

    [Fact]
    public void GetClientById_WhenThereIsClientAccordingToGivenId_ShouldReturnClientAccordingToId()
    {
        //arrange
        var client = GetClient();

        var clientManager = new ClientManager();

        clientManager.AddClient(client);

        //act
        var result = clientManager.GetClientById(client.Id);

        //assert
        result.Should().BeEquivalentTo(client);
    }

    [Fact]
    public void GetClientById_WhenThereIsNoClientAccordingToGivenId_ShouldReturnClientAccountAccordingToId()
    {
        //arrange
        var client = GetClient();

        var clientManager = new ClientManager();

        //act
        var result = clientManager.GetClientById(client.Id);

        //assert
        result.Should().BeNull();
    }

    #endregion 

    #region AddClient

    [Fact]
    public void AddClient_WhenThereIsClientAccordingToGivenId_ShouldReturnClientAccordingToId()
    {
        //arrange
        var client = GetClient();

        var clientManager = new ClientManager();

        //act
        clientManager.AddClient(client);

        //assert
        clientManager
            .Clients
            .First()
            .Should()
            .BeEquivalentTo(client);
    }

    #endregion 

    #region RemoveClient

    [Fact]
    public void RemoveClient_WhenIdCorrespondsToExistingClientIsGiven_ShouldReturnTrueAndRemoveClient()
    {
        //arrange
        var client = GetClient();

        var clientManager = new ClientManager();

        clientManager.AddClient(client);

        //act
        var result = clientManager.RemoveClientById(client.Id);

        //assert
        result
            .Should()
            .BeTrue();

        clientManager
            .Clients
            .Should()
            .BeEmpty();
    }

    [Fact]
    public void RemoveClient_WhenIdCorrespondingToNotExistingClientIsGiven_ShouldReturnFalseAndDoNotRemoveClient()
    {
        //arrange
        var checkinAccount = GetClient();

        var clientManager = new ClientManager();

        clientManager.AddClient(checkinAccount);

        //act
        var result = clientManager.RemoveClientById(2);

        //assert
        result
            .Should()
            .BeFalse();

        clientManager
            .Clients
            .Should()
            .Contain(checkinAccount);
    }

    #endregion 

    #region GetClientStatusById

    [Fact]
    public void GetClientStatusById_WhenClienttIsNotActive_ShouldReturnFalse()
    {
        //arrange
        var client = GetClient();
        client.IsActive = false;

        var clientManager = new ClientManager();

        clientManager.AddClient(client);

        //act
        var result = clientManager.GetClientStatusById(client.Id);

        //assert
        result.Should().BeFalse();
    }

    [Fact]
    public void GetClientStatusById_WhenClientIsActive_ShouldReturnTrue()
    {
        //arrange
        var client = GetClient();

        var clientManager = new ClientManager();

        clientManager.AddClient(client);

        //act
        var result = clientManager.GetClientStatusById(client.Id);

        //assert
        result.Should().BeTrue();
    }

    #endregion 

    #region CleanList

    [Fact]
    public void CleanList_WhenThereIsAClientListWithValues_ShouldCleanTheList()
    {
        //arrange
        var client = GetClient();

        var clientManager = new ClientManager();

        clientManager.AddClient(client);

        //act
        clientManager.CleanList();

        //assert
        clientManager
            .Clients
            .Should()
            .BeEmpty();
    }

    #endregion 

    #region ValidateAge

    [Theory]
    [InlineData(17)]
    [InlineData(66)]
    public void ValidateAge_WhenGivenAgeIsNewerThanEighteenAndOlderThanSixtyFive_ShouldThrowAgeNotAllowedException(int age)
    {
        //arrange & act
        Action act = () => ClientManager.ValidateAge(age);

        //assert
        act
            .Should()
            .Throw<AgeNotAllowedException>();
    }

    [Fact]
    public void ValidateAge_WhenGivenAgeIsNotNewerThanEighteenOrOlderThanSixtyFive_ShouldNowThrowAgeNotAllowedException()
    {
        //arrange & act
        Action act = () => ClientManager.ValidateAge(30);

        //assert
        act
            .Should()
            .NotThrow<AgeNotAllowedException>();
    }

    #endregion 

    private Client GetClient() =>
        new(1, "Yu Narukami", 16, "mytrueself@gmail.com", true, 1);
}
