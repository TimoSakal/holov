using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TransTriggPass : MonoBehaviour
{
    public Transmitter triggeredTrans;
    public Finish triggeredFinish;
    public Transform otherTransCubePlace;
    public bool canPass = false;
    public Collider otherCol;
    public static Action<bool> OnCanPass;
    public bool isFinish;
    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.CompareTag("TriggHelp"))
        {
        //    Debug.Log("trans");
            triggeredTrans = other.gameObject.GetComponentInParent<Transmitter>();
            otherCol = other;
            isFinish = false;
            canPass = true;
            OnCanPass?.Invoke(true);
        }
        if (other.gameObject.CompareTag("FinHelp"))
        {
          
            triggeredFinish = other.gameObject.GetComponentInParent<Finish>();
            otherCol = other;
            isFinish = true;
            canPass = true;
            OnCanPass?.Invoke(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("TriggHelp"))
        {
          
            canPass = false;
           OnCanPass?.Invoke(false);
            triggeredTrans = null;
        }
        if (other.gameObject.CompareTag("FinHelp"))
        {

          
            canPass = false;
            OnCanPass?.Invoke(false);
            triggeredTrans = null;
        }
    }
}
