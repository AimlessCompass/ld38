using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrGrabbable : MonoBehaviour {

    private Transform controller = null;
    private FixedJoint joint;

	// Use this for initialization
	void Start () {
        joint = transform.parent.GetComponent<FixedJoint>();
        if (joint == null)
        {
            Debug.Log("Joint not found!");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destory()
    {
        if (controller)
        {
            controller.tag = "Controller";
        }
        Destroy(transform.parent.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller") && controller == null)
        {
            Debug.Log("Attached");
            controller = other.transform;
            controller.tag = "ControllerGrabbed";
            joint.connectedBody = controller.GetComponent<Rigidbody>();
        }
    }
}
