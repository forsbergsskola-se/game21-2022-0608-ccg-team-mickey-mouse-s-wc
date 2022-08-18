using System;
using System.Collections;
using UnityEngine;

public class CardMovement : MonoBehaviour {
	[SerializeField] private Transform combatPosition1, combatPosition2;
	private CardCreator cardCreator;
	private Transform[] positions;
	private bool[] deadPlayer;
	private bool[] deadEnemy;
	private int playerNumber, enemyNumber;
	private bool positionsGotten;
	private void Awake(){
		cardCreator = GetComponent<CardCreator>();
		Broker.Subscribe<FighterFaintMessage>(OnFaintedMessageReceived);
		deadPlayer = new[] {true, false, false, false};
		deadEnemy = new[] {true, false, false, false};
	}

	private void Update(){
		if (cardCreator.cardCount == 7 && deadPlayer[0] && deadEnemy[0]){
			GetPositions();
			// Left to Right Player: Card 1 = [7], Card 2 = [15], Card 3 = [23]
			// Right to Left Enemy: Card 4 = [31], Card 5 = [39], Card 6 = [47]
			MoveTo(combatPosition1, positions[23]);
			MoveTo(combatPosition2, positions[47]);
		}

		// Player Fighter 1 Dead
		if (deadPlayer[1]){
			MoveTo(positions[3], positions[23]);
			MoveTo(combatPosition1, positions[15]);
		}
		
		// Enemy Fighter 1 Dead
		if (deadEnemy[1]){
			MoveTo(positions[6], positions[47]);
			MoveTo(combatPosition2, positions[39]);
		}
		
		// Player Fighter 2 Dead
		if (deadPlayer[2]){
			MoveTo(positions[2], positions[15]);
			MoveTo(combatPosition1, positions[7]);
		}
		
		// Enemy Fighter 2 Dead
		if (deadEnemy[2]) {
			MoveTo(positions[5], positions[39]);
			MoveTo(combatPosition2, positions[31]);
		}
		
		// Player Fighter 3 Dead
		if (deadPlayer[3]){
			MoveTo(positions[1], positions[7]);
		}
		
		// Enemy Fighter 3 Dead
		if (deadEnemy[3]){
			MoveTo(positions[4], positions[31]);
		}
	}
	
	private void GetPositions(){
		if (positionsGotten) return;
		positions = GetComponentsInChildren<Transform>();
		positionsGotten = true;
	}
	
	private void MoveTo(Transform targetTransform, Transform cardTransform){
		cardTransform.position = Vector3.MoveTowards(cardTransform.position, targetTransform.position, 1000f * Time.deltaTime);
	}

	private void OnFaintedMessageReceived(FighterFaintMessage obj){
		StartCoroutine(Fainting(obj));
	}
	
	private IEnumerator Fainting(FighterFaintMessage obj){
		yield return new WaitForSeconds(0.75f);
		if (obj.wasPlayerFighter){
			// Stops current movement.
			deadPlayer[playerNumber] = false;
			// Goes to next bool.
			playerNumber++;
			// Starts next movement.
			deadPlayer[playerNumber] = true;
		} else {
			deadEnemy[enemyNumber] = false;
			enemyNumber++;
			deadEnemy[enemyNumber] = true;
		}	
	}

	private void OnDisable(){
		Broker.Unsubscribe<FighterFaintMessage>(OnFaintedMessageReceived);

	}
}
