using System.Collections;
using UnityEngine;
public class CoolMathADS : MonoBehaviour
{
    public static CoolMathADS instance;
   
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

   static bool entered;

    void Start()
    {
        if(entered == false)
        {
            entered = true;
        DontDestroyOnLoad(gameObject);
        }
       // StartCoroutine(wait());
      //  PauseGame();
    }
   
    IEnumerator wait()
    {
        yield return new WaitForSecondsRealtime(4);
        ResumeGame();
    }
    public void PauseGame()
    {
        //All the code inside PauseGame will be called when the Ad event will begin.
        //Below line will pause the game excluding the IEnumerator with WaitForSecondsRealtime
        //and the animators with Update Mode set to Unscaled Time.
        /* for (int i = 0; i < sources.Length; i++)
         {
             sources[i].volume = 0;


         }*/
        Debug.Log("PauseGame Function!");
        AudioListener.pause = true;
        Time.timeScale = 0f;
      //  StartCoroutine(wait());
        //If you do not want to pause the game, call your custom code to mute or stop the music of the game.
    }


    public void ResumeGame()
    {
        Time.timeScale = 1.0f;
        AudioListener.pause = false;
        Debug.Log("ResumeGame Function!");
       /* for (int i = 0; i < sources.Length; i++)
        {
            sources[i].volume = 1;
          
        }*/
        //If you used custom code to mute music in PauseGame function, call the code here to unmute or play the music.
    }
    //Below code call the cmgAdBreak event.
    public void InitiateAds()
    {
        Application.ExternalCall("triggerAdBreak");
    }
}
