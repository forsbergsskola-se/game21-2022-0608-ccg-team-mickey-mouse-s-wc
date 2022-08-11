using System.Collections;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

public abstract class ItemConfig : ScriptableObject
{
    public short libraryID;
    public abstract void SendCreateItemMessage(short libraryID);
    public abstract void SendRemoveItemMessage(short libraryID);
    public abstract void TryAddToLibrary();
}
