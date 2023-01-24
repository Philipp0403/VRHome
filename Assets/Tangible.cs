using System.Collections.Generic;
using UnityEngine;

public class Tangible : MonoBehaviour
{
    public List<Tangible> connectedTangibles = new List<Tangible>();
    public List<TangibleLine> tangibleLines = new List<TangibleLine>();

    public bool inContactWithSurface = false;
    public float surfaceHeight = 1.1f;
    public float grabThreshold = 0.7f;
    public Oculus.Interaction.HandGrab.HandGrabInteractor leftHandState;
    public Oculus.Interaction.HandGrab.HandGrabInteractor rightHandState;
    public Transform leftFingerTip;
    public Transform rightFingerTip;
    GameObject table;
    public GameObject linePrefab;
    GameObject testTangible;
    // Start is called before the first frame update
    void Start()
    {
        leftHandState = GameObject.Find("HandGrabInteractorL").GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractor>();
        rightHandState = GameObject.Find("HandGrabInteractorR").GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractor>();
        leftFingerTip = GameObject.Find("l_index_finger_tip_marker").transform;
        rightFingerTip = GameObject.Find("r_index_finger_tip_marker").transform;
        table = GameObject.Find("Table");

        //testing
        if (name != "TestTangible")
        {
            testTangible = GameObject.Find("TestTangible");
            CreateConnection(testTangible.GetComponent<Tangible>());
        }
    }
	private void Update()
	{
        if (Input.GetKeyDown("space"))
        {
            RemoveConnection(testTangible.GetComponent<Tangible>());
        }
        // update all line vertex positions
		foreach(TangibleLine tangibleLine in tangibleLines)
        {
            LineRenderer lineRenderer = tangibleLine.GetComponent<LineRenderer>();
            // rotate Vectors, because line transform is rotateted by 90 degrees around x axis
            Vector3 vertex0Pos = Quaternion.Euler(-90, 0, 0) * tangibleLine.tangible0.transform.position;
            Vector3 vertex1Pos = Quaternion.Euler(-90, 0, 0) * tangibleLine.tangible1.transform.position;
            lineRenderer.SetPositions(new Vector3[] { vertex0Pos, vertex1Pos});
        }
	}
	// Update is called once per frame
	void LateUpdate()
    {
        GetComponent<Rigidbody>().useGravity = !inContactWithSurface;
        
        float rightIndexFingerTipDistanceFromSurface = rightFingerTip.position.y - surfaceHeight;
        float leftIndexFingerTipDistanceFromSurface = leftFingerTip.position.y - surfaceHeight;
        bool belowGrabThresholdRight = grabThreshold > rightIndexFingerTipDistanceFromSurface;
        bool belowGrabThresholdLeft = grabThreshold > leftIndexFingerTipDistanceFromSurface;
        bool rightHandLockCondition = rightHandState.Interactable != null && rightHandState.Interactable.gameObject == gameObject && belowGrabThresholdRight;
        bool leftHandLockCondition = leftHandState.Interactable != null && leftHandState.Interactable.gameObject == gameObject && belowGrabThresholdLeft;
        Vector3 tableColliderBounds = table.GetComponent<BoxCollider>().size;
        float tableXMin = table.transform.position.x - 0.9276f;
        float tableXMax = table.transform.position.x + 0.9276f;
        float tableZMin = table.transform.position.z - 0.5207f;
        float tableZMax = table.transform.position.z + 0.5207f;
        bool onTable = transform.position.x > tableXMin && transform.position.x < tableXMax && transform.position.z > tableZMin && transform.position.z < tableZMax;
        if ((rightHandLockCondition || leftHandLockCondition ) && onTable)
        {
            transform.position = new Vector3(transform.position.x, surfaceHeight, transform.position.z);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        }
    }
    // Create a connection to another tangible
    public void CreateConnection(Tangible tangibleToConnect)
	{
		connectedTangibles.Add(tangibleToConnect);
		tangibleToConnect.connectedTangibles.Add(this);
        CreateTangibleLine(tangibleToConnect);
	}
    // Remove a connection to another tangible

    public void RemoveConnection(Tangible tangibleToRemove)
	{
		connectedTangibles.Remove(tangibleToRemove);
		tangibleToRemove.connectedTangibles.Remove(this);
		RemoveTangibleLine(tangibleToRemove);
	}

	private void RemoveTangibleLine(Tangible tangibleToRemove)
	{
        // tangible line is in this or the connected tangibles line array. Find and destroy it
        TangibleLine tangibleLineToRemove0 = tangibleLines.Find(s => s.tangible0 == tangibleToRemove || s.tangible1 == tangibleToRemove);
        if (tangibleLineToRemove0 != null)
        {
            tangibleLines.Remove(tangibleLineToRemove0);
            Destroy(tangibleLineToRemove0.gameObject);
        }

        TangibleLine tangibleLineToRemove1 = tangibleToRemove.tangibleLines.Find(s => s.tangible0 == tangibleToRemove || s.tangible1 == tangibleToRemove);
        if (tangibleLineToRemove1 != null)
        {
            tangibleToRemove.tangibleLines.Remove(tangibleLineToRemove1);
            Destroy(tangibleLineToRemove1.gameObject);
        }
	}

	private void CreateTangibleLine(Tangible tangibleToConnect)
	{
		GameObject newLine = Instantiate(linePrefab);
		TangibleLine newLineScript = newLine.GetComponent<TangibleLine>();
		newLineScript.tangible0 = this;
		newLineScript.tangible1 = tangibleToConnect;
        tangibleLines.Add(newLineScript);
	}


}
