using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSelectionPanel : MonoBehaviour {
    public GameObject selectionPanel;

    public void OpenPanel() {
        selectionPanel.SetActive(true);
    }
}
