public class FighterStrikeMessage : IMessage {
    public int TargetID{ get; set; }
    
    public int SelfID{ get; set; }

    public float Targethealth { get; set; }
    public float DamageDealt { get; set; }

}
