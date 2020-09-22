
using System;
using System.ComponentModel.DataAnnotations;

public class NewItem
{

    public enum ItemType { SWORD, POTION, SHIELD }

    public Guid Id { get; set; }
    public ItemType Type { get; set; }
    [Range(0, 99)]
    public int Level { get; set; }
    public DateTime CreationDate { get; set; }


}