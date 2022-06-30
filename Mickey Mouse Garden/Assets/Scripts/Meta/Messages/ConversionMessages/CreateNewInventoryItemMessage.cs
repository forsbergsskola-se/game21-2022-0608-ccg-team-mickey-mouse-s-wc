using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewInventoryItemMessage<T> : IMessage
{
   public string PathID { get;}

   internal CreateNewInventoryItemMessage(string pathID)
   {
      PathID = pathID;
   }
}
