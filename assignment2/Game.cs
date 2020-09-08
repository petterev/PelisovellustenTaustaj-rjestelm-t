using System;
using System.Collections.Generic;
using System.Linq;

public class Game<T> where T : IPlayer
{
    private List<T> _players;

    public Game(List<T> players)
    {
        _players = players;
    }

    public T[] GetTop10Players()
    {
        T[] p = new T[10];


        List<T> sortedPlayers = _players.OrderBy(o => o.Score).ToList();
        sortedPlayers.Reverse();


        for (int i = 0; i < 10; i++)
        {
            p[i] = sortedPlayers[i];
        }

        foreach (T t in p)
        {
            Console.WriteLine(t.Score);

        }
        return p;
    }
}
