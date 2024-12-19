﻿using CSharpFunctionalExtensions;
using TicTacToe.Corrected.Boards;

namespace TicTacToe.Corrected.Players;

public interface IPlayer
{
    public Result<PlayerMove> GetNextMove();
    public char Icon { get; }
}


public abstract class Player : IPlayer
{
    public abstract char Icon { get; }

    public abstract Result<PlayerMove> GetNextMove();

    public override string ToString()
        => $"{this.Icon}";
}
