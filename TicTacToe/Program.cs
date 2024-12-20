using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using TicTacToe.Models.GameModel;
using TicTacToe.Services.DI;

namespace TicTacToe
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

            Console.WriteLine("Selectionnez Le type de jeu : ");
            Console.WriteLine("1 - Humain (X) contre Humain (O)");
            Console.WriteLine("2 - Humain (X) contre IA (O)");
            Console.WriteLine("3 - IA (X) contre Humain (O)");
            Console.WriteLine("4 - IA (X) contre IA (O)\n");
            Console.Write("Votre sélection : ");

            string? input = Console.ReadLine();

            bool initialized = serviceProvider.Init(input);

            Console.Clear();

            if (!initialized)
            {
                Console.Error.WriteLine("Invalid input provided by user : cannot initialize game.");
                Environment.Exit(1);
            }

            IGame game = serviceProvider.ServiceProvider.GetRequiredService<IGame>();
            Task gameTask = game.PlayAync();
            gameTask.Wait();
        }
    }
}