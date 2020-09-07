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


        List<T> SortedList = _players.OrderBy(o => o.Score).ToList();


        for (int i = 0; i < 10; i++)
        {
            p[i] = _players[i];
        }

        return p;
    }
}/*
Implement the GetTop10Players method.

Write an another class that implements the IPlayer interface called PlayerForAnotherGame.

Write code that demonstrates that you can instantiate the generic Game class and call 
GetTop10Players with both Player and PlayerForAnotherGame.




*/