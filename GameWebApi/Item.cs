using System;
using System.ComponentModel.DataAnnotations;

public class Item
{
    //public enum ItemType { SWORD, POTION, SHIELD }

    public Guid Id { get; set; }
    //[RegularExpression(SWORD|POTION|SHIELD)]
    [Range(0, 2)]
    public ItemType Type { get; set; }
    [Range(0, 99)]
    public int Level { get; set; }
    [PastDate]
    public DateTime CreationDate { get; set; }



}