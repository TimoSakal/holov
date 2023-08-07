using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LvlPanel : MonoBehaviour
{
    [SerializeField] RectTransform panel1, panel2, panel3;
    [SerializeField] Button myButt;
    void Start()
    {
        panel1.gameObject.SetActive(true);
        panel2.gameObject.SetActive(false);
        panel3.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        myButt.interactable = true;
    }
    int counter;
    public void OnPanelChange()
    {
        myButt.interactable = false;
        if(counter >=3)
        {
            counter = 0;
        }

        if(counter == 0)
        {

        LeanTween.move(panel1, new Vector3(0, 700, 0), 1);
        panel2.gameObject.SetActive(true);
        LeanTween.move(panel2, new Vector3(0, -700, 0), 0).setEase(LeanTweenType.easeOutExpo);
        LeanTween.move(panel2, new Vector3(0, 0, 0), 1).setEase(LeanTweenType.easeOutExpo).setOnComplete(()=> { myButt.interactable = true; panel1.gameObject.SetActive(false); });
        }
        else if(counter == 1)
        {
            LeanTween.move(panel2, new Vector3(0, 700, 0), 1);
            panel3.gameObject.SetActive(true);
            LeanTween.move(panel3, new Vector3(0, -700, 0), 0).setEase(LeanTweenType.easeOutExpo);
            LeanTween.move(panel3, new Vector3(0, 0, 0), 1).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => { myButt.interactable = true; panel2.gameObject.SetActive(false); });
        }
        else if (counter == 2)
        {
            LeanTween.move(panel3, new Vector3(0, 700, 0), 1);
            panel1.gameObject.SetActive(true);
            LeanTween.move(panel1, new Vector3(0, -700, 0), 0).setEase(LeanTweenType.easeOutExpo);
            LeanTween.move(panel1, new Vector3(0, 0, 0), 1).setEase(LeanTweenType.easeOutExpo).setOnComplete(() => { myButt.interactable = true; panel3.gameObject.SetActive(false); });
        }
        counter++;

    }

    public void BlockDownButt()
    {
        myButt.interactable = false;
    }
}
