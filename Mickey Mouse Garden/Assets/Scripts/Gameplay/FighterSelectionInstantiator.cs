using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FighterSelectionInstantiator : MonoBehaviour{
	private int id, health, damage, speed, level;
	private string rarity, name, alignment;
	private Sprite fighterSprite;

	public TextMeshProUGUI nameText, rarityText, alignmentText, levelText, damageText, healthText, speedText;
	public Image fighterImage;
	private void Awake() {
		Broker.Subscribe<FighterMessage>(OnFighterMessageReceived);
	}

	private void OnFighterMessageReceived(FighterMessage fighterMessage) {
		id = fighterMessage.ID;
		health = fighterMessage.Health;
		damage = fighterMessage.Damage;
		speed = fighterMessage.Speed;
		level = fighterMessage.Level;
		rarity = fighterMessage.Rarity;
		name = fighterMessage.Name;
		alignment = fighterMessage.Alignment;
		fighterSprite = fighterMessage.Sprite;
		AssignProperties();
	}

	private void AssignProperties() {
		nameText.text = name;
		rarityText.text = rarity;
		alignmentText.text = alignment;
		levelText.text = level.ToString();
		damageText.text = damage.ToString();
		healthText.text = health.ToString();
		speedText.text = speed.ToString();
		fighterImage.sprite = fighterSprite;
	}
}
