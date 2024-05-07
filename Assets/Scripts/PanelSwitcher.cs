using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject[] panels;
    private int currentPanelIndex = 0;

    void Start()
    {
        for (int i = 1; i < panels.Length; i++)
        { 
            panels[i].SetActive(false);
        }
    }

public void SwitchPanel()
    {
        panels[currentPanelIndex].SetActive(false);
        currentPanelIndex = (currentPanelIndex +1) % panels.Length;
        panels[currentPanelIndex].SetActive(true);
    }
}
