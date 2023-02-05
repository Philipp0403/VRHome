using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleteTangible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision){
        Debug.Log("DESTROY! " + collision.gameObject.name);
        Destroy(collision.gameObject);
    }
}
