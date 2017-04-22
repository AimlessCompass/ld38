using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {
    public Transform playerEyes;
    public float worldRadius = 25f;

    private bool keyheld = false;
    private Transform world;
    private Vector3 lastpos = Vector3.zero;
	// Use this for initialization
	void Start () {
		if (!playerEyes)
        {
            Debug.Log("No Player Attached");
        }
        world = transform.FindChild("Object");
        world.localScale = new Vector3(worldRadius * 2, worldRadius * 2, worldRadius * 2);
        transform.position = new Vector3(0f, -worldRadius, 0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.W)) {
            keyheld = true;
        } else
        {
            keyheld = false;
        }
        Vector3 newPos = playerEyes.position;
        float distanceTravelled = Vector3.Distance(newPos, lastpos);
        float angleToTurn = distanceTravelled * 180 / (Mathf.PI * worldRadius);
        Vector3 directionVector = (newPos - lastpos);
        directionVector = new Vector3(-directionVector.z, 0, directionVector.x);
        transform.Rotate(directionVector.normalized, angleToTurn * 10);
        lastpos = newPos;
        Debug.Log("Direction Vector: " + directionVector.normalized + " Angle: " + angleToTurn * 10);
	}

    private void FixedUpdate()
    {
        transform.position = new Vector3(playerEyes.position.x, -worldRadius, playerEyes.position.z);
        /*if (keyheld)
        {
            transform.localEulerAngles = transform.localEulerAngles + new Vector3(0.05f, 0f, 0f);
        }*/
    }
}
