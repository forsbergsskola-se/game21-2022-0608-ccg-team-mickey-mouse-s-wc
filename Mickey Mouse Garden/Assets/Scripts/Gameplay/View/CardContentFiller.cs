using System;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardContentFiller : MonoBehaviour{
	private int id;
	public TextMeshProUGUI nameText, rarityText, levelText, attackText, healthText, speedText;
	public GameObject damageText;
	public Image fighterImage;
	public Transform damageTextTransform;

	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
	}

	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		if (id == obj.ID){
			UpdateHealthUI(obj.Targethealth, obj.DamageDealt);
		}
	}

	private void UpdateHealthUI(float health, float damage){
		if (health <= 0){
			healthText.text = "0";
			return; //TODO: add more UI effects on death in here!
		}
		healthText.text = health.ToString(CultureInfo.InvariantCulture);
		ShowDamage(damage);
		//TODO: add more more UI effects
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
	private void ShowDamage(float damage){
		Instantiate(damageText, damageTextTransform.position, Quaternion.identity );
		damageText.GetComponent<TextMeshProUGUI>().text = damage.ToString(CultureInfo.InvariantCulture);
	}
}
