using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    Vector3 originalPosition;

    void Start (){
        originalPosition =gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Wurde die Taste ___ auf dem Touch Controller gedrückt?
        if(OVRInput.GetDown(OVRInput.Button.One))
        
        {
            // Button A wurde gedrückt => Aktion ausführen
            print("Button A wurde gedrückt!");

            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
            gameObject.transform.position = originalPosition;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            
        }
    }
}
