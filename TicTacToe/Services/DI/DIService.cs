using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TicTacToe.Models.BoardModel;
using TicTacToe.Models.GameModel;
using TicTacToe.Models.PlayerModel;
using TicTacToe.Services.InOut;

namespace TicTacToe.Services.DI
{
    public class DIService : IDIService
    {
        private IServiceCollection _serviceDescriptors;
        private ServiceProvider? _serviceProvider;
        public ServiceProvider ServiceProvider
        {
            get
            {
                this._serviceProvider ??= this._serviceDescriptors.BuildServiceProvider();
                return this._serviceProvider;
            }
        }

        protected DIService()
        {
            this._serviceDescriptors = new ServiceCollection();

            this._serviceDescriptors.AddSingleton<IBoard, Board>((sp) =>
            {
                return Board.Create();
            });
            this._serviceDescriptors.AddSingleton<IInOutService, InOutService>((sp) =>
            {
                IBoard board = sp.GetRequiredService<IBoard>();
                return InOutService.Create(board);
            });
            this._serviceDescriptors.AddSingleton<IGame, Game>((sp) =>
            {
                IBoard board = sp.GetRequiredService<IBoard>();
                IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                IReadOnlyList<IPlayer> players = sp.GetRequiredService<IReadOnlyList<IPlayer>>();
                return Game.Create(inOutService, players, board);
            });

            this._serviceProvider = null;
        }

        public static IDIService Create()
        {
            return new DIService();
        }

        public bool Init(string? input)
        {
            bool initialized = false;

            if (!string.IsNullOrWhiteSpace(input))
            {
                switch (input)
                {
                    case "1":
                        this._serviceDescriptors.AddSingleton<IReadOnlyList<IPlayer>>((sp) =>
                        {
                            IBoard board = sp.GetRequiredService<IBoard>();
                            IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                            IPlayer firstPlayer = HumanPlayer.Create(board, inOutService, GameSymbol.X);
                            IPlayer secondPlayer = HumanPlayer.Create(board, inOutService, GameSymbol.O);

                            return new List<IPlayer>()
                            {
                                firstPlayer,
                                secondPlayer
                            };
                        });
                        initialized = true;
                        break;

                    case "2":
                        this._serviceDescriptors.AddSingleton<IReadOnlyList<IPlayer>>((sp) =>
                        {
                            IBoard board = sp.GetRequiredService<IBoard>();
                            IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                            IPlayer firstPlayer = HumanPlayer.Create(board, inOutService, GameSymbol.X);
                            IPlayer secondPlayer = AIPlayer.Create(board, inOutService, GameSymbol.O);

                            return new List<IPlayer>()
                            {
                                firstPlayer,
                                secondPlayer
                            };
                        });
                        initialized = true;
                        break;

                    case "3":
                        this._serviceDescriptors.AddSingleton<IReadOnlyList<IPlayer>>((sp) =>
                        {
                            IBoard board = sp.GetRequiredService<IBoard>();
                            IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                            IPlayer firstPlayer = AIPlayer.Create(board, inOutService, GameSymbol.X);
                            IPlayer secondPlayer = HumanPlayer.Create(board, inOutService, GameSymbol.O);

                            return new List<IPlayer>()
                            {
                                firstPlayer,
                                secondPlayer
                            };
                        });
                        initialized = true;
                        break;

                    case "4":
                        this._serviceDescriptors.AddSingleton<IReadOnlyList<IPlayer>>((sp) =>
                        {
                            IBoard board = sp.GetRequiredService<IBoard>();
                            IInOutService inOutService = sp.GetRequiredService<IInOutService>();
                            IPlayer firstPlayer = AIPlayer.Create(board, inOutService, GameSymbol.X);
                            IPlayer secondPlayer = AIPlayer.Create(board, inOutService, GameSymbol.O);

                            return new List<IPlayer>()
                            {
                                firstPlayer,
                                secondPlayer
                            };
                        });
                        initialized = true;
                        break;
                }
            }

            return initialized;
        }
    }
}
