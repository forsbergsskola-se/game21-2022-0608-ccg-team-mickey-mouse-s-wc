using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicator : MonoBehaviour{

	[SerializeField] private float despawnTime, transformSpeed, scaleSpeed;
	private float timer;

	private void Update(){
		transform.localScale += Vector3.one * (scaleSpeed * Time.deltaTime);
		transform.Translate(Vector3.up * (transformSpeed * Time.deltaTime));
		
		if (timer < despawnTime){
			timer += Time.deltaTime;
		}
		else{
			Destroy(gameObject);
		}
	}
}
