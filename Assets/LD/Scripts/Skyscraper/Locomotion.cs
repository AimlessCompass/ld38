using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.AI;
using Valve.VR.InteractionSystem;

namespace Skyscraper {
    /// <summary>
    /// Player locomotion controlled by a touchpad.
    /// </summary>
    [AddComponentMenu("")]
    public class Locomotion : MonoBehaviour {

        public float moveSpeed = 2;
        public float celeration = 5;

        [SerializeField]
        Hand hand;
        NavMeshAgent agent;
        Vector3 movementDirection = Vector3.zero;


        /// <summary>
        /// Want to change hand?
        /// </summary>
        public Hand Hand {
            set {
                hand = value;
            }
        }
        
        Vector2 TouchAxis {
            get {
                if (hand.controller == null)
                    return Vector2.zero;
                return hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0);
            }
        }

        float Yaw {
            get {
                return hand.transform.eulerAngles.y;
            }
        }

        Vector3 WalkDirection {
            get {
                return      Quaternion.Euler(0, Yaw, 0) *
                            new Vector3(TouchAxis.x, 0, TouchAxis.y);
            }
        }

        void OnEnable() {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update() {
            movementDirection = Vector3.Lerp(movementDirection, WalkDirection, celeration * Time.deltaTime);
            agent.Move(movementDirection * 2 * Time.deltaTime);
        }

    }
}