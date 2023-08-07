using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggHelp : MonoBehaviour
{
    [SerializeField] Transmitter transmitter;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GameCube"))
        {
            transmitter.hasCube = true;
           
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("GameCube"))
        {
            transmitter.hasCube = false;
           

        }
    }
}
