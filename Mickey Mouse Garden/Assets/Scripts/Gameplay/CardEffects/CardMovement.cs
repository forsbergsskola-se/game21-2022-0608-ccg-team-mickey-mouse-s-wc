using UnityEngine;

public class CardMovement : MonoBehaviour{
	[SerializeField] private Transform combatPosition1, combatPosition2;
	private CardCreator cardCreator;
	private Transform[] positions;
	private Vector3 velocity = Vector3.zero;
	private bool fullDeck, returnCard1, returnCard4, returnCard2, returnCard5;

	private void Awake(){
		cardCreator = GetComponent<CardCreator>();
	}

	private void Update(){
		if (cardCreator.cardCount == 7){
			fullDeck = true;
		}
		if (fullDeck && !returnCard1 && !returnCard4) {
			positions = GetComponentsInChildren<Transform>();
			// Card 1 = [7], Card 2 = [15], Card 3 = [23]
			MoveTo(combatPosition1, positions[23]);

			// Card 4 = [31], Card 5 = [39], Card 6 = [47]
			MoveTo(combatPosition2, positions[47]);
		}
		if (Input.GetKeyDown(KeyCode.A)){
			returnCard1 = true;
		}
		if (returnCard1 && !returnCard2){
			MoveTo(positions[3], positions[23]);
			MoveTo(combatPosition1, positions[15]);
		}
		if (Input.GetKeyDown(KeyCode.S)){
			returnCard4 = true;
		}
		if (returnCard4 && !returnCard5){
			MoveTo(positions[6], positions[47]);
			MoveTo(combatPosition2, positions[39]);
		}
		if (Input.GetKeyDown(KeyCode.D)){
			returnCard2 = true;
		}
		if (returnCard2){
			MoveTo(positions[2], positions[15]);
			MoveTo(combatPosition1, positions[7]);
		}
		if (Input.GetKeyDown(KeyCode.F)){
			returnCard5 = true;
		}
		if (returnCard5){
			MoveTo(positions[5], positions[39]);
			MoveTo(combatPosition2, positions[31]);
		}
	}
	private void SmoothMove(Transform combatPosition, Transform card){
		var position = card.position;
		position = Vector3.SmoothDamp(position, combatPosition.position, ref velocity, 0.5f);
		card.position = position;
	}
	private void MoveTo(Transform combatPosition, Transform card){
		card.position = Vector3.MoveTowards(card.position, combatPosition.position, 500f * Time.deltaTime);
	}
}
