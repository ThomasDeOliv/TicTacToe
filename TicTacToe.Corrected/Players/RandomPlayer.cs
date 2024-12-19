using CSharpFunctionalExtensions;
using TicTacToe.Corrected.Boards;
using TicTacToe.Corrected.Players;

namespace TicTacToe;

public class RandomPlayer : Player
{
    public override char Icon { get; }

    public RandomPlayer(char icon)
    {
        this.Icon = icon;
    }

    public override Result<PlayerMove> GetNextMove()
        => PlayerMove.Random;

}