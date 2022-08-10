using Meta.Cards;
using Meta.Inventory.FighterInventory;
using UnityEngine;

public class InspectCardSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cardButtonPrefab;
    private Card inspectedCard;
    private void Awake(){
        //TODO: Find the actual inspected card??
        var instance = Instantiate(cardButtonPrefab, gameObject.transform);
        instance.GetComponentInChildren<CardView>().Configure(inspectedCard);
    }
}
