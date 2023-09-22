using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxManager : MonoBehaviour
{
    public static SfxManager instance;




    public AudioSource[] sound_effect;
    private void Awake()
    {
        instance = this;    
    }

 
    public void PlaySFX( int sfxToplaye)
    {
        sound_effect[ sfxToplaye ].Stop();
        sound_effect[ sfxToplaye ].Play();
    }
    public void PlaySFXPitched (int sfxToplay)
    {
        sound_effect[sfxToplay].pitch = Random.Range(.8f, 1.2f);

        PlaySFX(sfxToplay);

    }
}
