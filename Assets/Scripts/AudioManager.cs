using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> Music;

    public AudioClip ClickSound;

    public AudioSource MusicSorce;
    public AudioSource SfxSource;


    public Button SoundToggle;
    public Button MusicToggle;

    public Sprite SoundOn;
    public Sprite SoundOff;

    public Sprite MusicOn;
    public Sprite MusicOff;

    int MusicIndex = 0;

    bool SoundPlaying = true;
    bool MusicPlaying = true;

    void Start()
    {
        if(Music.Count <= 0) 
        {
            return;
        }
        ShuffleList(Music);

        MusicSorce.clip = Music[MusicIndex];

        MusicSorce.playOnAwake= true;


        SfxSource.clip = ClickSound;
        SfxSource.playOnAwake = false;
        SfxSource.loop= false;


    }

    // Update is called once per frame
    void Update()
    {
        if(MusicSorce.isPlaying == false && MusicPlaying == true) 
        {
            MusicIndex++;

            if(MusicIndex > Music.Count)
            {
                //finished playlist

                ShuffleList(Music);
                MusicIndex = 0;
                MusicSorce.clip = Music[MusicIndex];
                MusicSorce.Play();
            }
            else
            {
                MusicSorce.clip = Music[MusicIndex];
                MusicSorce.Play();
            }
        }
        
    }

    public void PlayClickSound()
    {
        SfxSource.Play();
    }

    void ShuffleList<T>(List<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    public void ToggleMusic()
    {
        if(MusicPlaying == true)
        {
            MusicPlaying = false;
            MusicSorce.Stop();

            MusicToggle.GetComponent<Image>().sprite = MusicOff;
        }
        else
        {
            MusicPlaying = true;
            ShuffleList(Music);
            MusicIndex= 0;
            MusicSorce.clip = Music[MusicIndex];
            MusicSorce.Play();
            MusicToggle.GetComponent<Image>().sprite = MusicOn;

        }
    }

    public void ToggleSound()
    {
        if (SoundPlaying == true)
        {
            SoundPlaying = false;
            SfxSource.Stop();
            SfxSource.volume = 0.0f;

            SoundToggle.GetComponent<Image>().sprite = SoundOff;
        }
        else
        {
            SoundPlaying = true;
            SfxSource.volume = 1.0f;

            SoundToggle.GetComponent<Image>().sprite = SoundOn;
        }
    }
}
