using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseColor : MonoBehaviour
{

    public GameObject Red;
    public GameObject Yellow;
    public GameObject Green;
    public GameObject Blue;
    public GameObject Purple;
    public GameObject Pink;

    public GameObject RedB;
    public GameObject YellowB;
    public GameObject GreenB;
    public GameObject BlueB;
    public GameObject PurpleB;
    public GameObject PinkB;

    public void resetBackgrounds()
    {
        RedB.SetActive(false);
        YellowB.SetActive(false);
        GreenB.SetActive(false);
        BlueB.SetActive(false);
        PurpleB.SetActive(false);
        PinkB.SetActive(false);
    }
    public void itsRed()
    {
        resetBackgrounds();
        RedB.SetActive(true);
    }
    public void itsYellow()
    {
        resetBackgrounds();
        YellowB.SetActive(true);
    }
    public void itsGreen()
    {
        resetBackgrounds();
        GreenB.SetActive(true);
    }
    public void itsBlue()
    {
        resetBackgrounds();
        BlueB.SetActive(true);
    }
    public void itsPurple()
    {
        resetBackgrounds();
        PurpleB.SetActive(true);
    }
    public void itsPink()
    {
        resetBackgrounds();
        PinkB.SetActive(true);
    }
}
