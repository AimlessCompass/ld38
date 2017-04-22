using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour {
    public RoomState state;   //The location the room must move to.

    void Start () {
        SetState(state);
    }

    public void SetState (RoomState state) {
        this.state = state;
        gameObject.SetActive(state.active);

        if (state.destTag) {
            transform.position = state.destTag.transform.position;
        }
    }
}
