using UnityEngine;

namespace Meta.Interfaces {
    public interface IInventoryItem: ISaveData{
        public string libraryID{ get; set; }
    }
}