using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerManager : MonoBehaviour {

    public SteamVR_TrackedObject leftHand;
    public SteamVR_TrackedObject rightHand;

    public WorldController world;

    public float gameLoopTime = 0.1f;

    private float deltaTime = 0f;

    Valve.VR.EVRButtonId grip = Valve.VR.EVRButtonId.k_EButton_Grip;                        //Grip Button
    Valve.VR.EVRButtonId trigger = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger;          //Trigger Button
    Valve.VR.EVRButtonId touch = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad;           //Touchpad Button
    Valve.VR.EVRButtonId app = Valve.VR.EVRButtonId.k_EButton_ApplicationMenu;              //Application Button
    Valve.VR.EVRButtonId touchAxis = Valve.VR.EVRButtonId.k_EButton_Axis0;                  //Touch Vector2 Axis
    Valve.VR.EVRButtonId triggerAxis = Valve.VR.EVRButtonId.k_EButton_Axis1;                //Trigger float Axis

    public SteamVR_Controller.Device leftDevice
    {
        get
        {
            return SteamVR_Controller.Input((int)leftHand.index);
        }
    }

    public SteamVR_Controller.Device rightDevice
    {
        get
        {
            return SteamVR_Controller.Input((int)rightHand.index);
        }
    }

    public Vector2 RightTouchAxis
    {
        get
        {
            return rightDevice.GetAxis(touchAxis);
        }
    }

    public Vector2 LeftTouchAxis
    {
        get
        {
            return leftDevice.GetAxis(touchAxis);
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    private void Update()
    {
        deltaTime += Time.deltaTime;
        if (deltaTime > gameLoopTime)
        {
            if (rightDevice.GetPress(trigger))
            {
                if (world)
                {
                    Debug.Log("Fast");
                    world.rotationMultiplier = 5;
                }
            } else 
            {
                if (world)
                {
                    Debug.Log("Slow");
                    world.rotationMultiplier = 1;
                }
            }
            deltaTime = 0f;
        }
    }

}
