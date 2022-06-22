using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class CardTranslationCommand : ICommand{
	private Transform cardDestination;
	private GameObject card; 

	public CardTranslationCommand(Transform destination, GameObject card){
		this.card = card;
		cardDestination = destination;
	}
	public void Execute() {
		Move();
	}

	public Task ExecuteAsync(){
		Move();
		return Task.CompletedTask;
	}

	public void Undo(){
		throw new System.NotImplementedException();
	}

	private void Move() {
		card.transform.position = cardDestination.position;
	}
}
