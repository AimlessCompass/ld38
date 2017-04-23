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

	}
	
	// Update is called once per frame
	void Update () {
        SteamVR_Controller.Device dev = getDeviceWithButtonDown(Valve.VR.EVRButtonId.k_EButton_Grip);
        if (dev != null) 
        {
            GameObject hand = getHand(dev).gameObject;
            if (!joint && GetComponent<Collider>()) 
            {
                Vector3 closestPoint = GetComponent<Collider>().ClosestPoint(hand.gameObject.transform.position);
                if ((closestPoint - hand.transform.position).magnitude <= 0.05f)
                    pickup(hand);
            }
        } else {
            dev = getDeviceWithButtonUp(Valve.VR.EVRButtonId.k_EButton_Grip);
            if (dev != null && joint) {
                drop(dev);
            }
        }
    }

    private SteamVR_TrackedObject getHand (SteamVR_Controller.Device dev) 
    {
        if (dev == controllerman.rightDevice)
            return controllerman.rightHand;
        else if (dev == controllerman.leftDevice)
            return controllerman.leftHand;
        return null;
    }

    private SteamVR_Controller.Device getDeviceWithButtonUp (Valve.VR.EVRButtonId bId) 
    {
        if (controllerman.rightDevice.GetPressUp(bId))
            return controllerman.rightDevice;
        else if (controllerman.leftDevice.GetPressUp(bId))
            return controllerman.leftDevice;
        return null;
    }

    private SteamVR_Controller.Device getDeviceWithButtonDown (Valve.VR.EVRButtonId bId) 
    {
        if (controllerman.rightDevice.GetPressDown(bId))
            return controllerman.rightDevice;
        else if (controllerman.leftDevice.GetPressDown(bId))
            return controllerman.leftDevice;
        return null;
    }

    public void pickup (GameObject ctr) {
        if (ctr.gameObject.CompareTag("Controller") && controller == null) 
        {
            //Debug.Log("Attached");
            controller = ctr.transform;
            controller.tag = "ControllerGrabbed";
            joint = gameObject.AddComponent<FixedJoint>();
            joint.connectedBody = controller.GetComponent<Rigidbody>();
        }
    }

    public void drop(SteamVR_Controller.Device dev)
    {
        if (controller)
        {
            controller.tag = "Controller";
            Object.Destroy(joint);
            joint = null;
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.angularVelocity = dev.angularVelocity;
            rb.velocity = dev.velocity;
            controller = null;
        }
    }
}
