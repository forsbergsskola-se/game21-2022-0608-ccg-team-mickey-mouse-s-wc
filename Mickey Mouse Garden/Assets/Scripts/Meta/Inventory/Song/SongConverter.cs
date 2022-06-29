using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongConverter : MonoBehaviour
{
    public SongConfigLibrary songLibrary;
    public void ConvertSong(string songName)
    {
        var songConfig = songLibrary.GetSong(songName);
        var song = new Song();
        song.libraryID = songConfig.configID;
        
        var message = new AddItemToInventoryMessage<Song>(song,1);
        Broker.InvokeSubscribers(message.GetType(), message);
    }
    
}
