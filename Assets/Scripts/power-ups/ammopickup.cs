using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammopickup : MonoBehaviour
{

    public weapon blueWeapon;
    public weapon2 redWeapon;
    public greenrifle greenWeapon;
    public orangerifle orangeWeapon;
    public yellowrifle yellowWeapon;
    public bluepistol pistol;
    public BAZOOKA missilesLeft;
    public greenperk perkverde;
    public GameObject playerCharacter;
    public GameObject maxAmmo;
    public float distance_;
    public GameObject bebidaVerde;

     private void Update()
    {
        print(distance_ + " dime la distancia");
        distance_ = Vector3.Distance(maxAmmo.transform.position, playerCharacter.transform.position);
        pickUpTheMaxAmmo();
        
    }

    private void Awake()
    {
       // perkverde = GameObject.Find("bebidaverde").GetComponent<greenperk>();
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        
        blueWeapon = playerCharacter.gameObject.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<weapon>();
        redWeapon = playerCharacter.gameObject.transform.GetChild(0).GetChild(0).GetChild(1).gameObject.GetComponent<weapon2>();
        greenWeapon = playerCharacter.gameObject.transform.GetChild(0).GetChild(0).GetChild(2).gameObject.GetComponent<greenrifle>();
        orangeWeapon = playerCharacter.gameObject.transform.GetChild(0).GetChild(0).GetChild(3).gameObject.GetComponent<orangerifle>();
        yellowWeapon = playerCharacter.gameObject.transform.GetChild(0).GetChild(0).GetChild(5).gameObject.GetComponent<yellowrifle>();
        pistol = playerCharacter.gameObject.transform.GetChild(0).GetChild(0).GetChild(6).gameObject.GetComponent<bluepistol>();
        missilesLeft = playerCharacter.gameObject.transform.GetChild(0).GetChild(0).GetChild(7).gameObject.GetComponent<BAZOOKA>();


        bebidaVerde = GameObject.FindGameObjectWithTag("bebidaverde");
       perkverde = bebidaVerde.gameObject.transform.GetComponent<greenperk>();
        

       

    }
    void pickUpTheMaxAmmo()
    {
        if (distance_ <= 1.0f && perkverde.isThisPerkActive == false)
        {
            print("I picked it up");
            POWERUPPICKUP item = GetComponentInParent<POWERUPPICKUP>();
            blueWeapon.bulletsLeft = 200;
            redWeapon.bulletsLeft = 200;
            greenWeapon.bulletsLeft = 200;
            orangeWeapon.bulletsLeft = 200;
           yellowWeapon.bulletsLeft = 200;
            missilesLeft.currentRockets = 20;
            //item.disablePickUp();
            print("Destroy maxAmmo");
            Destroy(gameObject);
        }
        else if (distance_ <= 1.0f && perkverde.isThisPerkActive == true)
        {
            POWERUPPICKUP item = GetComponentInParent<POWERUPPICKUP>();
            blueWeapon.bulletsLeft = 400;
            redWeapon.bulletsLeft = 300;
            greenWeapon.bulletsLeft = 400;
            orangeWeapon.bulletsLeft = 400;
            yellowWeapon.bulletsLeft = 500;
            missilesLeft.currentRockets = 40;
            //item.disablePickUp();
            Destroy(gameObject);
        }
    }
}
