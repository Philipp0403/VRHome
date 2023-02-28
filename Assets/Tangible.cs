using System.Collections.Generic;
using UnityEngine;

public class Tangible : MonoBehaviour
{
    public List<Tangible> connectedTangibles = new List<Tangible>();
    public List<TangibleLine> tangibleLines = new List<TangibleLine>();
    public List<TangibleLine> temporaryTangibleLines = new List<TangibleLine>();
    public bool isCollidingWithSurface = false;
    public bool inContactWithSurface = false;
    public float HeightToLock = 0.914f;
    public float grabThreshold = 0.2f;
    public Oculus.Interaction.HandGrab.HandGrabInteractor leftHandState;
    public Oculus.Interaction.HandGrab.HandGrabInteractor rightHandState;
    public Transform leftFingerTip;
    public Transform rightFingerTip;
    GameObject table;
    public GameObject linePrefab;
    GameObject testTangible;
    public Transform startNewConnectionButton;
    PokeInteractorVRHome rightPoke;
    PokeInteractorVRHome leftPoke;
    public GameObject ButtonsToHide;
    // Start is called before the first frame update
    void Start()
    {
        rightPoke = GameObject.Find("PokeRightRandVRHome").GetComponent<PokeInteractorVRHome>();
        leftPoke = GameObject.Find("PokeLeftRandVRHome").GetComponent<PokeInteractorVRHome>();
        leftHandState = GameObject.Find("HandGrabInteractorL").GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractor>();
        rightHandState = GameObject.Find("HandGrabInteractorR").GetComponent<Oculus.Interaction.HandGrab.HandGrabInteractor>();
        leftFingerTip = GameObject.Find("l_index_finger_tip_marker").transform;
        rightFingerTip = GameObject.Find("r_index_finger_tip_marker").transform;
        table = GameObject.Find("Table");

        //testing
        //CreateConnection(GameObject.Find("TestTangible").GetComponent<Tangible>());
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

		foreach(TangibleLine tangibleLine in temporaryTangibleLines)
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
        //if(inContactWithSurface) Debug.Log("incontact");
        float rightIndexFingerTipDistanceFromSurface = rightFingerTip.position.y - HeightToLock;
        float leftIndexFingerTipDistanceFromSurface = leftFingerTip.position.y - HeightToLock;
        bool belowGrabThresholdRight = grabThreshold > rightIndexFingerTipDistanceFromSurface;
        bool belowGrabThresholdLeft = grabThreshold > leftIndexFingerTipDistanceFromSurface;
        bool rightHandLockCondition = rightHandState.Interactable != null && rightHandState.Interactable.gameObject == gameObject && belowGrabThresholdRight;
        bool leftHandLockCondition = leftHandState.Interactable != null && leftHandState.Interactable.gameObject == gameObject && belowGrabThresholdLeft;

        Vector3 tableColliderBounds = table.GetComponent<BoxCollider>().size;
        float tableXMin = table.transform.position.x - 0.5207f;
        float tableXMax = table.transform.position.x + 0.5207f;
        float tableZMin = table.transform.position.z - 0.9276f;
        float tableZMax = table.transform.position.z + 0.9276f;
        bool onTable = transform.position.x > tableXMin && transform.position.x < tableXMax && transform.position.z > tableZMin && transform.position.z < tableZMax;
        inContactWithSurface = onTable && transform.position.y <= HeightToLock + grabThreshold && transform.position.y >= HeightToLock - grabThreshold;

        if ((rightHandLockCondition || leftHandLockCondition) && onTable)
        {
            transform.position = new Vector3(transform.position.x, HeightToLock, transform.position.z);
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        }
        ButtonsToHide?.SetActive(inContactWithSurface);
        startNewConnectionButton.gameObject.SetActive(inContactWithSurface);
        //GetComponent<Rigidbody>().useGravity = !inContactWithSurface;
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
		newLineScript.tangible0 = gameObject;
		newLineScript.tangible1 = tangibleToConnect.gameObject;
        tangibleLines.Add(newLineScript);
	}
    public void StartConnectionVisual()
    {
        GameObject newLine = Instantiate(linePrefab);
        TangibleLine newLineScript = newLine.GetComponent<TangibleLine>();
        newLineScript.tangible0 = gameObject;
        if ((startNewConnectionButton.position - rightFingerTip.position).magnitude < (startNewConnectionButton.position - leftFingerTip.position).magnitude)
        {
            newLineScript.tangible1 = rightPoke.gameObject;
            rightPoke.currentTangible = this;
        }
        else
        {
            newLineScript.tangible1 = leftPoke.gameObject;
            leftPoke.currentTangible = this;
        }
        temporaryTangibleLines.Add(newLineScript);
        
    }
    

}
