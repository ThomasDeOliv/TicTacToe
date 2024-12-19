using Microsoft.Extensions.DependencyInjection;
using System;
using TicTacToe.SingleResponsabilityRefactoring.Models.GameModel;
using TicTacToe.SingleResponsabilityRefactoring.Services;

namespace TicTacToe.SingleResponsabilityRefactoring
{
    public enum GameSymbol
    {
        X = 'X',
        O = 'O'
    }

    public static class Program
    {
        public static void Main(string[] args)
        {
            IDIService serviceProvider = DIService.Create();
            IGame? game = serviceProvider.ServiceProvider.GetService<IGame>();
            
            if (game is not null)
            {
                game.Init();
                game.Play();
            }
        }
    }
}
