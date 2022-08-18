using UnityEngine;

public abstract class ItemConfig : ScriptableObject {
    public string libraryID;
    public abstract void SendCreateItemMessage(string pathID);
    public abstract void SendRemoveItemMessage(string pathID);
}
