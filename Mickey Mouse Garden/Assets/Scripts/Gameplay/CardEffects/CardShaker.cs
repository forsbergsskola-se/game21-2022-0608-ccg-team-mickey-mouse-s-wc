using System.Collections;
using UnityEngine;

public class CardShaker : MonoBehaviour{
	private CardContentFiller cardContentFiller;
	private bool shake;
	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
		cardContentFiller = GetComponent<CardContentFiller>();
	}
	private void Update(){
		if (shake){
			ShakeCard();
		}
	}
	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		if (cardContentFiller.id == obj.SelfID){
			shake = true;
		}
	}
	
	private void ShakeCard(){
		transform.Translate(Vector3.left * 2);
		Debug.Log("shaking");
		StartCoroutine(Shaking());
	}
	private IEnumerator Shaking(){
		yield return new WaitForSeconds(0.2f);
		transform.Translate(Vector3.right * 2);
		shake = false;
	}
}
