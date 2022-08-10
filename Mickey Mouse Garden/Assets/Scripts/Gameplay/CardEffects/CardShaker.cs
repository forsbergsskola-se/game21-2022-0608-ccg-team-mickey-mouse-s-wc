using System;
using System.Collections;
using UnityEngine;

public class CardShaker : MonoBehaviour{
	private CardContentFiller cardContentFiller;
	private int directionModifier = 1;
	private bool player;
	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
		cardContentFiller = GetComponent<CardContentFiller>();
		if (transform.position.x < 200){
			directionModifier = -1;
		}
	}

	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		if (cardContentFiller.id == obj.SelfID){
			ShakeCard();
		}
	}

	private void OnDisable(){
		Broker.Unsubscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
	}

	private void ShakeCard(){
		transform.Rotate(0, 0, 7 * directionModifier, Space.World);
		transform.Translate(Vector3.left * (80 * directionModifier));
		StartCoroutine(Shaking());
	}
	private IEnumerator Shaking(){
		yield return new WaitForSeconds(0.1f);
		transform.Rotate(0, 0, -7 * directionModifier, Space.World);
		transform.Translate(Vector3.right * (80 * directionModifier));
	}
}
