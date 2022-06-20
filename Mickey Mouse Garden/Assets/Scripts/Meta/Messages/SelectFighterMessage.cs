using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectFighterMessage : IMessage
{
    public FighterInfo Fighter{ get; set; }
}
