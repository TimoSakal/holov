using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class ObjectInteraction : MonoBehaviour
{
    bool endRotation = true;
    public static Action<GameObject> selected;
    public GameObject parent;
    SwipeManager swipeManager;
    public bool SimplePlatform;
    ParticlePlexus particlePlexus;
    public bool oneSideRotate = false;
    [SerializeField] GameObject mainCorpus;
   
    private void Start()
    {
        swipeManager = FindFirstObjectByType<SwipeManager>();
        particlePlexus = FindObjectOfType<ParticlePlexus>();
      
    }
  
    private void OnMouseDown()
    {

        selected?.Invoke(this.gameObject);
    }

    bool needMove;
    bool canDoSecondMove = false;
    
    private void OnMouseUp()
    {
        if (endRotation == true && swipeManager.swipeDetected == false)
        {
            RotateTrans();
           // StartCoroutine(comfClick());
        }
        else if(canDoSecondMove == true)
        {
            needMove = true;
        }
      
    }
    int rotCounter;
    void RotateTrans()
    {
        if(!SimplePlatform )
        {
            if(oneSideRotate == false)
            {
                Sound.Instance.rotate.Play();
                particlePlexus.ChangeSimulationSpeed();
        LeanTween.rotateAroundLocal(this.gameObject, Vector3.up, 90, 0.3f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => endRotation = true);
        endRotation = false;
            }
            else if(oneSideRotate == true)
            {
                Sound.Instance.rotate.Play();
                particlePlexus.ChangeSimulationSpeed();
                if(rotCounter ==0)
                {
                LeanTween.rotateAroundLocal(this.gameObject, Vector3.up, 90, 0.3f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => endRotation = true);
                }
                else if(rotCounter == 1)
                {
                    LeanTween.rotateAroundLocal(this.gameObject, Vector3.up, -90, 0.3f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => endRotation = true);
                }
                rotCounter++;
                if(rotCounter >= 2)
                {
                    rotCounter = 0;
                }
                endRotation = false;
            }
        }
     
    }

  public void MakeBlue()
    {
        mainCorpus.GetComponent<Renderer>().material.color = new Color32(124,178,255,255);
    }
}
