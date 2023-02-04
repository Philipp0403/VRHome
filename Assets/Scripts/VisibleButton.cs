using System.Collections;
using System.Collections.Generic;
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
        Debug.Log("Bin in der Methode drin!");
        if (Sichtbar.activeSelf)
        {
            Sichtbar.SetActive(false);
            SichtbarOnOff.SetActive(true);
            Debug.Log("Was ist Off: " + Sichtbar.activeSelf);
        }
        else if (SichtbarOnOff.activeSelf)
        {
            Sichtbar.SetActive(true);
            SichtbarOnOff.SetActive(false);
            Debug.Log("Was ist On: " + SichtbarOnOff.activeSelf);
        }
    }
}
