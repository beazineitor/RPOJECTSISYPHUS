using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORANGEpERK : MonoBehaviour
{
    public GameObject ORANGEPERK;
    public GameObject playerCharacter;
    public GameObject UI;
    public GameObject orangeDot;
    public float distance_;
    public weapon weaponDamage;
    public weapon2 weaponDamage2;
    public greenrifle greenDamage;
    public orangerifle orangeDamage;
    public yellowrifle yellowDamage;
    public bluepistol blueGun;
    public aliencontrol rpgDamage;
    public bool isBought = false;
   
        
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance_ = Vector3.Distance(ORANGEPERK.transform.position, playerCharacter.transform.position);
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
        if (distance_ <= 3.0f && GAMEMANAGEMENT.playerScore >= 10000 && Input.GetKeyDown(KeyCode.E))
        {
            orangeDot.SetActive(true);
            GAMEMANAGEMENT.playerScore -= 10000;
            weaponDamage.damage = 100;
            blueGun.damage = 50;
            weaponDamage2.damage = 325;
            greenDamage.damage = 50;
            orangeDamage.damage = 100;
            yellowDamage.damage = 200;
            rpgDamage.applyRPGDamage(500);
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
