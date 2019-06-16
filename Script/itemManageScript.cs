using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemManageScript : MonoBehaviour
{
    public GameObject firstPoint;
    public Collider nodeCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnableRodaGeneration()
    {
        nodeCollider = firstPoint.GetComponent<Collider>();
        nodeCollider.enabled = !nodeCollider.enabled;
        
    }
}
