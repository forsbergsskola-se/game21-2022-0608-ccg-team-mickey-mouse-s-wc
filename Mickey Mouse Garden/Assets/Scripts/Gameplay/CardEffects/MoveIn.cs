using System;
using UnityEngine;

public class MoveIn : MonoBehaviour{
	[SerializeField] private CardCreator cardCreator;
	[SerializeField] private GameObject cardSlot1, cardSlot2, cardSlot3, cardSlot4, cardSlot5, cardSlot6;

	private void Awake(){
		Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
	}

	private void OnFighterMessageReceived(FighterMessage fighterMessage){
		if (!cardSlot1.GetComponent<CardSlot>().isOccupied) {
			cardCreator.cardSlot = cardSlot1;
			cardSlot1.GetComponent<CardSlot>().isOccupied = true;
		}
		else if (!cardSlot2.GetComponent<CardSlot>().isOccupied) {
			cardCreator.cardSlot = cardSlot2;
			cardSlot2.GetComponent<CardSlot>().isOccupied = true;
		}
		else if (!cardSlot3.GetComponent<CardSlot>().isOccupied) {
			cardCreator.cardSlot = cardSlot3;
			cardSlot3.GetComponent<CardSlot>().isOccupied = true;
		}
	}
}
