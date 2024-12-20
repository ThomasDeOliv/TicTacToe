using System;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.SingleResponsabilityRefactoring.Models.PlayerModel;

namespace TicTacToe.SingleResponsabilityRefactoring.Services.InOut
{
    public class InOutService : IInOutService
    {
        protected InOutService()
        {

        }

        public static InOutService Create()
        {
            return new InOutService();
        }

        public string? GetHumanUserInput()
        {
            return Console.ReadLine();
        }

        public async Task AIWaitingCallbackAsync(IPlayer player)
        {
            StringBuilder stringBuilder = new StringBuilder(50);
            stringBuilder.Append($"Grande reflexion de la part de l'IA (joueur {player.Symbol})");
            Console.WriteLine(stringBuilder.ToString());
            for (int i = 0; i < 3; i++)
            {
                await Task.Delay(500);
                Console.SetCursorPosition(0, Console.CursorTop - 1);
                stringBuilder.Append('.');
                Console.WriteLine(stringBuilder.ToString());
            }
            Console.WriteLine();
            await Task.Delay(1000);
        }
    }
}
