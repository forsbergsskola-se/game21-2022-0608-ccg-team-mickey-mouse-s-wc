using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNewInventoryItemMessage<T> : IMessage
{
   public short LibraryID { get;}

   internal CreateNewInventoryItemMessage(short libraryID)
   {
      LibraryID = libraryID;
   }
}
