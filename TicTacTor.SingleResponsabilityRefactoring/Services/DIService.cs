using Microsoft.Extensions.DependencyInjection;
using TicTacTor.SingleResponsabilityRefactoring.Models.BoardModel;
using TicTacTor.SingleResponsabilityRefactoring.Models.GameModel;
using TicTacTor.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacTor.SingleResponsabilityRefactoring.Services
{
    internal class DIService
    {
        private readonly ServiceProvider _serviceProvider;

        public DIService()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddSingleton<HumanPlayer>((sp) => new HumanPlayer());
            serviceDescriptors.AddSingleton<AIPlayer>((sp) => new AIPlayer());
            serviceDescriptors.AddSingleton<IBoard, Board>((sp) =>
            {
                IPlayer humanPlayer = sp.GetRequiredService<HumanPlayer>();
                IPlayer aIPlayer = sp.GetRequiredService<AIPlayer>();
                return new Board(humanPlayer, aIPlayer);
            });
            serviceDescriptors.AddSingleton<IGame, Game>((sp) =>
            {
                IBoard board = sp.GetRequiredService<IBoard>();
                return new Game(board);
            });

            this._serviceProvider = serviceDescriptors.BuildServiceProvider();
        }

        public ServiceProvider ServiceProvider { get => this._serviceProvider; }
    }
}
