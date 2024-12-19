using Microsoft.Extensions.DependencyInjection;
using TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel;
using TicTacToe.SingleResponsabilityRefactoring.Models.GameModel;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Services
{
    public class DIService : IDIService
    {
        public ServiceProvider ServiceProvider { get; }

        protected DIService()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddSingleton<HumanPlayer>((sp) => HumanPlayer.Create());
            serviceDescriptors.AddSingleton<AIPlayer>((sp) => AIPlayer.Create());
            serviceDescriptors.AddSingleton<IBoard, Board>((sp) =>
            {
                IPlayer humanPlayer = sp.GetRequiredService<HumanPlayer>();
                IPlayer aIPlayer = sp.GetRequiredService<AIPlayer>();
                return Board.Create(humanPlayer, aIPlayer);
            });
            serviceDescriptors.AddSingleton<IGame, Game>((sp) =>
            {
                IBoard board = sp.GetRequiredService<IBoard>();
                return Game.Create(board);
            });

            this.ServiceProvider = serviceDescriptors.BuildServiceProvider();
        }

        public static IDIService Create()
        {
            return new DIService();
        }
    }
}
