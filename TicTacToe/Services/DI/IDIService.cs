using Microsoft.Extensions.DependencyInjection;

namespace TicTacToe.Services.DI
{
    public interface IDIService
    {
        bool Init(string? input);
        ServiceProvider ServiceProvider { get; }
    }
}
