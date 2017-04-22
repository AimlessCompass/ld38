using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed = 1.0f;
    void FixedUpdate () {
        if (GetComponent<SteamVR_ControllerManager>().left) {
            GameObject left = GetComponent<SteamVR_ControllerManager>().left;
            SteamVR_Controller.Device leftDevice =
                SteamVR_Controller.Input((int) left.GetComponent<SteamVR_TrackedObject>().index);
            if (leftDevice.GetPress(SteamVR_Controller.ButtonMask.Touchpad)) {
                Vector2 axis = leftDevice.GetAxis();
                Vector3 forwards = left.transform.rotation * Vector3.forward * axis.y;
                Vector3 right = left.transform.rotation * Vector3.right * axis.x;
                Vector3 velocity = forwards + right;
                velocity = velocity.x * Vector3.right + velocity.z * Vector3.forward;
                transform.position += velocity * speed * Time.fixedDeltaTime;
            }
        }
    }
}
