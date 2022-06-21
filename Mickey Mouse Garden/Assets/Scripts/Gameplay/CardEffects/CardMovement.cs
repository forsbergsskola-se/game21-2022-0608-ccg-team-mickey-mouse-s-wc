using UnityEngine;

public class CardMovement : MonoBehaviour{
	[SerializeField] private Transform combatPosition1, combatPosition2;
	private CardCreator cardCreator;
	private Transform[] cards;
	private Vector3 velocity = Vector3.zero;

	private void Awake(){
		cardCreator = GetComponent<CardCreator>();
	}

	private void Update(){
		if (cardCreator.cardCount == 7){
			cards = GetComponentsInChildren<Transform>();
			// Card 1 = [23], Card 2 = [15], Card 3 = [7]
			SmoothMove(combatPosition1, cards[23]);

			// Card 4 = [47], Card 5 = [39], Card 6 = [31]
			SmoothMove(combatPosition2, cards[47]);
		}
	}
	private void SmoothMove(Transform combatPosition, Transform card){
		var position = card.position;
		position = Vector3.SmoothDamp(position, combatPosition.position, ref velocity, 0.5f);
		card.position = position;
	}

}
