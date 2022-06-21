using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Wallet: ISaveData{
    public List<ICurrency> currencies;
    public StringGUID ID{ get; }
    public Task TryLoadData(){
        throw new System.NotImplementedException();
    }

    public void Save(){
        throw new System.NotImplementedException();
    }
}
