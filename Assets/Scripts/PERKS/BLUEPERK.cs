using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BLUEPERK : MonoBehaviour
{
    public GameObject blueperk;
    public GameObject playerCharacter;
    public GameObject UI;
    public GameObject blueDot;
    public float distance_;
    public bluepistol blueGun;
    public weapon blueWeapon;
    public weapon2 redWeapon;
    public greenrifle greenWeapon;
    public orangerifle orangeWeapon;
    public yellowrifle yellowWeapon;
    public weaponmanager switchdelay;
    public GRAPPLEHOOK hookdistance;
    public bool isBought = false;
    

    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance_ = Vector3.Distance(blueperk.transform.position, playerCharacter.transform.position);
        showUI();
        purchase();

        TurnOFF();
    }
    public void showUI()
    {
        if (distance_ <= 3.0f)
        {
            UI.SetActive(true);
        }
        else
        {
            UI.SetActive(false);
        }
    }
    public void purchase()
    {
        if (distance_ <= 3.0f && GAMEMANAGEMENT.playerScore >= 2500 && Input.GetKeyDown(KeyCode.E))
        {
            blueDot.SetActive(true);
            GAMEMANAGEMENT.playerScore -= 2500;
            switchdelay.switchDelay = 0.1F;
            blueWeapon.adsSpeed = 20f;
            redWeapon.adsSpeed = 14f;
            redWeapon.contador = 1;
            greenWeapon.adsSpeed = 20f;
            orangeWeapon.adsSpeed = 20f;
            yellowWeapon.adsSpeed = 15;
            hookdistance._maxGrappledistance = 60;
            hookdistance._hookSpeed = 20;
            blueGun.adsSpeed = 15f;
            isBought = true;





        }
        
    }
    public void TurnOFF()
    {
        if (isBought == true)
        {
            UI.SetActive(false);
            this.enabled = false;
        }
    }
}
