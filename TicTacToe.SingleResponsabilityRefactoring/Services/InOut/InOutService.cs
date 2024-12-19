using System;

namespace TicTacToe.SingleResponsabilityRefactoring.Services.InOut
{
    public class InOutService : IInOutService
    {
        protected InOutService()
        {

        }

        public string? GetHumanUserInput()
        {
            return Console.ReadLine();
        }

        public static InOutService Create()
        {
            return new InOutService();
        }
    }
}
