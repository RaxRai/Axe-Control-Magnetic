using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetScript : MonoBehaviour
{
    public Camera mainCamera;
    public Rigidbody magnetRigidbody;
    public float mouseSensitivity = 1f;
    // public BoxCollider magnetBoxCollider;
    public SphereCollider magnetSphereCollider;
    public float magnetStrength = 10f;
    public float magnetRadius = 5f;
    public Rigidbody axeRigidbody;
    bool isThrown = false;
    bool caught = false;
    bool hasStopped = false;

    void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag == "Axe")
        {

            caught = true;
            isThrown = false;
            magnetStrength = 0f;
            Vector3 cameraCenter = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, mainCamera.nearClipPlane));
            Vector3 directionToCamera = cameraCenter - transform.position;
            // directionToCamera.Normalize();

            axeRigidbody.MovePosition(directionToCamera);
            axeRigidbody.ResetCenterOfMass();
            axeRigidbody.freezeRotation = true;
            axeRigidbody.freezeRotation = false;
            axeRigidbody.rotation.Set(1.5f, 5f, -6f, 0f);

            // axeRigidbody.MovePosition(new Vector3(2, 6, 0));
            // axeRigidbody.ResetCenterOfMass();
            // axeRigidbody.freezeRotation = true;
            // axeRigidbody.freezeRotation = false;
            // axeRigidbody.rotation.Set(1.5f, 5f, -6f, 0f);

            axeRigidbody.velocity = Vector3.zero;
            axeRigidbody.useGravity = false;
            // magnetBoxCollider.size = Vector3.zero;
            magnetSphereCollider.radius = 0;

        }
    }

    void Start()
    {
        axeRigidbody.useGravity = false;
        magnetStrength = 0f;
        // magnetBoxCollider.size = Vector3.zero;
        magnetSphereCollider.radius = 0;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 cameraForward = mainCamera.transform.forward;
            ThrowAxe(cameraForward, 25);
        }
        if (Input.GetKey(KeyCode.E))
        {
            magnetStrength = 5000f;
            // magnetBoxCollider.size = new Vector3(40f, 10f, 5f);
            magnetSphereCollider.radius = 2;
        }
        // if (isThrown && !hasStopped && axeRigidbody.velocity.magnitude < 0.1f)
        // {
        //     hasStopped = true;
        // }


        // Debug.Log("mmm2 : " + Input.mousePosition);

    }

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

    void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, magnetRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.attachedRigidbody;
            Transform tr = collider.transform;

            if (rb != null && rb != magnetRigidbody && rb.gameObject.tag == "Axe" && isThrown)
            {

                Vector3 forceDirection = transform.position - rb.position;
                forceDirection.y++;
                float distance = forceDirection.magnitude;
                float forceMagnitude = magnetStrength / Mathf.Max(distance, 0.1f);
                rb.AddForce(forceDirection.normalized * forceMagnitude, ForceMode.Force);
            }
        }
    }

    // Debug visualization of the magnet radius
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
