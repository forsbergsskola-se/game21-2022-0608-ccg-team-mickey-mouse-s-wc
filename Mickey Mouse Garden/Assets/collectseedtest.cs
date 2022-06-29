using Meta.Inventory.NewSeedInventory;
using UnityEngine;

public class collectseedtest : MonoBehaviour
{
    private void OnMouseDown() {
        Seed seed = new Seed();
        seed.rarity = Rarity.Common;
        var msg = new AddItemToInventoryMessage<Seed>(seed, 1);
        Broker.InvokeSubscribers(typeof(AddItemToInventoryMessage<Seed>), msg);
        Destroy(gameObject);
    }
}
