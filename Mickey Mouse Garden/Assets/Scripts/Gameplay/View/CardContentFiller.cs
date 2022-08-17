using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardContentFiller : MonoBehaviour{
	[HideInInspector] public StringGUID id;
	private bool faintDelay;
	public TextMeshProUGUI nameText, rarityText, levelText, attackText, healthText, speedText;
	public GameObject damageText, faintedImage;
	public Image fighterImage;
	public Transform damageTextTransform, parent;
	public SpriteLibrarySO spriteLibrary;

	private void Awake(){
		Broker.Subscribe<FighterStrikeMessage>(OnStrikeMessageReceived);
	}

	private void OnStrikeMessageReceived(FighterStrikeMessage obj){
		if (id == obj.TargetID){
			UpdateHealthUI(obj.TargetHealth, obj.DamageDealt);
		}
	}

	private void UpdateHealthUI(float health, float damage){
		ShowDamage(damage);
		if (health <= 0){
			healthText.text = "Health: 0";
			MakeCardFaint();
		}
		healthText.text = $"Health: {health.ToString(CultureInfo.InvariantCulture)}";
	}

	public void AssignTextFields(FighterInfo fighter){
		id = fighter.ID;
		nameText.text = fighter.Name;
		rarityText.text = fighter.Rarity.ToString();
		levelText.text = $"Level: {fighter.Level.ToString()}";
		attackText.text = $"Damage: {fighter.Attack.ToString(CultureInfo.InvariantCulture)}";
		healthText.text = $"Health: {fighter.MaxHealth.ToString(CultureInfo.InvariantCulture)}";
		speedText.text = $"Speed: {fighter.Speed.ToString(CultureInfo.InvariantCulture)}";
		fighterImage.sprite =spriteLibrary.sprites[fighter.SpriteIndex];
	}
	private void ShowDamage(float damage){
		var damageTextInstance = Instantiate(damageText, damageTextTransform.position, Quaternion.identity, parent);
		damageTextInstance.GetComponent<TextMeshProUGUI>().text = damage.ToString(CultureInfo.InvariantCulture);
	}
	private void MakeCardFaint(){
		StartCoroutine(Fainting());
	}
	private IEnumerator Fainting(){
		yield return new WaitForSeconds(0.75f);
		faintedImage.SetActive(true);
	}
}
