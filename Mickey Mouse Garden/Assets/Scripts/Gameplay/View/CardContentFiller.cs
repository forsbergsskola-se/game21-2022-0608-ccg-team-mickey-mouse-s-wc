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
		if (id == obj.FighterInfo.ID){
			UpdateHealthUI(obj.FighterInfo);
		}
	}

	private void UpdateHealthUI(FighterInfo fighter){
		if (fighter.MaxHealth <= 0){
			healthText.text = "0";
			return; //TODO: add more UI effects on death in here!
		}
		healthText.text = fighter.MaxHealth.ToString();
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
