using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
public class PeriodicLightIntensity : MonoBehaviour {
    private float initialIntensity;
    public float variance = 0.1f;
    public float frequency = 1.0f;
    void Start () {
        initialIntensity = GetComponent<Light>().intensity;
	}
	
	void Update () {
        GetComponent<Light>().intensity = initialIntensity + Mathf.Sin(Time.time * frequency) * variance;
    }
}
