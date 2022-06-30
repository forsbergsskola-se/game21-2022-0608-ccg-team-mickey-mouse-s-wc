using UnityEngine;

public class OpenSelectionPanel : MonoBehaviour {
    public GameObject selectionPanel;
    public int position;

    public void OpenPanel() {
        selectionPanel.SetActive(true);
        var config = GetComponentInChildren<ASelectedCard>().FindCardData();
        var msg = new CardSelectionMessage{CardConfig = config , Position = position};
        Broker.InvokeSubscribers(typeof(CardSelectionMessage), msg);
    }
}
