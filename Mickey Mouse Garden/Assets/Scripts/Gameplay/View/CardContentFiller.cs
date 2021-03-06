using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardContentFiller : MonoBehaviour{
	[HideInInspector] public string id;
	private bool faintDelay;
	public TextMeshProUGUI nameText, rarityText, levelText, attackText, healthText, speedText;
	public GameObject damageText, faintedImage;
	public Image fighterImage;
	public Transform damageTextTransform, parent;

	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
	}

	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		if (id == obj.TargetID){
			UpdateHealthUI(obj.TargetHealth, obj.DamageDealt);
		}
	}

	private void UpdateHealthUI(float health, float damage){
		if (health <= 0){
			healthText.text = "Health: 0";
			MakeCardFaint();
		}
		healthText.text = $"Health: {health.ToString(CultureInfo.InvariantCulture)}";
		ShowDamage(damage);
	}

	public void AssignTextFields(FighterInfo fighter){ //TODO: add discriptive text to the values eg. health: 5
		id = fighter.ID;
		nameText.text = fighter.Name;
		rarityText.text = fighter.Rarity.ToString();
		levelText.text = $"Level: {fighter.Level.ToString()}";
		attackText.text = $"Damage: {fighter.Attack.ToString(CultureInfo.InvariantCulture)}";
		healthText.text = $"Health: {fighter.MaxHealth.ToString(CultureInfo.InvariantCulture)}";
		speedText.text = $"Speed: {fighter.Speed.ToString(CultureInfo.InvariantCulture)}";
		fighterImage.sprite = fighter.Sprite;
	}
	private void ShowDamage(float damage){
		Instantiate(damageText, damageTextTransform.position, Quaternion.identity, parent);
		damageText.GetComponent<TextMeshProUGUI>().text = damage.ToString(CultureInfo.InvariantCulture);
	}
	private void MakeCardFaint(){
		StartCoroutine(Fainting());
	}
	private IEnumerator Fainting(){
		yield return new WaitForSeconds(0.75f);
		faintedImage.SetActive(true);
	}
}
