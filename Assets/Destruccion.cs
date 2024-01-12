using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruccion : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)

    {
        if (collision.gameObject.tag.Equals("DestrucCol"))

        {
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DestructionTrigger"));
        {
            Destroy(other.gameObject);
        }
      
    }
}