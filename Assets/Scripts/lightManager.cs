using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightManager : MonoBehaviour
{
    public GameObject firstRoomLights;
    public int contador = 0;

 
    // Update is called once per frame
    void Update()
    {
        contador++;
        activateRedLights();
    }
    void activateRedLights()
    {
        if (contador * Time.deltaTime >= 4)
        {
            firstRoomLights.SetActive(true);
        }
    }
}
