public class FighterStrikeMessage : IMessage {
    public StringGUID TargetID{ get; set; }
    public StringGUID SelfID { get; set; }
    public float TargetHealth { get; set; }
    public float DamageDealt { get; set; }
    public Alignment StrikerAlignment { get; set; }
    public Rarity StrikerRarity{ get; set; }

}
