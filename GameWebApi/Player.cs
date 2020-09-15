using System;
public class Player
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public int Level { get; set; }
    public bool IsBanned { get; set; }
    public DateTime CreationTime { get; set; }

    public Player()
    {

        Name = null;
        Score = 0;
        Level = 0;
        IsBanned = false;


    }
}