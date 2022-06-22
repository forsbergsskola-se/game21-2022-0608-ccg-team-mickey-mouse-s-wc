public interface ISaveData{
    public StringGUID ID{ get; }
    public void TryLoadData();
    public void Save();
}
