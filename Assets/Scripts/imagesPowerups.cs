using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class imagesPowerups : MonoBehaviour
{
    public GameObject instakillImage;
    public GameObject x2Image;
    

    private void Awake()
    {
        instakillImage.SetActive(false);
        x2Image.SetActive(false);
    }
    
    void Update()
    {
        activarImagenInstKill();
        activarImagenPuntosDobles();
     /*   if (aliencontrol.instaKillActivated)
        {
            instakillImage.SetActive(true);
            
        }
        else if (GAMEMANAGEMENT.doublePointACtivated)
         {
             x2Image.SetActive(true);
         }

         else
         {
             instakillImage.SetActive(false);
             x2Image.SetActive(false);
         }
        */
    }

    void activarImagenPuntosDobles()
    {
        if (GAMEMANAGEMENT.doublePointACtivated)
        {
            x2Image.SetActive(true);
        }
        else
        {
            x2Image.SetActive(false);
        }
    }
    void activarImagenInstKill()
    {
        if (aliencontrol.instaKillActivated)
        {
            instakillImage.SetActive(true);

        }
        else
        {
            instakillImage.SetActive(false);
        }
    }
}
