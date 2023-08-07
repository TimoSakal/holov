using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GG.Infrastructure.Utils.Swipe;
public class SwipeManager : MonoBehaviour
{
    [SerializeField] SwipeListener swipeListenerUp;
  
    [SerializeField] SwipeListener swipeListenerLeft;
    [SerializeField] SwipeListener swipeListenerRight;
    GameObject ObjToMove;
   
    public bool swipeDetected = false;
    Transmitter transmitter;
    public  bool allowed = true;
    ParticlePlexus particlePlexus;
    private void OnEnable()
    {
        swipeListenerUp.OnSwipe.AddListener(OnSwipeUp);
        swipeListenerLeft.OnSwipe.AddListener(OnSwipeLeft);
        swipeListenerRight.OnSwipe.AddListener(OnSwipeRight);
        ObjectInteraction.selected += objToMove;
        ObjToMove = null;
    }

    private void Start()
    {
        Application.targetFrameRate = 300;
        particlePlexus = FindObjectOfType<ParticlePlexus>();

    }
    void OnSwipeUp(string swipe)
    {
       // Debug.Log(swipe);

        if(ObjToMove != null && allowed == true && transmitter.leverFinished == true)
        {
            particlePlexus.ChangeSimulationSpeed();
            if(transmitter.upPos)
            {
              MakeSwipeForUpTrans(swipe);
                Sound.Instance.swipe.Play();
                //   Debug.Log("enter"+swipe);
            }
            if (transmitter.rightPos)
            {
             //   MakeSwipeForRightTrans(swipe);
            }
            if (transmitter.leftPos)
            {
              //  MakeSwipeForLeftTrans(swipe);
            }
        }
    }
    void OnSwipeLeft(string swipe)
    {
      

        if (ObjToMove != null && allowed == true && transmitter.leverFinished == true)
        {
            particlePlexus.ChangeSimulationSpeed();
            if (transmitter.upPos)
            {
               // MakeSwipeForUpTrans(swipe);
            }
            if (transmitter.rightPos)
            {
              //  MakeSwipeForRightTrans(swipe);
            }
            if (transmitter.leftPos)
            {
                MakeSwipeForLeftTrans(swipe);
                Sound.Instance.swipe.Play();

            }
        }
    }
    void OnSwipeRight(string swipe)
    {
        //    Debug.Log(swipe);
      

        if (ObjToMove != null && allowed == true && transmitter.leverFinished == true)
        {
            particlePlexus.ChangeSimulationSpeed();
            if (transmitter.upPos)
            {
                // MakeSwipeForUpTrans(swipe);
            }
            if (transmitter.rightPos)
            {
                  MakeSwipeForRightTrans(swipe);
                Sound.Instance.swipe.Play();
            }
            if (transmitter.leftPos)
            {
              //  MakeSwipeForLeftTrans(swipe);
            }
        }
    }
    void MakeSwipeForUpTrans(string swipe)
    {
        if (swipe == "DownLeft" /*|| swipe == "Up"*/ && transmitter.leftPathTrig.moveAllowed == true && swipeDetected == false && transmitter.leftPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.leftPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);


        }
        if (swipe == "UpRight" /*|| swipe == "Right" */&& transmitter.rightPathTrig.moveAllowed == true && swipeDetected == false && transmitter.rightPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.rightPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);
        }
        if (swipe == "DownRight" /*|| swipe == "Down"*/ && transmitter.backPathTrig.moveAllowed == true && swipeDetected == false && transmitter.backPathTrig.moveAllowed2)
        {
            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.backPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);

        }
        if (swipe == "UpLeft" /*|| swipe == "Left"*/ && transmitter.forwardPathTrig.moveAllowed == true && swipeDetected == false && transmitter.forwardPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.forwardPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);
        }
    }

    void MakeSwipeForRightTrans(string swipe)
    {
        if (swipe == "Up" && transmitter.leftPathTrig.moveAllowed == true && swipeDetected == false && transmitter.leftPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.leftPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);


        }
        if (swipe == "Down" && transmitter.rightPathTrig.moveAllowed == true && swipeDetected == false && transmitter.rightPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.rightPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);
        }
        if (swipe == "DownLeft" && transmitter.backPathTrig.moveAllowed == true && swipeDetected == false && transmitter.backPathTrig.moveAllowed2)
        {
            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.backPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);

        }
        if (swipe == "UpRight" && transmitter.forwardPathTrig.moveAllowed == true && swipeDetected == false && transmitter.forwardPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.forwardPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);
        }
    }

    void MakeSwipeForLeftTrans(string swipe)
    {
        if (swipe == "Up" && transmitter.leftPathTrig.moveAllowed == true && swipeDetected == false && transmitter.leftPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.leftPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);


        }
        if (swipe == "Down" && transmitter.rightPathTrig.moveAllowed == true && swipeDetected == false && transmitter.rightPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.rightPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);
        }
        if (swipe == "UpLeft" && transmitter.backPathTrig.moveAllowed == true && swipeDetected == false && transmitter.backPathTrig.moveAllowed2)
        {
            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.backPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);

        }
        if (swipe == "DownRight" && transmitter.forwardPathTrig.moveAllowed == true && swipeDetected == false && transmitter.forwardPathTrig.moveAllowed2)
        {

            swipeDetected = true;
            LeanTween.move(ObjToMove, transmitter.forwardPathTrig.objToMoveTrans.transform.position, 0.5f).setOnComplete(() => swipeDetected = false).setEase(LeanTweenType.easeOutExpo);
        }
    }
    void objToMove(GameObject obj)
    {
        ObjToMove = obj.GetComponent<ObjectInteraction>().parent;
        transmitter = obj.GetComponent<Transmitter>();
    }

    private void OnDisable()
    {
        swipeListenerUp.OnSwipe.RemoveListener(OnSwipeUp);
    }
}
