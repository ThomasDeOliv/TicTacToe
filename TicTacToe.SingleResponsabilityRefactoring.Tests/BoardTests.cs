using FluentAssertions;
using Moq;
using TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Tests
{
    public class BoardTests
    {
        private Mock<IPlayer> _fakeAIPlayerMock { get; }
        private Mock<IPlayer> _fakeHumanPlayerMock { get; }

        public BoardTests()
        {
            this._fakeAIPlayerMock = new Mock<IPlayer>();
            this._fakeHumanPlayerMock = new Mock<IPlayer>();
        }

        [Fact]
        public void Board_CurrentPlayerIsHuman_AtStart()
        {
            // Arrange
            IPlayer humanPlayer = this._fakeHumanPlayerMock.Object;
            IPlayer aiPlayer = this._fakeAIPlayerMock.Object;
            IBoard board = Board.Create(humanPlayer, aiPlayer);

            // Act
            IPlayer currentPlayer = board.CurrentPlayer;

            // Assert
            currentPlayer.Should().BeEquivalentTo(humanPlayer);
        }

        [Fact]
        public void Board_ChangePlayer_ChangeCurrentPlayer()
        {
            // Arrange
            IPlayer humanPlayer = this._fakeHumanPlayerMock.Object;
            IPlayer aiPlayer = this._fakeAIPlayerMock.Object;
            IBoard board = Board.Create(humanPlayer, aiPlayer);

            // Act
            board.ChangePlayer();

            // Assert
            board.CurrentPlayer.Should().BeEquivalentTo(aiPlayer);
        }

        [Fact]
        public void Board_IsGameBoardFull_ReturnsFalse_AtStart()
        {
            // Arrange
            IPlayer humanPlayer = this._fakeHumanPlayerMock.Object;
            IPlayer aiPlayer = this._fakeAIPlayerMock.Object;
            IBoard board = Board.Create(humanPlayer, aiPlayer);

            // Act
            bool atStartResult = board.IsGameBoardFull();

            // Assert
            atStartResult.Should().BeFalse();
        }

        [Fact]
        public void Board_IsGameBoardWin_ReturnsFalse_AtStart()
        {
            // Arrange
            IPlayer humanPlayer = this._fakeHumanPlayerMock.Object;
            IPlayer aiPlayer = this._fakeAIPlayerMock.Object;
            IBoard board = Board.Create(humanPlayer, aiPlayer);

            // Act
            bool atStartResult = board.IsGameBoardWin();

            // Assert
            atStartResult.Should().BeFalse();
        }

        //[Fact]
        //public void Board_IsGameBoardWin_ReturnsTrue_AfterNotGridFullGame()
        //{
        //    // Arrange
        //    this._fakeHumanPlayerMock.Setup(m => m.GetType()).Returns(() => typeof(HumanPlayer));
        //    this._fakeHumanPlayerMock.SetupGet(m => m.IsAI).Returns(() => false);
        //    this._fakeHumanPlayerMock.SetupGet(m => m.Symbol).Returns(() => 'X');
        //    this._fakeHumanPlayerMock.Setup(m => m.GetNextMove(It.IsAny<string?>())).Returns(ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(2, 2)));
        //    this._fakeHumanPlayerMock.Setup(m => m.GetNextMove(It.IsAny<string?>())).Returns(ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(1, 2)));
        //    this._fakeHumanPlayerMock.Setup(m => m.GetNextMove(It.IsAny<string?>())).Returns(ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(3, 2)));
        //    this._fakeAIPlayerMock.Setup(m => m.GetType()).Returns(() => typeof(AIPlayer));
        //    this._fakeHumanPlayerMock.SetupGet(m => m.IsAI).Returns(() => true);
        //    this._fakeAIPlayerMock.SetupGet(m => m.Symbol).Returns(() => 'O');
        //    this._fakeAIPlayerMock.Setup(m => m.GetNextMove(It.IsAny<string?>())).Returns(ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(1, 1)));
        //    this._fakeAIPlayerMock.Setup(m => m.GetNextMove(It.IsAny<string?>())).Returns(ResultDTO<IPlayerMove>.CreateSuccessdResult(PlayerMove.Create(3, 2)));
        //    IPlayer humanPlayer = this._fakeHumanPlayerMock.Object;
        //    IPlayer aiPlayer = this._fakeAIPlayerMock.Object;
        //    IBoard board = Board.Create(humanPlayer, aiPlayer);

        //    // Act
        //    ResultDTO<IPlayerMove> firstGame = humanPlayer.GetNextMove("");
        //    //board.PlayOnGameBoard(firstGame.Value.Row);
        //    aiPlayer.GetNextMove("");
        //    humanPlayer.GetNextMove("");
        //    aiPlayer.GetNextMove("");
        //    humanPlayer.GetNextMove("");

        //    // Assert
        //    //atStartResult.Should().BeFalse();
        //}
    }
}
