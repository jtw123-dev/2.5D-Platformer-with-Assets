using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad : MonoBehaviour
{
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="MovingBox")
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            Debug.Log("Distance " + distance);

            if (distance <0.05f)
            {
                other.attachedRigidbody.isKinematic = true;
                GetComponentInChildren<Renderer>().material.color = Color.blue;
                Destroy(this);//so we are no longer using the component destroy it when done
                //should also null check but should be fine.
            }
            
            
        }
    }
}
