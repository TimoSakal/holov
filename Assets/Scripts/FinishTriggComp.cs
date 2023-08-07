using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class FinishTriggComp : MonoBehaviour
{
    bool entered;
    int lvlProgress, currentLevel;
    CurrentLvl currentLvl;
    RectTransform fader;
    [DllImport("__Internal")]
    private static extern void StartLevelEvent(int level);

    private void Start()
    {
        currentLvl = FindObjectOfType<CurrentLvl>();
        currentLevel = PlayerPrefs.GetInt("currentLvl", 1);
        fader = FindObjectOfType<Fader>().GetComponent<RectTransform>();
        lvlProgress = PlayerPrefs.GetInt("lvlProgress", 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("GameCube") && entered == false)
        {
            entered = true;
            
            if(currentLevel >= lvlProgress)
            {
                if(lvlProgress < 30)
                {

            PlayerPrefs.SetInt("lvlProgress", (currentLevel+1));
            PlayerPrefs.Save();
                Debug.Log("SETTED" + (currentLevel + 1));
                }
            

            }
            if(currentLevel < 30)
            { 
            PlayerPrefs.SetInt("currentLvl", (currentLevel + 1));
            PlayerPrefs.Save();
            }

            StartCoroutine(finish());
        }
    }

    [SerializeField] ParticleSystem[] particles;
    IEnumerator finish()
    {
        particles[0].Play();
        particles[1].Play();
        particles[2].Play();
        Sound.Instance.finish.Play();
        yield return new WaitForSeconds(2);
        Fade();

    }
    void Fade()
    {
        fader.GetComponent<Image>().enabled = true;
        LeanTween.alpha(fader, 1, 1f).setOnComplete(()=> {
            if(Boolian.Instance.useApi)
            {
                StartLevelEvent(currentLevel + 1);
            CoolMathADS.instance.InitiateAds();

            }
            SceneManager.LoadScene(0);

        });
    }
}
