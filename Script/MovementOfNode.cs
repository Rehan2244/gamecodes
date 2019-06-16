using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementOfNode : MonoBehaviour
{
    LineRenderer lr;
    public GameObject previousNode;
    public GeneratingPlatform gp;
    public int currentNodeNo, previousNodeNo, otherNodeNumber;
    //public string currentNodeStr,previousNodeStr;
    public float distanceofnodes;
    public GameObject Current, firstNode;
    public float radius;
    public bool spawned = false;
    // public Transform trTarget;

    // Start is called before the first frame update
    void Start()
    {
        radius = 2f;

    }

    // Update is called once per frame
    void Update()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        previousNode = GameObject.Find(previousNodeNo.ToString());
        PositionOfNode();
        gp = GameObject.Find("0").GetComponent<GeneratingPlatform>();                //calling script component
        currentNodeNo = int.Parse(this.name);     //converted current node name to int
        Debug.Log("Current Node number: " + currentNodeNo);         //print current node int
        previousNodeNo = currentNodeNo; // - 1;                //calculating previous node int
        Debug.Log("Previous node:" + previousNodeNo);       // print previous node int
        previousNode.transform.LookAt(this.transform.position); //rotation of previous node to current node

        if (currentNodeNo == previousNodeNo)
        {
            previousNodeNo = currentNodeNo - 1;

        }
        //converted previous node int to string name
        Debug.Log(currentNodeNo);

        lr.SetPosition(0, previousNode.transform.position);
        lr.SetPosition(1, this.transform.position);
        try
        {
            if(previousNode.active)
            {
                Debug.Log("Exits Previous Node"+previousNode.name);
            }
        }
        catch(NullReferenceException ex)
        {
            Debug.LogException(ex);
        }
        //distanceofnodes = Vector3.Distance(this.transform.position,previousNode.transform.position);  //calculate distance of 2 nodes
        // Debug.Log("Distance is: " + distanceofnodes);



    }
    void OnMouseDrag()
    {
        if (Input.GetMouseButton(0))
        {


            Vector3 clickPosition = -Vector3.one;
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 40f));
            // Debug.Log(clickPosition);
            this.transform.position = clickPosition;


        }

    }
    //Node Generation block
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            gp.nextNode = (GameObject)Instantiate(gp.nextNode, this.transform.position + new Vector3(2, 2, 0), Quaternion.identity);

            gp.nextNode.name = gp.nodeNumber.ToString();

            gp.nodeNumber += 1;

        }
    }

    // block for restricting movement of node in boundary with previous node
    void PositionOfNode()
    {
        //this block to move it in radius
        Vector3 centerPosition = previousNode.transform.localPosition; //center of *black circle*
        Current = this.gameObject;
        float distance2 = Vector3.Distance(Current.transform.position, centerPosition); //distance from ~green object~ to *black circle*

        if (distance2 > radius) //If the distance is less than the radius, it is already within the circle.
        {
            Vector3 fromOriginToObject = Current.transform.position - centerPosition; //~GreenPosition~ - *BlackCenter*
            fromOriginToObject *= radius / distance2; //Multiply by radius //Divide by Distance
            Current.transform.position = centerPosition + fromOriginToObject; //*BlackCenter* + all that Math
        }

    }
    public void OnTriggerEnter(Collider others)
    {
        otherNodeNumber = int.Parse(others.transform.name);
        Debug.Log("node" + otherNodeNumber + "entered");
        if (others.gameObject.tag == "Nodes" && this.name != others.name)
        {
            //others.gameObject.name = this.name;
            // others.transform.position=transform.position;        }
        }
    }
}
