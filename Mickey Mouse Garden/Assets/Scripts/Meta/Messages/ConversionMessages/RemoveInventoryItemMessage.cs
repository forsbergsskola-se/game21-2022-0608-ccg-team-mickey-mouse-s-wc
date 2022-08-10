using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveInventoryItemMessage<T> : IMessage
{
    public string PathID { get;}
    public StringGUID StringGuid{ get; }

    internal RemoveInventoryItemMessage(string pathID, StringGUID stringGuid = null)
    {
        PathID = pathID;

        if (stringGuid != default){
            StringGuid= stringGuid;
        }
    }
}
