using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReaderController : MonoBehaviour {
    public Transform door;

    private bool openDoor = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (openDoor)
        {
            door.Translate(0f, 0.01f, 0f);
            if (door.position.y > (door.localScale.y / 2 + door.localScale.y))
            {
                openDoor = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            openDoor = true;
        }
    }
}
