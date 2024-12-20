using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TicTacToe.DTO;
using TicTacToe.Models.BoardModel;
using TicTacToe.Models.PlayerModel;
using TicTacToe.Models.PlayerModel.PlayerMoveModel;
using TicTacToe.Services.InOut;

namespace TicTacToe.Models.GameModel
{
    public class Game : IGame
    {
        private readonly IInOutService _inOutService;
        private readonly IBoard _board;
        private readonly IReadOnlyList<IPlayer> _players;
        private IPlayer? _currentPlayer;
        private bool _played;

        public IPlayer CurrentPlayer
        {
            get
            {
                this._currentPlayer ??= this._players[0];
                return this._currentPlayer;
            }
        }

        protected Game(IInOutService inOutService, IReadOnlyList<IPlayer> players, IBoard board)
        {
            this._inOutService = inOutService;
            this._board = board;
            this._players = players;
            this._currentPlayer = null;
            this._played = false;
        }

        public void Play()
        {
            if (!this._played)
            {
                this._inOutService.DisplayGameBoard();

                while (true)
                {
                    this._inOutService.GetStartSentence(this.CurrentPlayer);

                    ResultDTO<IPlayerMove> result = this.CurrentPlayer.GetNextMove();

                    if (!result.Success)
                    {
                        bool shouldContinue = this._inOutService.ShouldContinueAndHandleError(result.Reason);

                        if (shouldContinue)
                        {
                            continue;
                        }

                        break;
                    }

                    // Play
                    if (result.Value is not null && !this._board.WriteInCell(result.Value.Row, result.Value.Column, this.CurrentPlayer.Symbol))
                    {
                        this._inOutService.InvalidMove();
                        continue;
                    }

                    this._inOutService.Clear();

                    this._inOutService.DisplayGameBoard();

                    if (this._board.IsGameBoardWin())
                    {
                        this._inOutService.PlayerWonGame(this.CurrentPlayer);
                        break;
                    }

                    if (this._board.IsGameBoardFull())
                    {
                        this._inOutService.Draw();
                        break;
                    }

                    this.ChangePlayer();
                }

                this._played = true;
            }
            else
            {
                this._inOutService.Clear();
                this._inOutService.AlreadyPlayed();
                this._inOutService.DisplayGameBoard();
            }
        }

        public async Task PlayAync(CancellationToken cancellationToken = default)
        {
            if (!this._played)
            {
                this._inOutService.DisplayGameBoard();

                while (true)
                {
                    this._inOutService.GetStartSentence(this.CurrentPlayer);

                    ResultDTO<IPlayerMove> result = await this.CurrentPlayer.GetNextMoveAsync();

                    if (!result.Success)
                    {
                        bool shouldContinue = this._inOutService.ShouldContinueAndHandleError(result.Reason);

                        if (shouldContinue)
                        {
                            continue;
                        }

                        break;
                    }

                    // Play
                    if (result.Value is not null && !this._board.WriteInCell(result.Value.Row, result.Value.Column, this.CurrentPlayer.Symbol))
                    {
                        this._inOutService.InvalidMove();
                        continue;
                    }

                    this._inOutService.Clear();

                    this._inOutService.DisplayGameBoard();

                    if (this._board.IsGameBoardWin())
                    {
                        this._inOutService.PlayerWonGame(this.CurrentPlayer);
                        break;
                    }

                    if (this._board.IsGameBoardFull())
                    {
                        this._inOutService.Draw();
                        break;
                    }

                    this.ChangePlayer();
                }

                this._played = true;
            }
            else
            {
                this._inOutService.Clear();
                this._inOutService.AlreadyPlayed();
                this._inOutService.DisplayGameBoard();
            }
        }

        public static Game Create(IInOutService inOutService, IReadOnlyList<IPlayer> players, IBoard board)
        {
            return new Game(inOutService, players, board);
        }

        public void ChangePlayer()
        {
            this._currentPlayer = (this._currentPlayer == this._players[0]) ?
                this._players[1] : this._players[0];
        }
    }
}
