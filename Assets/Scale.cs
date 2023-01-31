using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Scale : MonoBehaviour
{
    
    public float value = 0;
    public float stepSize = 1;

    public TextMeshPro displayText;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	private void OnEnable()
	{

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnUpButtonPressed()
    {
        value += stepSize;
        displayText.SetText(value.ToString());
    }
    public void OnDownButtonPressed()
    {
        value -= stepSize;
        displayText.SetText(value.ToString());
    }
}
