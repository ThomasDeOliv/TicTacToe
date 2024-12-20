using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.Models.GameModel;
using TicTacToe.SingleResponsabilityRefactoring.Services.DI;

namespace TicTacToe.SingleResponsabilityRefactoring
{
    public enum GameSymbol
    {
        X = 'X',
        O = 'O'
    }

    [ExcludeFromCodeCoverage]
    public static class Program
    {
        public static void Main(string[] args)
        {
            IDIService serviceProvider = DIService.Create();
            IGame? game = serviceProvider.ServiceProvider.GetService<IGame>();

            if (game is null)
            {
                Console.Error.WriteLine("Cannot find service 'IGame' in service provider.");
                Environment.Exit(1);
            }

            game.Init();
            Task gameTask = game.PlayAync();
            gameTask.Wait();
        }
    }
}