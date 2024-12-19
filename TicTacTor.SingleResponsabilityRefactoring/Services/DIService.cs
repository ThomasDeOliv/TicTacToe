using Microsoft.Extensions.DependencyInjection;
using TicTacTor.SingleResponsabilityRefactoring.Models.BoardModel;
using TicTacTor.SingleResponsabilityRefactoring.Models.GameModel;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Services
{
    internal class DIService : IDIService
    {
        public ServiceProvider ServiceProvider { get; }

        private DIService()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddSingleton<HumanPlayer>((sp) => HumanPlayer.CreateHumanPlayer());
            serviceDescriptors.AddSingleton<AIPlayer>((sp) => AIPlayer.CreateAIPlayer());
            serviceDescriptors.AddSingleton<IBoard, Board>((sp) =>
            {
                IPlayer humanPlayer = sp.GetRequiredService<HumanPlayer>();
                IPlayer aIPlayer = sp.GetRequiredService<AIPlayer>();
                return Board.CreateBoard(humanPlayer, aIPlayer);
            });
            serviceDescriptors.AddSingleton<IGame, Game>((sp) =>
            {
                IBoard board = sp.GetRequiredService<IBoard>();
                return Game.CreateGame(board);
            });

            this.ServiceProvider = serviceDescriptors.BuildServiceProvider();
        }

        public static IDIService CreateServiceProvider()
        {
            return new DIService();
        }
    }
}
