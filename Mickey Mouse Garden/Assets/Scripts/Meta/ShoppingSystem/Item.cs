public class Item{
    public string ItemName{ get; set; }
    public int Price{ get; }

    public Item(int price, string name){
        this.Price = price;
        this.ItemName = name;
    }
    
}