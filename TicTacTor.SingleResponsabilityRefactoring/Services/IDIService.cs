using Microsoft.Extensions.DependencyInjection;

namespace TicTacTor.SingleResponsabilityRefactoring.Services
{
    internal interface IDIService
    {
        ServiceProvider ServiceProvider { get; }
    }
}
