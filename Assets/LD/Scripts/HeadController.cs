using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public Transform player;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Transform otherTrans = collision.transform;
        //Debug.Log("Collide");
        if (otherTrans.CompareTag("Wall"))
        {
            //Debug.Log(collision.relativeVelocity);
        }
    }
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 pushBack = (transform.position - contact.point) * 0.1f;
            //player.Translate(new Vector3(pushBack.x, 0f, pushBack.y));
            player.Translate(contact.normal * 0.01f);
            Debug.DrawRay(contact.point, new Vector3(pushBack.x, 0f, pushBack.y), Color.blue, 20f);
        }
    }
}