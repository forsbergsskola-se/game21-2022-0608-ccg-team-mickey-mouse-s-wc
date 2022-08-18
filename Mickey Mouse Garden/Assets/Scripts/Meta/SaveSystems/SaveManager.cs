using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

public static class SaveManager{
    private static string SavePath => @$"{Application.persistentDataPath}/SaveData";
    
    public static async Task<T> Load<T>(StringGUID id){
        if (!File.Exists(@$"{SavePath}\{id}")){
            return default;
        }
        
        try{
            var readString = await File.ReadAllLinesAsync(@$"{SavePath}\{id}", Encoding.ASCII);
            string completeReadString = default;
            
            foreach (var _string in readString){
                completeReadString += _string;
            }
           
            var dataBaseObject = JsonConvert.DeserializeObject<T>(completeReadString); 
            
            return dataBaseObject;
        }
        catch (Exception e){
            throw e;
        }
    }
   
    public static async void Save(ISaveData saveData){
        if (!Directory.Exists(SavePath)){
            Directory.CreateDirectory(SavePath);
            Save(saveData);
            return;
        }
        
        try{
            var stringSerialized = JsonConvert.SerializeObject(saveData);
            await File.WriteAllTextAsync(@$"{SavePath}\{saveData.ID}", stringSerialized);
        }
        catch (Exception e){
            throw e;
        }
    }
    public static void DeleteAllSaves(){ 
        try{
            Directory.Delete(@$"{SavePath}",true);
        }
        catch (Exception e){
            throw e;
        }
    }
}
