using UnityEngine;

namespace Meta.Interfaces {
    public interface IInventoryItem: ISaveData{
        public short libraryID{ get; set; }
    }
}