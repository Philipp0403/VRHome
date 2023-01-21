using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Lamp;

    public Vector3 initialLampPosition = new Vector3(0f, 0.02f, 0f);
    public Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        // string[] test = { "a", "b" };
        // foreach (string i in test)
        // {
        //     Debug.Log(i);
        // }
        Debug.Log(GameObject.Find("InitialLamp").transform.localPosition);
        //GameObject moin = Instantiate(Lamp, new Vector3(0, 2, 0), Quaternion.identity);
        //moin.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Variables
        // objects [{objectName: "lamp", initalPosition: {x: 2, y: 1, z: 3}}, {objectName: "settings", initalPosition: {x: 3, y: 1, z: 3}} ...]

        // Functions
        // foreach (int i in objects) {

        // }
        if (ObjectHasMoved("InitialLamp")) {
            Debug.Log("start timer");
        } else {
            Debug.Log("dont start timer!");
        }
    }

    bool ObjectHasMoved(string objectName) {
        //Debug.Log("I am trying really hard!");
        GameObject obj = GameObject.Find(objectName);
        Vector3 currentPosition = obj.transform.localPosition;
        //Debug.Log("Hihi this is the position: " + currentPosition);
        switch(objectName) {
            case "InitialLamp":
                initialPosition = initialLampPosition;
                break;
            default:
                Debug.Log("I don't know your tangible ;(");
                break;
        }
        bool tmp = initialPosition == currentPosition;
        Debug.Log("currentPosition:" + currentPosition+"; initialPosition: "+initialLampPosition+"; IsEqual: "+tmp);
        return tmp;
    }
}
