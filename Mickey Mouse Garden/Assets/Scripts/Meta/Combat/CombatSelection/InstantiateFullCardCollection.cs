using Meta.Cards;
using UnityEngine;

public class InstantiateFullCardCollection : MonoBehaviour{ //TODO: combine with SpawnCardButtons if time and energy.
    [SerializeField] private GameObject cardButtonPrefab;
    private CardConfig[] playerCardTeam;
    private void Awake(){
        playerCardTeam = FindObjectOfType<CardInventoryMockup>().playerCards;
        for (int i = 0; i < playerCardTeam.Length; i++){
            var instance = Instantiate(cardButtonPrefab, gameObject.transform);
            instance.GetComponentInChildren<CardView>().Configure(playerCardTeam[i]);
        }
    }
}
