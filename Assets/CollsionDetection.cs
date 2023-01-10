using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollsionDetection : MonoBehaviour
{
    
    public AudioSource ScoreAudio; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerExit(Collider other)
    {
        print("No longer in contact with " + other.transform.name);
        ScoreAudio.Play();
    }
}
