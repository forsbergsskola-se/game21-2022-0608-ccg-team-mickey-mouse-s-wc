using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

public class AddItemToInventoryMessage<T> : IMessage where T: IInventoryItem
{
    public T item;
    public int amount;
    public AddItemToInventoryMessage(T item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
