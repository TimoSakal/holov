using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Runtime.InteropServices;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] lvlPrefabs;
    [SerializeField] Button[] lvlButtons;
    int currentLvl;
    [SerializeField] RectTransform fader;
    int counter;
    int progress;
    [SerializeField] Text levelText;

    [DllImport("__Internal")]
    private static extern void StartLevelEvent(int level);

    // Import the javascript function that redirects to another URL
    [DllImport("__Internal")]
    private static extern void ReplayEvent();
    private void Start()
    {
        currentLvl = PlayerPrefs.GetInt("currentLvl", 1);
      //  Debug.Log("CurrentLvl: " + currentLvl);
      //  Debug.Log("lvlProgress: " + PlayerPrefs.GetInt("lvlProgress", 1));
        progress = PlayerPrefs.GetInt("lvlProgress", 1);
        levelText.text = "Level: "  + currentLvl.ToString();
        AddListenersToButtons();
        for (int i = 0; i < lvlButtons.Length; i++)
        {
           
                lvlButtons[i].interactable = false;

        }
        for (int i = 0; i < progress; i++)
        {
            if(counter <= progress )
            {
                lvlButtons[i].interactable = true;

            }
            counter++;
        }
        
        Instantiate(lvlPrefabs[currentLvl - 1]);
                
        
    }


    void AddListenersToButtons()
    {
        for (int i = 0; i < lvlButtons.Length; i++)
        {
            int index = i; // To capture the current index in the lambda function

            // Assign a unique identifier to the button
            lvlButtons[i].name = "Button" + (i+1);

            // Add a listener to the button
            lvlButtons[i].onClick.AddListener(() =>
            {
                // Get the name of the button that was clicked
                string buttonName = lvlButtons[index].name;

                // Use the name to determine which button was pressed
                switch (buttonName)
                {
                    case "Button1":
                        GoToLevel(1);
                        break;
                    case "Button2":
                        GoToLevel(2);
                        break;
                    case "Button3":
                        GoToLevel(3);
                        break;
                    case "Button4":
                        GoToLevel(4);
                        break;
                    case "Button5":
                        GoToLevel(5);
                        break;
                    case "Button6":
                        GoToLevel(6);
                        break;
                    case "Button7":
                        GoToLevel(7);
                        break;
                    case "Button8":
                        GoToLevel(8);
                        break;
                    case "Button9":
                        GoToLevel(9);
                        break;
                    case "Button10":
                        GoToLevel(10);
                        break;
                    case "Button11":
                        GoToLevel(11);
                        break;
                    case "Button12":
                        GoToLevel(12);
                        break;
                    case "Button13":
                        GoToLevel(13);
                        break;
                    case "Button14":
                        GoToLevel(14);
                        break;
                    case "Button15":
                        GoToLevel(15);
                        break;
                    case "Button16":
                        GoToLevel(16);
                        break;
                    case "Button17":
                        GoToLevel(17);
                        break;
                    case "Button18":
                        GoToLevel(18);
                        break;
                    case "Button19":
                        GoToLevel(19);
                        break;
                    case "Button20":
                        GoToLevel(20);
                        break;
                    case "Button21":
                        GoToLevel(21);
                        break;
                    case "Button22":
                        GoToLevel(22);
                        break;
                    case "Button23":
                        GoToLevel(23);
                        break;
                    case "Button24":
                        GoToLevel(24);
                        break;
                    case "Button25":
                        GoToLevel(25);
                        break;
                    case "Button26":
                        GoToLevel(26);
                        break;
                    case "Button27":
                        GoToLevel(27);
                        break;
                    case "Button28":
                        GoToLevel(28);
                        break;
                    case "Button29":
                        GoToLevel(29);
                        break;
                    case "Button30":
                        GoToLevel(30);
                        break;
                    case "Button31":
                        GoToLevel(31);
                        break;

                }
            });
        }
    }

   public void GoToLevel(int number)
    {
        
       // Debug.Log("Number: " + number);
        PlayerPrefs.SetInt("currentLvl", number);
        PlayerPrefs.Save();
        
        fader.gameObject.GetComponent<Image>().enabled = true;
        // LeanTween.alpha(Fader, 1, 0f);
        LeanTween.alpha(fader, 1, 1.5f).setOnComplete(() => { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            
            if(Boolian.Instance.useApi)
            {
              StartLevelEvent(number); 
            }
        });

    }
    public void RestartButt()
    {

      
      
            fader.gameObject.GetComponent<Image>().enabled = true;
            LeanTween.alpha(fader, 1, 1.5f).setOnComplete(() => {
                if (Boolian.Instance.useApi)
                {
                    ReplayEvent();
                    CoolMathADS.instance.InitiateAds();

                }
              
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        
        });

    }
}
