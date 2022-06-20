using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;
using UnityEngine.UDP;

public class PurchasingSystem : MonoBehaviour, ICurrency{
    public Inventory Inventory;
    public string Name{ get; }
    public int Amount{ get; }
    public string SpriteName{ get; }
    public Sprite Sprite{ get; }
    public void AddAmount(int value){
        throw new System.NotImplementedException();
    }
}
