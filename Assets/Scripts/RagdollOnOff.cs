using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollOnOff : MonoBehaviour
{
    [SerializeField] private BoxCollider mainCollider;
    [SerializeField] private GameObject rig;
    [SerializeField] private Animator animator;
    [SerializeField] private float impactPower;

    private Collider[] ragdollColliders;
    private Rigidbody[] limbsRigidbodies;

    private void Start()
    {
        GetRadollBits();
        RagdollModeOff();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RagdollModeOn();
            foreach (Rigidbody rigidbody in limbsRigidbodies)
            {
                rigidbody.AddForce(new Vector3(0, 0, impactPower), ForceMode.Impulse);
            }   
        }
    }

    void GetRadollBits()
    {
        ragdollColliders = rig.GetComponentsInChildren<Collider>();
        limbsRigidbodies = rig.GetComponentsInChildren<Rigidbody>();
    }

    void RagdollModeOn() 
    {
        animator.enabled = false;
        foreach (Collider colider in ragdollColliders)
        {
            colider.enabled = true;
        }
        foreach (Rigidbody rigidbody in limbsRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
        mainCollider.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void RagdollModeOff() 
    {
        foreach (Collider colider in ragdollColliders)
        {
            colider.enabled = false;
        }
        foreach (Rigidbody rigidbody in limbsRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
        animator.enabled = true;
        mainCollider.enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;
    }
}
