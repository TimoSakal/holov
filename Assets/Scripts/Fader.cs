using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    RectTransform thisRect;
    private void Start()
    {
       thisRect = GetComponent<RectTransform>();
        LeanTween.alpha(thisRect, 1, 0);
        LeanTween.alpha(thisRect, 0, 1.5f).setOnComplete(()=> GetComponent<Image>().enabled = false);
    }
}
