using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using Meta.Inventory;
using UnityEngine;

public class PurchasingSystem<T> : MonoBehaviour where T : IInventoryItem{
    public Inventory<T> Inventory;
}
