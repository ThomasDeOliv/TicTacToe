using Microsoft.Extensions.DependencyInjection;
using TicTacToe.SingleResponsabilityRefactoring.Models.BoardModel;
using TicTacToe.SingleResponsabilityRefactoring.Models.GameModel;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel;
using TicTacToe.SingleResponsabilityRefactoring.Services.InOut;

namespace TicTacToe.SingleResponsabilityRefactoring.Services.DI
{
    public class DIService : IDIService
    {
        public ServiceProvider ServiceProvider { get; }

        protected DIService()
        {
            IServiceCollection serviceDescriptors = new ServiceCollection();

            serviceDescriptors.AddSingleton<IInOutService, InOutService>((sp) =>
            {
                return InOutService.Create();
            });
            serviceDescriptors.AddSingleton((sp) =>
            {
                IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                return HumanPlayer.Create(inOutService);
            });
            serviceDescriptors.AddSingleton((sp) =>
            {
                IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                return AIPlayer.Create(inOutService);
            });
            serviceDescriptors.AddSingleton<IBoard, Board>((sp) =>
            {
                IPlayer humanPlayer = sp.GetRequiredService<HumanPlayer>();
                IPlayer aIPlayer = sp.GetRequiredService<AIPlayer>();
                return Board.Create(humanPlayer, aIPlayer);
            });
            serviceDescriptors.AddSingleton<IGame, Game>((sp) =>
            {
                IBoard board = sp.GetRequiredService<IBoard>();
                IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                return Game.Create(inOutService, board);
            });

            ServiceProvider = serviceDescriptors.BuildServiceProvider();
        }

        public static IDIService Create()
        {
            return new DIService();
        }
    }
}
