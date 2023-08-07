using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPlatform : MonoBehaviour
{

    public GameObject transmitter;
   // public GameObject transmitterSecond;
    bool hasTrans;
    public bool canMove = true;
    

    private void Start()
    {
      
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Transmitter") && hasTrans == false)
        {
            hasTrans = true;
            transmitter = other.gameObject;
        }
      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == transmitter)
        {
            hasTrans = false;
            transmitter = null;
            canMove = true;
        }
       
    }
}
