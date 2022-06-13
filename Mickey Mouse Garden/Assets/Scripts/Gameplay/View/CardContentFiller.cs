using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardContentFiller : MonoBehaviour{
	private int id, level;
	private float health, attack, speed;
	private string rarity, name;
	private Alignment alignment;
	private Sprite fighterSprite;

	public TextMeshProUGUI nameText, rarityText, alignmentText, levelText, attackText, healthText, speedText;
	public Image fighterImage;

	private FighterInfo fighterInfo = new FighterInfo();

	private void Awake() {
		id = fighterInfo.ID;
		health = fighterInfo.MaxHealth;
		attack = fighterInfo.Attack;
		speed = fighterInfo.Speed;
		level = fighterInfo.Level;
		rarity = fighterInfo.Rarity;
		name = fighterInfo.Name;
		alignment = fighterInfo.Alignment;
		fighterSprite = fighterInfo.Sprite;
		AssignProperties();
	}

	private void AssignProperties() {
		nameText.text = name;
		rarityText.text = rarity;
		alignmentText.text = alignment.ToString(); //TODO: this is an enum..
		levelText.text = level.ToString();
		attackText.text = attack.ToString();
		healthText.text = health.ToString();
		speedText.text = speed.ToString();
		fighterImage.sprite = fighterSprite;
	}

	
}
