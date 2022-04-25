using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenperk : MonoBehaviour
{
    public GameObject ORANGEPERK;
    public GameObject playerCharacter;
    public GameObject UI;
    public GameObject greenDot;
    public float distance_;
    public weapon blueWeapon;
    public weapon2 redWeapon;
    public greenrifle greenWeapon;
    public orangerifle orangeWeapon;
    public yellowrifle yellowWeapon;
    public bluepistol bluegun;
    public BAZOOKA bazooKammunition;
    public bool isThisPerkActive = false;
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
        if (distance_ <= 3.0f && GAMEMANAGEMENT.playerScore >= 3500 && Input.GetKeyDown(KeyCode.E))
        {
            greenDot.SetActive(true);
            GAMEMANAGEMENT.playerScore -= 3500;
            bluegun.bulletsLeft = 150;
            bluegun.bulletsPerMag = 20;
            blueWeapon.bulletsLeft = 400;
            blueWeapon.bulletsPerMag = 40;
            redWeapon.bulletsPerMag = 40;
            redWeapon.bulletsLeft = 300;
            greenWeapon.bulletsPerMag = 45;
            greenWeapon.bulletsLeft = 400;
            orangeWeapon.bulletsPerMag = 50;
            orangeWeapon.bulletsLeft = 400;
            yellowWeapon.bulletsPerMag = 70;
            yellowWeapon.bulletsLeft = 500;
            bazooKammunition.rocketsLeft = 40;
            isThisPerkActive = true;
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
