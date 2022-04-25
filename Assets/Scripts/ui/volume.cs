using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class volume : MonoBehaviour
{
    public AudioMixer audioMixer;
    // Start is called before the first frame update
public void setVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
    }
}
