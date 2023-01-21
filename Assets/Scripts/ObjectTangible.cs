using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTangible : MonoBehaviour
{
    SettingTangible sT;

    public bool activationTangible = false;
    public bool heaterTangible = false;
    public bool lampTangible = false;
    public bool shuttersTangible = false;

    //Verbindung von Objecttangible mit SettingTangible
    public void ConnectTangibles()
    {
        if (activationTangible)
        {
            sT.onOffBool = true;
            sT.timeBool = true;
        }

        if (heaterTangible)
        {
            sT.temperatureBool = true;
        }

        if (lampTangible)
        {
            sT.brightnessBool = true;
            sT.colorBool = true;
        }

        if (shuttersTangible)
        {
            sT.shuttersClosedBool = true;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
