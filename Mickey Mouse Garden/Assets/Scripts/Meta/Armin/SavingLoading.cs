using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using OpenCover.Framework.Model;
using UnityEditor.VersionControl;
using UnityEngine;
using FileMode = System.IO.FileMode;

public class SavingLoading : MonoBehaviour{
    
    private string SavePath => $"{Application.persistentDataPath}/SaveData";

    [ContextMenu("Save")]

    void Save(){
        
    }
    
    [ContextMenu("Load")]

    void Load(){
        
    }

    // void SaveFile(object state){
    //     using (var stream = File.Open(SavePath, FileMode.Create)){
    //         var formatter = new BinaryFormatter();
    //         formatter.Serialize(stream, state);
    //     }
    // }
}
