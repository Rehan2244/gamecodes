using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//very first node generation
public class GeneratingPlatform : MonoBehaviour
{
    public GameObject spawnBox,CurrentPosition;
    public GameObject nextNode;
    public bool spawned = false;
    public int nodeNumber =1;
    // Start is called before the first frame update
    void Start()
    {
        nodeNumber = 1;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            this.transform.LookAt(GameObject.Find("1").transform);    //this to look angle of nodes set view point to previous node
        }
        catch(NullReferenceException ex)
        {
            this.transform.LookAt(GameObject.Find("endPoint").transform);
        }
    }
    void OnMouseOver()
    {
        //movement of node
        if(Input.GetMouseButtonDown(1) && !spawned)
        {
            nextNode = (GameObject)Instantiate(nextNode, this.transform.position + new Vector3(1, 0, 0), Quaternion.identity);
            
            nextNode.name = nodeNumber.ToString();
            spawned = true;
            nodeNumber += 1;

        }
    }
   
}
