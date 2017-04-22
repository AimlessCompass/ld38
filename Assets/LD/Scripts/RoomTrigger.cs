using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrigger : MonoBehaviour {
    public StateChangeEntry[] changedStates;
	
    void OnTriggerEnter (Collider other) {
        if(other.gameObject.transform.parent.gameObject.CompareTag("Player")) {
            Vector3 currentPos = transform.position;
            foreach (StateChangeEntry entry in changedStates) {
                entry.room.SetState(entry.state);
            }
            other.gameObject.transform.parent.position += transform.position - currentPos;
        }
    }
}

[System.Serializable]
public class StateChangeEntry {
    public Room room;
    public RoomState state;
}