using System.Collections.Generic;
using System.Threading.Tasks;

public class ShopItemList : ISaveData{
    public Dictionary<StringGUID, ShopItemList> ShopItemLists{ get; private set; }
    public StringGUID ID{ get; }

    public void TryLoadData(){
        throw new System.NotImplementedException();
    }

    public void Save(){
        SaveManager.Save(this);
    }

    public ShopItemList(StringGUID id){
        ID = id;
        ShopItemLists = new Dictionary<StringGUID, ShopItemList>();
    }

    public void AddItemToShop(StringGUID id, ShopItemList list){
        ShopItemLists.Add(id, list);
        Save();
    }
}