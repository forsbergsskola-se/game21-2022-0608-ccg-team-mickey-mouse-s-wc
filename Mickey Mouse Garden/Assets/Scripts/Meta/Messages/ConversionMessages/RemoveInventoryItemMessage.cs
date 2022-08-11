using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInventoryItemMessage<T> : IMessage
{
    public short LibraryID { get;}
    public StringGUID StringGuid{ get; }

    internal RemoveInventoryItemMessage(short libraryID, StringGUID stringGuid = null)
    {
        LibraryID = libraryID;

        if (stringGuid != default){
            StringGuid= stringGuid;
        }
    }
}
