using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingTangible : MonoBehaviour
{
    // Wurde die Option ausgewaehlt
    public bool brightnessBool = false;
    public bool colorBool = false;
    public bool onOffBool = false;
    public bool shuttersClosedBool = false;
    public bool temperatureBool = false;
    public bool timeBool = false;

    // Helligkeit mit Gleitkommazahl
    public float brightness;
    // RGB mit HexCode
    public String color;
    // Einstellen ob an oder aus
    public bool onOff;
    // Wie weit sind die Rolladen geschlossen, 0 = Offen, 100 = Geschlossen
    public float shuttersClosed;
    // Temperatur mit Gleitkommazahl
    public float temperature;
    // Zeit mit Gleitkommazahl
    public float time;

    // Active State Tracker fuer rechts, Auswahl der gewuenschten Option
    public Oculus.Interaction.HandGrab.HandGrabInteractor rightHand;
    // Active State Tracker fuer links, Auswahl der gewuenschten Option
    public Oculus.Interaction.HandGrab.HandGrabInteractor leftHand;


    // Methode zur Bestimmung der Auswahl der Option die eingestellt werden soll
    public void SelectOptionToAdjust()
    {
        // Noch hinzufuegen vor den if-Abfragen fuer Abfrage nach Kontakt von Hand mit canvas: rightHand.GameObject... || leftHand.GameObject...
        if (rightHand.WhenStateChanged += )
            leftHand.Inter
        {
            // Hier einstellen von true indem gedruecktes und erkannte Einstellung von oben uebertragen mit Canvas."jeweilige Einstellung" = true
            // Auswahl von Helligkeit
            if (!onOffBool && !shuttersClosedBool && !temperatureBool && !timeBool)
            {
                brightnessBool = true;
                SelectValueOfBrightness();
            }

            // Auswahl von Farbe
            else if (!onOffBool && !shuttersClosedBool && !temperatureBool && !timeBool)
            {
                colorBool = true;
                SelectValueOfColor();
            }

            // Auswahl von Aktivierung
            else if (!brightnessBool && !colorBool && !shuttersClosedBool && !temperatureBool)
            {
                onOffBool = true;
                SelectValueOfOnOff();
            }

            // Auswahl von Rolladen
            else if (!brightnessBool && !colorBool && !onOffBool && !temperatureBool && !timeBool)
            {
                shuttersClosedBool = true;
                SelectValueOfShutters();
            }

            // Auswahl von Temperatur
            else if (!brightnessBool && !colorBool && !onOffBool && !shuttersClosedBool && !timeBool)
            {
                temperatureBool = true;
                SelectValueOfTemperature();
            }

            // Auswahl von Zeit
            else if (!brightnessBool && !colorBool && !shuttersClosedBool && !temperatureBool)
            {
                timeBool = true;
                SelectValueOfTime();
            }
        }
    }

    // Helligkeitseinstellung vornehmen
    public void SelectValueOfBrightness()
    {

    }

    // Farbeinstellung vornehmen
    public void SelectValueOfColor()
    {

    }

    // Aktivierung von Tangible einstellen
    public void SelectValueOfOnOff()
    {

    }

    // Geschlossenheit der Rolladden einstellen
    public void SelectValueOfShutters()
    {

    }

    // Temperatureinstellung vornehmen
    public void SelectValueOfTemperature()
    {

    }

    // Zeiteinstellung vornehmen
    public void SelectValueOfTime()
    {

    }

}
