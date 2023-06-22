using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody axeRigidbody;
    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag != "Player")
        {

            Debug.Log("Crashed");
            axeRigidbody.velocity = Vector3.zero;
            axeRigidbody.freezeRotation = true;

        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (axeRigidbody.velocity.magnitude > 1f)
        {
            transform.Rotate(new Vector3(1, 0, 0));
        }
    }
}
