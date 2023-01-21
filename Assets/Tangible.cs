using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tangible : MonoBehaviour
{
    public bool inContactWithSurface = false;
    public float surfaceHeight = 1.1f;
    public Oculus.Interaction.HandGrab.HandGrabInteractor leftHandState;
    public Oculus.Interaction.HandGrab.HandGrabInteractor rightHandState;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        GetComponent<Rigidbody>().useGravity = !inContactWithSurface;
        if (rightHandState.Interactable.gameObject == gameObject)
        {
            transform.position = new Vector3(transform.position.x, surfaceHeight, transform.position.z);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
    }
}
