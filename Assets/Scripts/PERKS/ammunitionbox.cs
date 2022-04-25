using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammunitionbox : MonoBehaviour
{
    public GameObject ammoBox;
    public GameObject playerCharacter;
    public GameObject UI;
    public float distance_;
    public weapon blueWeapon;
    public bluepistol blueGUn;
    public weapon2 redWeapon;
    public greenrifle greenWeapon;
    public orangerifle orangeWeapon;
    public yellowrifle yellowWeapon;
    public greenperk perkverde;
  



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance_ = Vector3.Distance(ammoBox.transform.position, playerCharacter.transform.position);
        showUI();
        purchase();

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
        if (distance_ <= 3.0f && GAMEMANAGEMENT.playerScore >= 1500 && Input.GetKeyDown(KeyCode.E) && perkverde.isThisPerkActive == false)
        {
           
            GAMEMANAGEMENT.playerScore -= 1500;
            blueWeapon.bulletsLeft = 200;
            redWeapon.bulletsLeft = 200;
            greenWeapon.bulletsLeft = 200;
            orangeWeapon.bulletsLeft = 200;
            yellowWeapon.bulletsLeft = 200;
            blueGUn.bulletsLeft = 100;

          





        }
        else if (distance_ <= 3.0f && GAMEMANAGEMENT.playerScore >= 2000 && Input.GetKeyDown(KeyCode.E) && perkverde.isThisPerkActive == true)
        {
            GAMEMANAGEMENT.playerScore -= 1500;
            blueWeapon.bulletsLeft = 400;
            redWeapon.bulletsLeft = 300;
            greenWeapon.bulletsLeft = 400;
            orangeWeapon.bulletsLeft = 400;
            yellowWeapon.bulletsLeft = 500;
            blueGUn.bulletsLeft = 150;
        }
    }
}
