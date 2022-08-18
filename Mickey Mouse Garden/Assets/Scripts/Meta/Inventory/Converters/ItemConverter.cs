using System.Linq;
using Meta.Interfaces;
using UnityEngine;

public abstract class ItemConverter<TItemConfig, TInventoryItem> : MonoBehaviour where TItemConfig : ItemConfig where TInventoryItem : IInventoryItem, new(){
    public ConfigLibrary<TItemConfig> library;
    void OnEnable(){
        Broker.Subscribe<CreateNewInventoryItemMessage<TInventoryItem>>(ConvertItem);
    }

    void OnDisable(){
        Broker.Unsubscribe<CreateNewInventoryItemMessage<TInventoryItem>>(ConvertItem);
    }

    private void ConvertItem(CreateNewInventoryItemMessage<TInventoryItem> createNewInventoryItemMessage)
    {
        Debug.Log($"Converting Item {createNewInventoryItemMessage.PathID}");
        var itemConfig = library.GetItem(createNewInventoryItemMessage.PathID);
        var itemConfigAttributes = itemConfig.GetType().GetFields().ToList();
        var inventoryItem = new TInventoryItem();
        var inventoryItemAttributes = inventoryItem.GetType().GetFields().ToList();
        var inventoryItemProperties = inventoryItem.GetType().GetProperties().ToList();
        
        foreach (var fieldInfo in itemConfigAttributes){
            if (inventoryItemAttributes.Any(field => field.Name == fieldInfo.Name)){
                inventoryItem.GetType().GetField(fieldInfo.Name)?.SetValue(inventoryItem, fieldInfo.GetValue(itemConfig));
            }
            if (inventoryItemProperties.Any(property => property.Name == fieldInfo.Name)){
                inventoryItem.GetType().GetProperty(fieldInfo.Name)?.SetValue(inventoryItem, fieldInfo.GetValue(itemConfig));
            }
        }
        
        SendAddItemToInventoryMessage(inventoryItem);
    }

    private void SendAddItemToInventoryMessage(TInventoryItem song){
        var message = new AddItemToInventoryMessage<TInventoryItem>(song,1);
        Broker.InvokeSubscribers(message.GetType(), message);
    }
}
