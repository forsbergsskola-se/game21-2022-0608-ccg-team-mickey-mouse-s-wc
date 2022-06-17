using System;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

public class IDIncrementor : ISaveData{
    private static volatile IDIncrementor instance;
    private static object syncRoot = new Object();
    internal IDIncrementor() {}

    public static IDIncrementor Instance
    {
        get 
        {
            if (instance == null) 
            {
                lock (syncRoot) 
                {
                    if (instance == null){
                        instance = new IDIncrementor();
                    }
                        
                }
                
            }

            return instance;
        }
    } 
    
    public long idIncrementValue{
        get;
        private set;
    }
    public long IDIncrementValue{
        get => idIncrementValue;
        private set => idIncrementValue = value;
    }

    public StringGUID ID{ get; }
    public async Task TryLoadData(){
        var loadedValue = await SaveManager.Load<IDIncrementor>(ID);
        instance.idIncrementValue = loadedValue.IDIncrementValue;
    }

    public void Save(){
        SaveManager.Save(this);
    }

    public async Task IncrementID(){
        await instance.TryLoadData();
        instance.IDIncrementValue++;
        Debug.Log(IDIncrementValue);
        instance.Save();
    }
}
