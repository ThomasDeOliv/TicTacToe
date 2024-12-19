using Microsoft.Extensions.DependencyInjection;
using System;
using TicTacTor.SingleResponsabilityRefactoring.Models.GameModel;
using TicTacTor.SingleResponsabilityRefactoring.Services;

namespace TicTacTor.SingleResponsabilityRefactoring
{
    internal enum GameSymbol
    {
        X = 'X',
        O = 'O'
    }

    internal static class Program
    {
        internal static void Main(string[] args)
        {
            IDIService serviceProvider = DIService.CreateServiceProvider();
            IGame? game = serviceProvider.ServiceProvider.GetService<IGame>();
            
            if (game is not null)
            {
                game.Init();
                game.Play();
            }
        }
    }
}
