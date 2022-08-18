using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFighterTeamMessage : IMessage
{
    public Stack<FighterInfo> FighterTeam{ get; set; }
    public bool IsPlayerTeam{ get; set; }
}
