using System;

public class NewPlayer
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public DateTime CreationTime { get; set; }

    public NewPlayer(string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        CreationTime = DateTime.Now;
    }
}