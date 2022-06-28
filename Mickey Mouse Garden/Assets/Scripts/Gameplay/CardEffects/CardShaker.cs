using System.Collections;
using UnityEngine;

public class CardShaker : MonoBehaviour{
	private CardContentFiller cardContentFiller;
	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
		cardContentFiller = GetComponent<CardContentFiller>();
	}
	private void Update(){
		// if (shake){
		// 	ShakeCard();
		// }
	}
	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		if (cardContentFiller.id == obj.SelfID){
			ShakeCard();
		}
	}
	
	private void ShakeCard(){
		transform.Rotate(0, 0, 7, Space.World);
		transform.Translate(Vector3.left * 20);
		Debug.Log("shaking");
		StartCoroutine(Shaking());
	}
	private IEnumerator Shaking(){
		yield return new WaitForSeconds(0.1f);
		transform.Rotate(0, 0, -7, Space.World);
		transform.Translate(Vector3.left * 20);
	}
}
