namespace TicTacToe.SingleResponsabilityRefactoring.Tests
{
    public class HumanPlayerTests
    {
        //[Fact]
        //public void HumanPlayer_GetNextMove_ValidInput_GetValidResult()
        //{
        //    // Arrange
        //    HumanPlayer humanPlayer = HumanPlayer.Create();

        //    // Act
        //    ResultDTO<IPlayerMove> result = humanPlayer.GetNextMove("1 1");

        //    // Assert
        //    result.Success.Should().Be(true);
        //    result.Reason.Should().BeNull();
        //    result.Value.Should().NotBeNull();
        //    result.Value.Should().BeEquivalentTo(PlayerMove.Create(1, 1));
        //}

        //[Theory]
        //[InlineData("", "Empty")]
        //[InlineData("BONJOUR", "InvalidInput")]
        //[InlineData("q", "Quit")]
        //[InlineData("0 0", "OutOfRangeRowAndColumn")]
        //[InlineData("4 4", "OutOfRangeRowAndColumn")]
        //[InlineData("4 1", "OutOfRangeRow")]
        //[InlineData("1 4", "OutOfRangeColumn")]
        //public void HumanPlayer_GetNextMove_InvalidInput_GetInvalidResult(string? input, string reason)
        //{
        //    // Arrange
        //    HumanPlayer humanPlayer = HumanPlayer.Create();

        //    // Act
        //    ResultDTO<IPlayerMove> result = humanPlayer.GetNextMove(input);

        //    // Assert
        //    result.Success.Should().Be(false);
        //    result.Reason.Should().NotBeNull();
        //    result.Reason.Should().BeEquivalentTo(reason);
        //    result.Value.Should().BeNull();
        //}

        //[Fact]
        //public void AIPlayer_GetNextMove_Default_GetValidResult()
        //{
        //    // Arrange
        //    AIPlayer aiPlayer = AIPlayer.Create();

        //    // Act
        //    ResultDTO<IPlayerMove> result = aiPlayer.GetNextMove();
        //    bool conditionResult = result.Value is not null && result.Value.Row > 0 && result.Value.Row < 4 && result.Value.Column > 0 && result.Value.Column < 4;

        //    // Assert
        //    result.Success.Should().Be(true);
        //    result.Reason.Should().BeNull();
        //    conditionResult.Should().BeTrue();
        //}

        //[Theory]
        //[InlineData("")]
        //[InlineData("q")]
        //[InlineData("A random string")]
        //[InlineData("1 1")]
        //[InlineData("4 4")]
        //[InlineData("0 0")]
        //[InlineData("4 0")]
        //[InlineData("0 4")]
        //[InlineData("1 0")]
        //[InlineData("0 1")]
        //public void AIPlayer_GetNextMove_RandomString_GetValidResult(string? randomString)
        //{
        //    // Arrange
        //    AIPlayer aiPlayer = AIPlayer.Create();

        //    // Act
        //    ResultDTO<IPlayerMove> result = aiPlayer.GetNextMove(randomString);
        //    bool conditionResult = result.Value is not null && result.Value.Row > 0 && result.Value.Row < 4 && result.Value.Column > 0 && result.Value.Column < 4;

        //    // Assert
        //    result.Success.Should().Be(true);
        //    result.Reason.Should().BeNull();
        //    conditionResult.Should().BeTrue();
        //}
    }
}