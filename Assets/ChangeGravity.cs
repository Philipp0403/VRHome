using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeGravity : MonoBehaviour
{
    public ConstantForce gravity;
    public float g = -0.17f;
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, g, 0);


        //gameObject.GetComponent<Rigidbody>().useGravity = false;
        //gravity = gameObject.AddComponent<ConstantForce>();
        //gravity.force = new Vector3(0.0f, -1.64f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
