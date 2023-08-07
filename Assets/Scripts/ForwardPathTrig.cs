using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardPathTrig : MonoBehaviour
{
    public bool moveAllowed, moveAllowed2 = true;
    public GameObject objToMoveTrans;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PathCom"))
        {
          //  Debug.Log("LeftTrigger");
            moveAllowed = true;
            objToMoveTrans = other.gameObject.GetComponent<PathComponent>().parent;
        }
        if (other.gameObject.CompareTag("Transmitter"))
        {
            moveAllowed2 = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PathCom"))
        {
           // Debug.Log("LeftTrigger");
            moveAllowed = true;
          // objToMoveTrans = other.gameObject.GetComponent<PathComponent>().parent;
        }
        if (other.gameObject.CompareTag("Transmitter"))
        {
            moveAllowed2 = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.CompareTag("PathCom"))
        {
            moveAllowed = false;
        }
        if (other.gameObject.CompareTag("Transmitter"))
        {
            moveAllowed2 = true;
        }
    }
}
