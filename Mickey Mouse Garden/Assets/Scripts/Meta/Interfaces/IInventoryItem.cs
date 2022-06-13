using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItem {
    [SerializeField] Sprite inventorySprite { get; set; }
    public void OnHarvest();
}
