using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TangibleLine : MonoBehaviour
{
    public GameObject tangible0;
    public GameObject tangible1;
    LineRenderer line;
    Oculus.Interaction.SelectorUnityEventWrapper scissorHandSelector;
    bool isScissorsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        scissorHandSelector = GameObject.Find("ScissorsPose").GetComponent<Oculus.Interaction.SelectorUnityEventWrapper>();
        line = GetComponent<LineRenderer>();
        scissorHandSelector.WhenSelected.AddListener(() => {
            isScissorsActive = true;
        });
        scissorHandSelector.WhenUnselected.AddListener(() => {
            isScissorsActive = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if(isScissorsActive)
            {


                RaycastHit[] hits;
        
                hits = Physics.RaycastAll(new Ray(Quaternion.Euler(90, 0, 0) * line.GetPosition(0), Quaternion.Euler(90, 0, 0) * line.GetPosition(1) - Quaternion.Euler(90, 0, 0) * line.GetPosition(0)), (Quaternion.Euler(90, 0, 0) * line.GetPosition(1) - Quaternion.Euler(90, 0, 0) * line.GetPosition(0)).magnitude);
            Debug.Log(Quaternion.Euler(90, 0, 0) * line.GetPosition(0));
            Debug.Log(Quaternion.Euler(90, 0, 0) * line.GetPosition(1));
            Debug.Log(tangible0.transform.position);

            Debug.Log(tangible1.transform.position);
            foreach (RaycastHit hit in hits)
                {
                    if(hit.collider.gameObject.name == "ScissorsCollider")
                    {
                    Destroy(gameObject);
                    
                }
            }
        }
        
    }
}
