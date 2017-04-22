using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrGrabbable : MonoBehaviour {
    public ControllerManager controllerman;
    private Transform controller = null;
    private FixedJoint joint;

    private SteamVR_Controller.Device device
    {
        get
        {
            return SteamVR_Controller.Input((int)controller.GetComponent<SteamVR_TrackedObject>().index);
        }
    }
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
        if (controller)
        {
            if (device.GetPressDown(Valve.VR.EVRButtonId.k_EButton_Grip))
            {
                //Debug.Log("Drop");
                drop();
            }
        }
	}

    public void destory()
    {
        if (controller)
        {
            controller.tag = "Controller";
        }
        Destroy(transform.parent.gameObject);
    }

    public void drop()
    {
        if (controller)
        {
            controller.tag = "Controller";
            joint.connectedBody = null;
            StartCoroutine("delayDrop");
        }
    }

    private IEnumerator delayDrop()
    {
        //Debug.Log("Wait");
        yield return new WaitForSeconds(0.5f);
        //Debug.Log("Detach");
        controller = null;
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Controller") && controller == null)
        {
            //Debug.Log("Attached");
            controller = other.transform;
            controller.tag = "ControllerGrabbed";
            joint.connectedBody = controller.GetComponent<Rigidbody>();
        }
    }
}
