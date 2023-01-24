using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    //What Tangible Prefab willbereproduced?
    public GameObject tangibleType;

    //Where does the tangible startout?
    public Vector3 initialObjectPosition;

    // has the tangible alreday been moved?
    private bool objecthasMoved = false;

    //How after what distance will the movement be detected?
    private float movementThreshhold = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(initialObjectPosition);
    }

    // Update is called once per frame
    void Update()
    {
        //get new position of object
        Vector3 newPosition = transform.position;

        if(initialObjectPosition != newPosition){
            //Debug.Log("New Position: "+ newPosition);
            //Debug.Log("Detected: " + movementThreshholdExceeded(initialObjectPosition, newPosition));
            //Was the object moved enough to be detected
            if( movementThreshholdExceeded(initialObjectPosition, newPosition) && !objecthasMoved){
                GameObject newObject = Instantiate(tangibleType, initialObjectPosition, Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                objecthasMoved = true;
            }
        }
    }

    bool movementThreshholdExceeded(Vector3 lastposition, Vector3 newPosition){
        return Mathf.Abs(lastposition.x - newPosition.x) > movementThreshhold
            || Mathf.Abs(lastposition.y - newPosition.y) > movementThreshhold
            || Mathf.Abs(lastposition.z - newPosition.z) > movementThreshhold;
    }
}
