/*
IMPORTANT:

The Hierarchy of the test folders is taken from the namespace of "CreateMenuCommandHandler.cs" 
and name of this class is taken form "CreateMenuCommandHandler" (The class we intend to test)
witht he suffix of "Test".

*/
using System.Net.NetworkInformation;

using Moq;
using PoolDinner.Application.Common.Interfaces.Persistence;
using PoolDinner.Application.Menus.Commands.CreateMenu;
using PoolDinner.Application.UnitTests.Menus.Commands.TestUtils;
using PoolDinner.Application.UnitTests.TestUtils.Menus.Extensions;

namespace PoolDinner.Application.UnitTests.Menus.Commands.CreateMenu;
public class CreateMenuCommandHandlerTest
{
    // Function name: void T1_T2_T3 ()
    // T1 : SUT -> System Under Test / logical component that we are testing 
    // T2 : Scenario that we are testing / what we are testing
    // T3 : Expected outcome
    private readonly CreateMenuCommandHandler _handler;
    private readonly Mock<IMenuRepository> _mockMenuRepository;
    public CreateMenuCommandHandlerTest()
    {
        _mockMenuRepository = new Mock<IMenuRepository>();
        _handler = new CreateMenuCommandHandler(_mockMenuRepository.Object);
    }
    [Theory]
    [MemberData(nameof(ValidCreateCommands))]
    public async Task HandleCreateMenuCommand_WhenMenuisValid_ShouldCreateAndReturnMenu (CreateMenuCommand createMenuCommand) 
    {
        // Arrange
        // Correct menu command
       // var createMenuCommand = CreateMenuCommandUtils.CreateCommand();

        // Act
        // Invoke Handler
        var result = await _handler.Handle(createMenuCommand, CancellationToken.None);

        // Assert
        // 1. Check if the correct menu created
        result.ValidateCreatedFrom(createMenuCommand);
        // 2. Menu inserted into the repository
        _mockMenuRepository.Verify(m => m.Add(result),Times.Once());
    }
    public static IEnumerable<object[]> ValidCreateCommands()
    {
        yield return new [] { CreateMenuCommandUtils.CreateCommand() };
        yield return new [] {
            CreateMenuCommandUtils.CreateCommand(CreateMenuCommandUtils.CreateSectionsCommand(10,
            CreateMenuCommandUtils.CreateItemsCommand(5)))
            };
    }
}
