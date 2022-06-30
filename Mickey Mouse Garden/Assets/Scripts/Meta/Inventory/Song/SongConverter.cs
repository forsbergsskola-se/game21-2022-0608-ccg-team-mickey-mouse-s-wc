using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongConverter : MonoBehaviour //TODO: Make a generic abstract base class for easier new classes.
{
    public SongConfigLibrary songLibrary;


    void Awake(){
        Broker.Subscribe<CreateNewInventoryItemMessage<Song>>(ConvertSong);
    }

    public void ConvertSong(CreateNewInventoryItemMessage<Song> createNewInventoryItemMessage)
    {
        var songConfig = songLibrary.GetItem(createNewInventoryItemMessage.PathID);
        var song = new Song();
        song.libraryID = songConfig.configID;
        SendAddItemToInventoryMessage(song);
    }
    
    void SendAddItemToInventoryMessage(Song song){
        var message = new AddItemToInventoryMessage<Song>(song,1);
        Broker.InvokeSubscribers(message.GetType(), message);
    }
    
}