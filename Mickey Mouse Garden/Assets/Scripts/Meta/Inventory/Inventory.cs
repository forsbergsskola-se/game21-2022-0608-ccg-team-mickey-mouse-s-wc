using System;
using System.Collections.Generic;
using Meta.Interfaces;
using UnityEngine;

namespace Meta.Inventory {
    public abstract class Inventory : MonoBehaviour {
        public abstract List<IInventoryItem> items { get; set; }

        //TODO: Subscribe to the right broker messages
            //Required method but different implementations

        public void Add<T>(T item) where T : IInventoryItem {
            items.Add(item);
        }

        public void Remove<T>(T item) where T : IInventoryItem {
            items.Remove(item);
        }
    }
}