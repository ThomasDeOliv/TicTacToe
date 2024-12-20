using System.Threading;
using System.Threading.Tasks;
using TicTacToe.DTO;
using TicTacToe.Models.BoardModel;
using TicTacToe.Models.PlayerModel.PlayerMoveModel;

namespace TicTacToe.Models.PlayerModel
{
    public abstract class Player : IPlayer
    {
        protected readonly IBoard _board;
        protected Player(IBoard board, GameSymbol gameSymbol)
        {
            this._board = board;
            this.Symbol = (char)gameSymbol;
        }
        public abstract bool IsAI { get; }
        public char Symbol { get; }
        public abstract ResultDTO<IPlayerMove> GetNextMove();
        public abstract Task<ResultDTO<IPlayerMove>> GetNextMoveAsync(CancellationToken cancellationToken = default);
    }
}
