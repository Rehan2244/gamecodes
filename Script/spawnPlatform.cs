using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class spawnPlatform : MonoBehaviour
{
    public GameObject platform;
    public int nextNodeInt,currentNodeInt;
    public GameObject nextNode,finalNode;
    //public MovementOfNode targettoLook;
    //public Transform trtarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //targettoLook = gameObject.GetComponent<MovementOfNode>();
        //distanceofnodes =gameObject.GetComponent<MovementOfNode>();
        FindNode();
        //trtarget = nextNode.transform;
        SpawnLog();
        //Debug.Log("Distance is nodede to: "+distanceofnodes.distanceofnodes);
    }
    void SpawnLog()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            platform = (GameObject)Instantiate(platform, this.transform.position, Quaternion.identity);// spawn a log //LookRotation(nextNode.transform.position)
            try
            {
                platform.transform.LookAt(nextNode.transform.position); //set rotation of log
                platform.transform.localScale = new Vector3(1, 1, 0.3371875f);
                Rigidbody rblog = platform.GetComponent<Rigidbody>();
               // rblog.isKinematic = false;
            }

            catch (NullReferenceException e)
            {
                finalNode = GameObject.Find("endPoint");
                platform.transform.localScale = new Vector3(1, 1, 0.3371875f);
                platform.transform.LookAt(finalNode.transform);
            }

            //platform.transform.localScale = new Vector3(1, 1, targettoLook.distanceofnodes);
        }
    }
    void FindNode() { 
        currentNodeInt = int.Parse(this.name);
    nextNodeInt = currentNodeInt;
        if(nextNodeInt==currentNodeInt)
        {
            nextNodeInt = currentNodeInt + 1;
        }
    nextNode = GameObject.Find(nextNodeInt.ToString());
    }
}
