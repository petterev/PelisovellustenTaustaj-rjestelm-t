using System;
using System.ComponentModel.DataAnnotations;

public class Item
{


    public Guid Id { get; set; }
    [Range(0, 2)]
    public ItemType Type { get; set; }
    [Range(0, 99)]
    public int Level { get; set; }
    [PastDate]
    public DateTime CreationDate { get; set; }



}