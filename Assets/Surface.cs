using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surface : MonoBehaviour
{
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionStay(Collision collision)
	{
        collision.gameObject.GetComponent<Tangible>().isCollidingWithSurface = true;
    }
    private void OnCollisionExit(Collision collision)
	{


         collision.gameObject.GetComponent<Tangible>().isCollidingWithSurface = false;

    }

}
 