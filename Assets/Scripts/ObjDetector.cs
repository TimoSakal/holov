using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjDetector : MonoBehaviour
{
    public bool canRotate;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Transmitter")/* other.gameObject.CompareTag("RotateTrigg")*/)
        {
            canRotate = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Transmitter")/* other.gameObject.CompareTag("RotateTrigg")*/)
        {
            canRotate = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Transmitter")/* other.gameObject.CompareTag("RotateTrigg")*/)
        {
            canRotate = true;
        }
    }

}
