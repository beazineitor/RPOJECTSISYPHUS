using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIINSTAKILL : MonoBehaviour
{
    public GameObject yoMismo;
    public instaKill instakillActivo;
    public aliencontrol powerUpActivado;
    // Start is called before the first frame update
 

    // Update is called once per frame
    void Update()
    {
        meActivo();
    }
    void meActivo()
    {
        if (aliencontrol.instaKillActivated)
        {
            print("activadisimo");
            yoMismo.SetActive(true);
        }
       
    }
}
