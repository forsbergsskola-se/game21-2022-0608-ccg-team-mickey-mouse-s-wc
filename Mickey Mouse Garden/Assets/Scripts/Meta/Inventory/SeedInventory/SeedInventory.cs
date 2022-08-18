namespace Meta.Inventory.NewSeedInventory {
    [System.Serializable]
    public class SeedInventory : Inventory<Seed> {
        public override InventoryList<Seed> InventoryList { get; set; } = new(new StringGUID().CreateStringGuid(20202));
        public InventoryList<Seed> PlantedSeeds { get; set; } = new(new StringGUID().CreateStringGuid(30303));

        public static SeedInventory Instance { get; private set; }

        public override void Awake() {
            base.Awake();
            if (Instance != null) {
            } else {
                Instance = this;
            }
            
            Broker.Subscribe<AskForUpdateSeedUi>(SendUpdateSeedUiMessage);
        }

        public override void Start() {
            base.Start();
            PlantedSeeds.TryLoadData();
        }
        

        public override void OnDisable(){
            Broker.Unsubscribe<AskForUpdateSeedUi>(SendUpdateSeedUiMessage);
        }

        public override void OnRemoveInventoryItemMessageReceived(RemoveInventoryItemMessage<Seed> message){
            base.OnRemoveInventoryItemMessageReceived(message);
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
        }

        private void SendUpdateSeedUiMessage(AskForUpdateSeedUi message){
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
        }
        
        public override void CollectOperations(Seed addedItem){
            base.CollectOperations(addedItem);
            Broker.InvokeSubscribers(typeof(UpdateSeedUi), new UpdateSeedUi(InventoryList.Items));
        }
    }
}