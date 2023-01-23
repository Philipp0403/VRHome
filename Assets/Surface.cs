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
        if (collision.transform.up.y > .99f)
        {

            point.transform.position = collision.collider.transform.position;
            collision.gameObject.GetComponent<Tangible>().inContactWithSurface = true;
            collision.gameObject.GetComponent<Tangible>().surfaceHeight = collision.transform.position.y;
        }
    }
    private void OnCollisionExit(Collision collision)
	{
        collision.gameObject.GetComponent<Tangible>().inContactWithSurface = false;
    }

}
 