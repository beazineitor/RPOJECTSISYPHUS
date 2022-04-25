using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showprice : MonoBehaviour
{
    [SerializeField] private Text textOnScreen;
    public abrirPuertas  codigoDeLasPuertas;
   
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        showPriceText();
        
    }
    void showPriceText()
    {
        if (codigoDeLasPuertas.isCLose == true && codigoDeLasPuertas.hasBeenOpened != true)
        {
            textOnScreen.text = "PRESS *E* TO OPEN THE DOOR  " + codigoDeLasPuertas.doorPrize.ToString();
        }
        if (codigoDeLasPuertas.isCLose == false)
        {
            textOnScreen.text = "";
        }
    }
}
