using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject mainConstruction;
    [SerializeField] GameObject menuButt, passButt, lvlText, restartBtn;
    [SerializeField] RectTransform menuPanel, MPFader;
    [SerializeField] GameObject soundButton, musicButton, returnButton;

    [SerializeField] RectTransform lvlPanel;
    Vector3 currTransform;
   
    bool clicked = false;
    public void OnMenuClicked()
    {
        if(clicked == false)
        {
            clicked = true;
        mainConstruction = FindObjectOfType<CurrentLvl>().gameObject;
        LeanTween.move(mainConstruction, new Vector3(0, -15, 0), 1).setEase(LeanTweenType.easeInExpo);
            currTransform = mainConstruction.transform.position;
        LeanTween.scale(passButt, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeInExpo);
        LeanTween.scale(menuButt, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeInExpo).setDelay(0.2f);
        LeanTween.scale(lvlText, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeInExpo).setDelay(0.3f);
        LeanTween.scale(restartBtn, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeInExpo).setDelay(0.4f);



            menuPanel.gameObject.SetActive(true);
            LeanTween.alpha(MPFader, 0f, 0);
            LeanTween.alpha(MPFader, 0.7f, 2);

            LeanTween.scale(soundButton, new Vector3(0, 0, 0), 0).setEase(LeanTweenType.easeInExpo);
            LeanTween.scale(musicButton, new Vector3(0, 0, 0), 0).setEase(LeanTweenType.easeInExpo);
            LeanTween.scale(returnButton, new Vector3(0, 0, 0), 0).setEase(LeanTweenType.easeInExpo);

            LeanTween.scale(soundButton, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutExpo).setDelay(1.2f); ;
            LeanTween.scale(musicButton, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutExpo).setDelay(1.4f);
            LeanTween.scale(returnButton, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutExpo).setDelay(2f);

            LeanTween.move(lvlPanel, new Vector3(0, -700, 0), 0);
            LeanTween.move(lvlPanel, new Vector3(0, 0, 0), 1).setEase(LeanTweenType.easeOutExpo).setDelay(0.5f);

            StartCoroutine(enumerator());
        }
    }
    bool clicked2;
    public void OnReturnClicked()
    {
        if (clicked2 == false)
        {
            clicked2 = true;

            mainConstruction = FindObjectOfType<CurrentLvl>().gameObject;
           // LeanTween.move(mainConstruction, new Vector3(-1.2f, 1.2f, 1.2f), 1).setEase(LeanTweenType.easeOutCubic).setDelay(0.5f).setOnComplete(()=> menuPanel.gameObject.SetActive(false)); 
            LeanTween.move(mainConstruction,currTransform, 1).setEase(LeanTweenType.easeOutCubic).setDelay(0.5f).setOnComplete(()=> menuPanel.gameObject.SetActive(false)); 

            LeanTween.scale(passButt, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutExpo).setDelay(1.5f); 
            LeanTween.scale(restartBtn, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutExpo).setDelay(1.3f); 
            LeanTween.scale(lvlText, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutExpo).setDelay(1.4f); 
            LeanTween.scale(menuButt, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutExpo).setDelay(1.6f);



           // menuPanel.gameObject.SetActive(true);
          
            LeanTween.alpha(MPFader, 0, 2);

          

            LeanTween.scale(soundButton, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeInExpo).setDelay(0.2f); ;
            LeanTween.scale(musicButton, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeInExpo).setDelay(0.4f);
            LeanTween.scale(returnButton, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeInExpo).setDelay(0);

            // LeanTween.move(lvlPanel, new Vector3(0, -700, 0), 0);
            LeanTween.move(lvlPanel, new Vector3(0, -700, 0), 1).setEase(LeanTweenType.easeInExpo);

            StartCoroutine(enumerator());
        }
    }

    IEnumerator enumerator()
    {
        yield return new WaitForSeconds(2);
        clicked = false;
        clicked2 = false;
    }

}
