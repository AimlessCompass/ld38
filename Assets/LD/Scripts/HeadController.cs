using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public Transform player;

    private bool pushPlayer = false;
    Vector3 pushBack = Vector3.zero;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pushPlayer)
        {
            player.Translate(pushBack * 0.005f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform otherTrans = collision.transform;
        if (otherTrans.CompareTag("Wall"))
        {
            pushPlayer = true;
        }
    }
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            //Vector3 pushBack = (transform.position - contact.point) * 0.1f;
            //player.Translate(new Vector3(pushBack.x, 0f, pushBack.y));
            //player.Translate(contact.normal * 0.01f);
            pushBack = contact.normal;
            //Debug.DrawRay(contact.point, new Vector3(pushBack.x, 0f, pushBack.y), Color.blue, 20f);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        pushPlayer = false;
        pushBack = Vector3.zero;
    }
}