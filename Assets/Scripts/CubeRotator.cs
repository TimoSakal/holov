using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeRotator : MonoBehaviour
{
    int enterCounter = 0;
    [SerializeField] Transform parent;
    [SerializeField] Transform pointStart, pointEnd;
    [SerializeField] GameObject Mover;
    [SerializeField] ObjDetector objDetector;
    SwipeManager swipeManager;
   public  bool isUp, isRight, isLeft;

    private void Start()
    {
        swipeManager = FindAnyObjectByType<SwipeManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Cube"))
        {
            if (enterCounter < 4)
            {
                other.gameObject.GetComponent<BoxCollider>().enabled = false;
            other.gameObject.transform.SetParent(this.gameObject.transform);
            enterCounter++;
            }
          
           // other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
    bool inProcces = false;
    private void OnMouseDown()
    {
        if(inProcces == false && objDetector.canRotate == true)
        {
            swipeManager.allowed = false;
            inProcces = true;
            Sound.Instance.rotPlatf.Play();
            if (isRight)
            {

        LeanTween.move(this.gameObject, pointEnd.position, 0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(()=> {
            LeanTween.rotateAround(this.gameObject, new Vector3(1, 0, 0), 90, 0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(()=> {
                LeanTween.move(this.gameObject, pointStart.position, 0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(()=>{ inProcces = false; swipeManager.allowed = true; }); });
        } );
            }
            else if(isLeft)
            {
                LeanTween.move(this.gameObject, pointEnd.position, 0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(() => {
                    LeanTween.rotateAround(this.gameObject, new Vector3(0, 0, 1), 90, 0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => {
                        LeanTween.move(this.gameObject, pointStart.position, 0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(() => { inProcces = false; swipeManager.allowed = true; });
                    });
                });
            }
            else if(isUp)
            {
                LeanTween.move(this.gameObject, pointEnd.position, 0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(() => {
                    LeanTween.rotateAround(this.gameObject, new Vector3(0, 1, 0), 90, 0.5f).setEase(LeanTweenType.easeOutCubic).setOnComplete(() => {
                        LeanTween.move(this.gameObject, pointStart.position, 0.5f).setEase(LeanTweenType.easeInOutCubic).setOnComplete(() => { inProcces = false; swipeManager.allowed = true; });
                    });
                });
            }
        }
        else if (inProcces == false && objDetector.canRotate == false)
        {
            inProcces = true;
            this.gameObject.transform.DOShakeRotation(0.5f, 5 , 10).OnComplete(()=> inProcces = false);
        }


    }
}
