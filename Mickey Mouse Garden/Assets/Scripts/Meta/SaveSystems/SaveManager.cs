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

public static class SaveManager{
    
    private static readonly string SavePath = @$"{Application.persistentDataPath}/SaveData";


    // void Start(){
    //     Broker.Subscribe<SaveMessage>(StartSaveTask);
    //    // Broker.Subscribe<LoadMessage>(StartLoadTask);
    // }
    // public void StartLoadTask(LoadMessage saveMessage){
    //     Load(saveMessage);
    // }
    public static async Task<T> Load<T>(Guid id){
        try{
            var readString = await System.IO.File.ReadAllLinesAsync(@$"{SavePath}\{id}", Encoding.ASCII);
            var dataBaseObject = JsonUtility.FromJson<T>(readString.ToString()); 
            return dataBaseObject;
        }
        catch (Exception e){
            throw e;
        }
    }
   
    public static async Task Save(ISaveData saveData){
        Debug.Log("Saving!");
        if (!Directory.Exists(SavePath)){
            Debug.Log($"Directory {SavePath}: does not exist, Creating New Directory.");
            Directory.CreateDirectory(SavePath);
            Save(saveData);
            return;
        }
        try{
            var seializedDataBaseObject = JsonUtility.ToJson(saveData);
            await System.IO.File.WriteAllTextAsync(@$"{SavePath}\{saveData.ID}", seializedDataBaseObject);
            Debug.Log("Saved Successfully!");
        }
        catch (Exception e){
            throw e;
        }
    }
    
    
    
    /// <summary>
    /// Deletes Local save Directory with all saved files.
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static async Task DeleteAllSaves(){ 
        Debug.Log($"Deleting directory: {SavePath}");
        try{
            Directory.Delete(@$"{SavePath}",true);
            Debug.Log("Deleting all files Successfully!");
        }
        catch (Exception e){
            throw e;
        }
    }
}
