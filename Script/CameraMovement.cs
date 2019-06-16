using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform _2dcam,_3dcam,focusOnObject;
    public float speed,carspeed=10f;
    public bool movecam = false;
    public Camera cam;
    public GameObject car,bgImage,target;
    public Rigidbody carweight;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        carweight = car.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.D) && movecam)
        {
            car.transform.position = Vector3.MoveTowards(car.transform.position, target.transform.position,carspeed*Time.deltaTime);
            
        }
        transform.LookAt(focusOnObject);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movecam = !movecam;
                
            
            /*else
            {
                transform.position = Vector3.MoveTowards(transform.position, _3dcam.position, speed * Time.deltaTime);
            }*/
        }
        if (movecam)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, _3dcam.position, speed * Time.deltaTime);
            bgImage.SetActive(false);
            
        }
        else
        {
            bgImage.SetActive(true);
            this.transform.position = Vector3.MoveTowards(this.transform.position, _2dcam.position, speed * Time.deltaTime);
            
        }
    }
}
