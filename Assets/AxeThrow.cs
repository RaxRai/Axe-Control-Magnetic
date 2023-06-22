using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeThrow : MonoBehaviour
{
    public Rigidbody axeRigidbody;
    bool isThrown = false;

    void ThrowAxe(Vector3 throwDirection, float throwForce)
    {
        axeRigidbody.useGravity = true;
        if (!isThrown)
        {
            // Invoke("EnableCatchField", 1f);
            isThrown = true;
            axeRigidbody.AddForce(throwDirection * throwForce, ForceMode.Impulse);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
