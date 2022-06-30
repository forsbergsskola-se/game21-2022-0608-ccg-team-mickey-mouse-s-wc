using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

public abstract class ItemConfig : ScriptableObject
{
    public string configID;
    public abstract void SendCreateItemMessage(string pathID);
    public abstract void AddToLibrary();
}
