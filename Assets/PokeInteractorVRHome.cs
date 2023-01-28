using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokeInteractorVRHome : MonoBehaviour
{
    public Tangible currentTangible; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter(Collider other)
	{
        if (other.transform.parent.GetComponent<Tangible>() != null && currentTangible != null)
        {
            currentTangible.CreateConnection(other.transform.parent.GetComponent<Tangible>());
            TangibleLine toDelete = currentTangible.temporaryTangibleLines.Find(s => s.tangible0 == gameObject || s.tangible1 == gameObject);
            currentTangible.temporaryTangibleLines.Remove(toDelete);
            Destroy(toDelete.gameObject);
            currentTangible = null;
        }
	}
}
