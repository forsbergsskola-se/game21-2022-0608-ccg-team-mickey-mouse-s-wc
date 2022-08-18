using UnityEngine;

public class UIChangedMessage : IMessage{
   public int TaskToDo { get; set; }
   public Transform ObjectTransform { get; set; }
   public string ObjectTag { get; set; }
}
