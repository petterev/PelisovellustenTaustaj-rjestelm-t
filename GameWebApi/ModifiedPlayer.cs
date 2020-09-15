public class ModifiedPlayer
{
    public int Score { get; set; }
    public int Level { get; set; }
    public bool IsBanned { get; set; }

    public ModifiedPlayer(int score, int level, bool isBan)
    {
        Score = score;
        Level = level;
        IsBanned = isBan;
    }
}