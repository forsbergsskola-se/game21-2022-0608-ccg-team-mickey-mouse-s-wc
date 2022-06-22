using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;
using File = UnityEngine.Windows.File;
using Task = System.Threading.Tasks.Task;

public static class SaveManager{
    
    private static string SavePath => @$"{Application.persistentDataPath}/SaveData";
    public static async Task<T> Load<T>(StringGUID id){
        if (!File.Exists(@$"{SavePath}\{id}")){
            Debug.Log(@$"File does not exist : {SavePath}\{id}");
            return default;
        }
        try{
            var readString = await System.IO.File.ReadAllLinesAsync(@$"{SavePath}\{id}", Encoding.ASCII);
            string completeReadString = default;
            foreach (var _string in readString){
                completeReadString += _string;
            }
           
            var dataBaseObject = JsonConvert.DeserializeObject<T>(completeReadString); 
            foreach (var propertyInfo in dataBaseObject.GetType().GetProperties()){
                Debug.Log(propertyInfo.GetValue(dataBaseObject));
            }
            return dataBaseObject;
        }
        catch (Exception e){
            throw e;
        }
    }
   
    public static async void Save(ISaveData saveData){
        Debug.Log("Saving!");
        if (!Directory.Exists(SavePath)){
            Debug.Log($"Directory {SavePath}: does not exist, Creating New Directory.");
            Directory.CreateDirectory(SavePath);
            Save(saveData);
            return;
        }
        try{
            var stringSerialized = JsonConvert.SerializeObject(saveData);
            await System.IO.File.WriteAllTextAsync(@$"{SavePath}\{saveData.ID}", stringSerialized);
            Debug.Log("Saved Successfully!");
        }
        catch (Exception e){
            Debug.Log("Failed to save.");
            throw e;
        }
    }
    
    
    
    /// <summary>
    /// Deletes Local save Directory with all saved files.
    /// </summary>
    /// <exception cref="Exception"></exception>
    public static void DeleteAllSaves(){ 
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
