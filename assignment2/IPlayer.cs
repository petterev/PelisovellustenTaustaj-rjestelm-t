using System;

public interface IPlayer
{
    int Score { get; set; }

    public static bool operator >(IPlayer a, IPlayer b)
    {
        return a.Score > b.Score;
    }
    public static bool operator <(IPlayer a, IPlayer b)
    {
        return a.Score < b.Score;
    }
}