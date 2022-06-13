using UnityEngine;

public class FighterMessage : IMessage{ //TODO: make sure its the correct types.
   public int ID { get; private set;}
   public int Health { get; private set;}
   public int Damage { get; private set;}
   public int Speed { get; private set;}
   public int Level  { get; private set;}
   public string Rarity  { get; private set;}
   public string Name { get; private set;}
   public string Alignment { get; private set;}
   public Sprite Sprite { get; private set;}
}
