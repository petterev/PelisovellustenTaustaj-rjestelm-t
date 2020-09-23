
using System;
using System.ComponentModel.DataAnnotations;

public class NewItem
{

    // public enum ItemType { SWORD, POTION, SHIELD }

    public Guid Id { get; set; }
    [EnumDataType(typeof(ItemType))]
    [Range(0, 2)]
    public ItemType Type { get; set; }
    [Range(0, 99)]
    public int Level { get; set; }
    public DateTime CreationDate { get; set; }


}