using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardContentFiller : MonoBehaviour{
	private int id, level;
	private float health, attack, speed;
	private string rarity, name;
	private Alignment alignment;
	private Sprite fighterSprite;
	
	public int ID { get; set;}
	public float MaxHealth { get; set;}
	public float Attack { get; set;}
	public float Speed { get; set;}
	public int Level  { get; set;}
	public string Rarity  { get; set;}
	public string Name { get; set;}
	public Alignment Alignment { get; set;}
	public Sprite Sprite { get; set;}

	public TextMeshProUGUI nameText, rarityText, alignmentText, levelText, attackText, healthText, speedText;
	public Image fighterImage;

	private FighterInfo fighterInfo = new FighterInfo();

	private void Start(){
		AssignProperties();
		AssignTextFields();
	}

	private void AssignProperties(){
		id = ID;
		health = MaxHealth;
		attack = Attack;
		speed = Speed;
		level = Level;
		rarity = Rarity;
		name = Name;
		alignment = Alignment;
		fighterSprite = Sprite;
	}

	private void AssignTextFields() {
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
