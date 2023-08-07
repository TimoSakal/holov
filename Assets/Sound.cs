using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    [SerializeField] Button sfxBtn, musicBtn;
    public AudioSource musicSource;
    public AudioSource rotate, swipe, ability, give ,finish, rotPlatf;
    [SerializeField] Sprite[] sound, mucic;

    public static Sound Instance { get; private set; }
    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    int currMusic, currSound;
    private void Start()
    {
        musicBtn.onClick.AddListener(MusicBtn);
        sfxBtn.onClick.AddListener(SoundBtn);

        currMusic = PlayerPrefs.GetInt("music", 1);
        currSound = PlayerPrefs.GetInt("sound", 1);

        if(currMusic == 1)
        {
            musicSource.volume = 1f;
            Mcounter = 1;
            musicBtn.GetComponent<Image>().sprite = mucic[1];
        }
        else if(currMusic ==0)
        {
            musicSource.volume = 0f;
            Mcounter = 0;
            musicBtn.GetComponent<Image>().sprite = mucic[0];
        }

        if (currSound == 1)
        {

            rotate.volume = 1f;
            swipe.volume = 1f;
            ability.volume = 1f;
            give.volume = 1f;
            finish.volume = 1f;
            rotPlatf.volume = 1f;
            sfxBtn.GetComponent<Image>().sprite = sound[1];
            Scounter = 1;
        }
        else if (currSound == 0)
        {
            sfxBtn.GetComponent<Image>().sprite = sound[0];
            rotate.volume = 0f;
            swipe.volume = 0f;
            ability.volume = 0f;
            give.volume = 0f;
            finish.volume = 0f;
            rotPlatf.volume = 0f;
            Scounter = 0;
        }

    }

    int Mcounter = 1;
    public void MusicBtn()
    {
        if(Mcounter == 0)
        {
            musicSource.volume = 1f;
            Mcounter = 1;

            musicBtn.GetComponent<Image>().sprite = mucic[1];

            PlayerPrefs.SetInt("music", 1);
            PlayerPrefs.Save();
        }
        else if(Mcounter == 1)
        {
        musicSource.volume = 0f;
            Mcounter = 0;
            musicBtn.GetComponent<Image>().sprite = mucic[0];
            PlayerPrefs.SetInt("music", 0);
            PlayerPrefs.Save();

        }
    }

    int Scounter = 1;
    public void SoundBtn()
    {
        if (Scounter == 0)
        {
            rotate.volume = 1f;
            swipe.volume = 1f;
            ability.volume = 1f;
            give.volume = 1f;
            finish.volume = 1f;
            rotPlatf.volume = 1f;
            sfxBtn.GetComponent<Image>().sprite = sound[1];
            Scounter = 1;
            PlayerPrefs.SetInt("sound", 1);
            PlayerPrefs.Save();
          

        }
        else if (Scounter == 1)
        {
            rotate.volume = 0f;
            swipe.volume = 0f;
            ability.volume = 0f;
            give.volume = 0f;
            finish.volume = 0f;
            rotPlatf.volume = 0f;
            Scounter = 0;
            sfxBtn.GetComponent<Image>().sprite = sound[0];
            PlayerPrefs.SetInt("sound", 0);
            PlayerPrefs.Save();
           
        }
    }
}
