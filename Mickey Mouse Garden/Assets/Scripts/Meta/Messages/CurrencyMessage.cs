using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class CurrencyMessage : IMessage{ 
    public ICurrency Currency{ get; }
}

public abstract class CurrenciesMessage : IMessage{
    public List<ICurrency> Currencies{ get; set; }
}


public class DisplayPlayerCurrencyMessage : CurrenciesMessage // Idea is to display player currency with this message.
{
}
public class AddPlayerCurrencyMessage : CurrenciesMessage{}

public class CurrencyRewardMessage : CurrenciesMessage // Idea is to use this to send rewards to the player. Also 
// to display the Reward with this message.
{
}

public class AskForPlayerCurrencyMessage : IMessage{} // Idea is to call this when UI that needs the player Currency
//for the first time or to Update it Visually. Player Will Then invoke DisplayPlayerCurrencyMessage which must be listened to.

