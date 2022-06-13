using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenCover.Framework.Model;
using UnityEditor.VersionControl;
using UnityEngine;
using File = UnityEngine.Windows.File;
using FileMode = System.IO.FileMode;
using Task = System.Threading.Tasks.Task;

public class SaveManager : MonoBehaviour{
    
    private static string SavePath => @$"{Application.persistentDataPath}/SaveData";


    void Start(){
        Broker.Subscribe<SaveMessage>(StartSaveTask);
       // Broker.Subscribe<LoadMessage>(StartLoadTask);
    }
    // public void StartLoadTask(LoadMessage saveMessage){
    //     Load(saveMessage);
    // }
    // public static async Task Load(LoadMessage loadMessage){
    //     try{
    //         var readString = await System.IO.File.ReadAllLinesAsync(@$"{SavePath}\{loadMessage.saveData.ID}", Encoding.ASCII);
    //         var type = loadMessage.saveData.GetType(); //Type has to be an implemented class to deserialize saved file.
    //         var dataBaseObject = JsonUtility.FromJson<type>(readString.ToString()); 
    //         return  dataBaseObject;
    //     }
    //     catch (Exception e){ //Happens twice?? CW and Throw
    //         throw e;
    //     }
    // }
    public void StartSaveTask(SaveMessage saveMessage){
        Save(saveMessage);
    }
    public async Task Save(SaveMessage saveMessage){
        Debug.Log("Saving!", this);
        if (!Directory.Exists(SavePath)){
            Debug.Log($"Directory {SavePath}: does not exist, Creating New Directory.");
            Directory.CreateDirectory(SavePath);
            Save(saveMessage);
            return;
        }
        try{
            var seializedDataBaseObject = JsonUtility.ToJson(saveMessage.saveData);
            await System.IO.File.WriteAllTextAsync(@$"{SavePath}\{saveMessage.saveData.ID}", seializedDataBaseObject);
            Debug.Log("Saved Successfully!", this);
        }
        catch (Exception e){
            throw e;
        }
    }
    
    [ContextMenu("DeleteAllSaves")]
    public async Task DeleteAllSaves(){
        Debug.Log($"Deleting directory: {SavePath}", this);
        try{
            Directory.Delete(@$"{SavePath}",true);
            Debug.Log("Deleting all files Successfully!", this);
        }
        catch (Exception e){
            throw e;
        }
    }
}
