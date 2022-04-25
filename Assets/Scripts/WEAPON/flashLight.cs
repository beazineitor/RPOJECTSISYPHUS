using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashLight : MonoBehaviour
{
    public GameObject Light;
    public bool lightActive;
    private AudioSource lightOn;
    public AudioClip flashLightOn;
    // Start is called before the first frame update
    void Start()
    {
        Light.SetActive(false);
        lightOn = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            lightActive = !lightActive;
            if (lightActive)
            {
                flahsLightActive();
            }
           if (!lightActive)
            {
                flashLightInnactive();
            }
            playFlashLightSoundEffect();
            
        }
    }
    void flahsLightActive()
    {
        Light.SetActive(true);
    }
    void flashLightInnactive()
    {
        Light.SetActive(false);
    }
    private void playFlashLightSoundEffect()
    {
        lightOn.PlayOneShot(flashLightOn);
    }
}
