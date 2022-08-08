using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatLevelMessage : IMessage{
  public int level;
  
  public CombatLevelMessage(int currentMissionLevel) {
    this.level = currentMissionLevel;
  }
}
