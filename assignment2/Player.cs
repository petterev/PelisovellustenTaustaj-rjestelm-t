using System;
using System.Collections.Generic;

public class PlayerForAnotherGame : IPlayer
{
    public PlayerForAnotherGame(int score)
    {
        Score = score;
    }

    public Guid Id { get; set; }
    public int Score { get; set; }
    public List<Item> Items { get; set; }

    public static bool operator >(PlayerForAnotherGame a, PlayerForAnotherGame b)
    {
        return a.Score > b.Score;
    }
    public static bool operator <(PlayerForAnotherGame a, PlayerForAnotherGame b)
    {
        return a.Score < b.Score;
    }


}

public class Player : IPlayer
{
    public Player(Guid g)
    {
        Id = g;
    }
    public Player(List<Item> list)
    {
        Items = list;
    }
    public Player(int score)
    {
        Score = score;
    }
    public Guid Id { get; set; }
    public int Score { get; set; }
    public List<Item> Items { get; set; }

    /*  public static bool operator >(Player a, Player b)
      {
          return a.Score > b.Score;
      }
      public static bool operator <(Player a, Player b)
      {
          return a.Score < b.Score;
      }
      public static bool operator ==(Player a, Player b)
      {
          return a.Score == b.Score;
      }
      public static bool operator !=(Player a, Player b)
      {
          return a.Score != b.Score;
      }*/

}
public static class PlayerHelper
{
    public static Item GetHighestLevelItem(this Player p)
    {
        Item highest;
        if (p.Items.Count == 0)
        {
            return null;
        }
        else
        {
            highest = p.Items[0];
        }

        for (int i = 1; i < p.Items.Count; i++)
        {
            if (p.Items[i].Level > highest.Level)
            {
                highest = p.Items[i];
            }
        }
        return highest;
    }
}