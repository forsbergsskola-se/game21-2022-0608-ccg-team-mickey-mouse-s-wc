using UnityEngine;

public class CardMovement : MonoBehaviour{
	[SerializeField] private Transform combatPosition1, combatPosition2;
	private CardCreator cardCreator;
	private Transform[] positions;
	private bool player1Dead, enemy1Dead, player2Dead, enemy2Dead, player3Dead, enemy3Dead;

	private void Awake(){
		cardCreator = GetComponent<CardCreator>();
		Broker.Subscribe<FighterFaintMessage>(OnDeathMessageReceived);
	}

	private void Update(){
		if (cardCreator.cardCount == 7 && !player1Dead && !enemy1Dead){
			positions = GetComponentsInChildren<Transform>();
			// Left to Right Player: Card 1 = [7], Card 2 = [15], Card 3 = [23]
			// Right to Left Enemy: Card 4 = [31], Card 5 = [39], Card 6 = [47]
			MoveTo(combatPosition1, positions[23]);
			MoveTo(combatPosition2, positions[47]);
		}
		// FighterDead(Player1) Message
		if (Input.GetKeyDown(KeyCode.A)){
			player1Dead = true;
		}
		if (player1Dead && !player2Dead){
			MoveTo(positions[3], positions[23]);
			MoveTo(combatPosition1, positions[15]);
		}
		
		// FighterDead(Enemy1) Message
		if (Input.GetKeyDown(KeyCode.S)){
			enemy1Dead = true;
		}
		if (enemy1Dead && !enemy2Dead){
			MoveTo(positions[6], positions[47]);
			MoveTo(combatPosition2, positions[39]);
		}
		
		// FighterDead(Player2) Message
		if (Input.GetKeyDown(KeyCode.D)){
			player2Dead = true;
		}
		if (player2Dead && !player3Dead){
			MoveTo(positions[2], positions[15]);
			MoveTo(combatPosition1, positions[7]);
		}
		
		// FighterDead(Enemy2) Message
		if (Input.GetKeyDown(KeyCode.F)){
			enemy2Dead = true;
		}
		if (enemy2Dead && !enemy3Dead) {
			MoveTo(positions[5], positions[39]);
			MoveTo(combatPosition2, positions[31]);
		}

		// Player Defeated Message
		if (Input.GetKeyDown(KeyCode.Z)){
			player3Dead = true;
		}
		if (player3Dead){
			MoveTo(positions[1], positions[7]);
		}
		
		// Enemy Defeated Message
		if (Input.GetKeyDown(KeyCode.X)){
			enemy3Dead = true;
		}
		if (enemy3Dead){
			MoveTo(positions[4], positions[31]);
		}
	}
	private void MoveTo(Transform targetTransform, Transform cardTransform){
		cardTransform.position = Vector3.MoveTowards(cardTransform.position, targetTransform.position, 500f * Time.deltaTime);
	}

	private void OnDeathMessageReceived(FighterFaintMessage obj){
	}

}
