namespace TicTacTor.SingleResponsabilityRefactoring.Players
{
    internal class Player : IPlayer
    {
        private readonly char _symbol;

        private Player(GameSymbol gameSymbol)
        {
            _symbol = (char)gameSymbol;
        }

        internal static Player CreatePlayer(GameSymbol gameSymbol)
        {
            return new Player(gameSymbol);
        }

        public char GetCurrentPlayer()
        {
            return _symbol;
        }
    }
}
