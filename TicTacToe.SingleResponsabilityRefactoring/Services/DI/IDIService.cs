using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.SingleResponsabilityRefactoring.Services.DI
{
    public interface IDIService
    {
        ServiceProvider ServiceProvider { get; }
    }
}
