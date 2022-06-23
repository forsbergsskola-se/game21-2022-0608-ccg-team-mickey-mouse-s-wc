using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardContentFiller : MonoBehaviour{
	private int id;
	
	public TextMeshProUGUI nameText, rarityText, levelText, attackText, healthText, speedText;
	public Image fighterImage;

	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
	}

	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		if (id == obj.ID){
			UpdateHealthUI(obj.Targethealth);
		}
	}

	private void UpdateHealthUI(float health){
		if (health <= 0){
			healthText.text = "0";
			return; //TODO: add more UI effects on death in here!
		}
		healthText.text = health.ToString();
	}

	public void AssignTextFields(FighterInfo fighter){
		id = fighter.ID;
		nameText.text = fighter.Name;
		rarityText.text = fighter.Rarity.ToString();
		levelText.text = fighter.Level.ToString();
		attackText.text = fighter.Attack.ToString();
		healthText.text = fighter.MaxHealth.ToString();
		speedText.text = fighter.Speed.ToString();
		fighterImage.sprite = fighter.Sprite;
	}

	
}
