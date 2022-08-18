using UnityEngine;

public class SoundToggleMessage : IMessage{
   public bool Toggle { get; set; }
   public int Option { get; set; }
}
