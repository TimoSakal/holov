using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Transmitter : MonoBehaviour
{
    [SerializeField] GameObject lever;
    [SerializeField] TransTriggPass transTrigPass;
    GameObject gameCube;
    Button passButton;
    public bool hasCube = false;
    [SerializeField] Transform leverStartPoint, leverEndPoint;
    // GameObject cubePlace;
    public Transform transPointToPass;
    public LeftPathTrig leftPathTrig;
    public RightPathTrig rightPathTrig;
    public BacktPathTrig backPathTrig;
    public ForwardPathTrig forwardPathTrig;
    ColorChange colorChange;

    public bool upPos, rightPos, leftPos;
    public bool canUseWithLever = true;

    private void OnEnable()
    {
        TransTriggPass.OnCanPass += ChangeButtonState;
    }

    private void OnDisable()
    {
       TransTriggPass.OnCanPass -= ChangeButtonState;

    }
    public void OnCol()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
    public void OffCol()
    {
        GetComponent<BoxCollider>().enabled = false;
    }
    void ChangeButtonState(bool state)
    {
        if(state==true && transTrigPass.canPass == true && hasCube == true)
        {
            passButton.interactable = true;
         
            colorChange.makeChanging = true;
           

        }
        if(state == false)
        {
            passButton.interactable = false;
          
            colorChange.makeChanging = false;

        }
    }
  
    private void Update()
    {
        // Debug.Log("HASCUBE: " + hasCube);
        if (Input.GetKeyDown("space") && passButton.interactable == true)
        {
            PassCube();
        }
    }
    private void Start()
    {
        gameCube = GameObject.FindGameObjectWithTag("GameCube");
        passButton = GameObject.FindGameObjectWithTag("PassButt").GetComponent<Button>();

        passButton.onClick.AddListener(PassCube);
        passButton.interactable = false;
        colorChange = FindObjectOfType<ColorChange>();
        colorChange.makeChanging = false;

    }

   
    public void PassCube()
    {
      

        if(transTrigPass.canPass == true && hasCube == true)
        {
            if (transTrigPass.isFinish == false)
            {
                Sound.Instance.give.Play();
            passButton.interactable = false;
         
              
                colorChange.makeChanging = false;
                Transform pointTo =  transTrigPass.otherCol.gameObject.GetComponentInParent<Transmitter>().transPointToPass;
            LeanTween.move(gameCube, pointTo , 0.5f).setEase(LeanTweenType.easeOutExpo);
            MoveLever();
            gameCube.transform.SetParent(transTrigPass.triggeredTrans.transform);
            }
            if(transTrigPass.isFinish == true)
            {
          
                passButton.interactable = false;
                colorChange.makeChanging = false;
                Transform pointTo = transTrigPass.otherCol.gameObject.GetComponentInParent<Finish>().finPointToPass;
                LeanTween.move(gameCube, pointTo, 0.5f).setEase(LeanTweenType.easeOutExpo);
                MoveLever();
                gameCube.transform.SetParent(transTrigPass.triggeredFinish.transform);
            }
          
        }
    }


    public bool leverFinished = true;
    void MoveLever()
    {
        leverFinished = false;
          LeanTween.move(lever,leverEndPoint.position, 0.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
          LeanTween.move(lever,leverStartPoint.position, 0.5f).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => {
              if(transTrigPass.canPass == true)
              {

              passButton.interactable = true;
               
                  colorChange.makeChanging = true;
              }
              leverFinished = true;
          });
          });
     
    }

  
   
}
