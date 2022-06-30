public class FighterStrikeMessage : IMessage {
    public string TargetID{ get; set; }
    public string SelfID { get; set; }
    public float TargetHealth { get; set; }
    public float DamageDealt { get; set; }
    public Alignment StrikerAlignment { get; set; }
    public Rarity StrikerRarity{ get; set; }

}
