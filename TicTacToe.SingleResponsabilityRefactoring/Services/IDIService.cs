using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.SingleResponsabilityRefactoring.Services
{
    public interface IDIService
    {
        ServiceProvider ServiceProvider { get; }
    }
}
