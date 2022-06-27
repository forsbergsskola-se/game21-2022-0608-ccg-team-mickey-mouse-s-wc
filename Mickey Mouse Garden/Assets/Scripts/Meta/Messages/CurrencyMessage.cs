using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
// public abstract class CurrencyMessage : IMessage{ 
//     public ICurrency Currency{ get; set;}
// }
//
// public abstract class CurrenciesMessage : IMessage{
//     public List<ICurrency> Currencies{ get; set; }
// }

public abstract class PlayerCurrencyMessage : IMessage{
    [CanBeNull] public Money money{ get; set; }
    [CanBeNull] public Fertilizer fertilizer{ get; set; }
}

public class DisplayPlayerCurrencyMessage : PlayerCurrencyMessage // Idea is to display player currency with this message.
{
}
public class AddPlayerCurrencyMessage : PlayerCurrencyMessage{}

public class CurrencyRewardMessage : PlayerCurrencyMessage // Idea is to use this to send rewards to the player. Also 
// to display the Reward with this message.
{
}

public class AskForPlayerCurrencyMessage : IMessage{} // Idea is to call this when UI that needs the player Currency
//for the first time or to Update it Visually. Player Will Then invoke DisplayPlayerCurrencyMessage which must be listened to.

