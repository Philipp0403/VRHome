using System.Collections;
using System.Collections.Generic;
using UnityEditor.DeviceSimulation;
using UnityEngine;

public class VisibleButton : MonoBehaviour
{
    public GameObject Sichtbar;
    public GameObject SichtbarOnOff;
    public int start = 0;

    public void machSichtbar()
    {
        if (start == 0) {
            Sichtbar.SetActive(true);
            start++;
        }
        else
        {
            Sichtbar.SetActive(false);
            start--;
        }
    }

    public void onOff()
    {
        if (Sichtbar.activeSelf)
        {
            Sichtbar.SetActive(false);
            SichtbarOnOff.SetActive(true);
        }
        else
        {
            Sichtbar.SetActive(true);
            SichtbarOnOff.SetActive(false);
        }
    }
}
