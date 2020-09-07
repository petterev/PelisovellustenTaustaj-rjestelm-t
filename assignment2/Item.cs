using System;


public class Item
{
    public Item(int l)
    {
        Id = Guid.NewGuid();
        Level = l;
    }


    public Guid Id { get; set; }
    public int Level { get; set; }
}