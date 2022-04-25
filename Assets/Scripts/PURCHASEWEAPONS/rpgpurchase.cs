using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpgpurchase : MonoBehaviour
{
    public GameObject rpgPurchase;
    public GameObject playerCharacter;
    public GameObject UI;
    public GameObject fakecollider;
     public float distance_;
    public GameObject rpg;
    public weaponmanager llamadaAlManager;
    public bool isBought = false;
     //Start is called before the first frame update


     //Update is called once per frame
    void Update()
    {
         distance_ = Vector3.Distance(rpgPurchase.transform.position, playerCharacter.transform.position);
         showUI();
        purchase();
        TurnOFF();

    }
    public void showUI()
    {
        if (distance_ <= 2.0f)
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
         if (distance_ <= 2.0f && GAMEMANAGEMENT.playerScore >= 10000 && Input.GetKeyDown(KeyCode.E))
         {
             llamadaAlManager.addWeapon(rpg);
             GAMEMANAGEMENT.playerScore -= 10000;
            fakecollider.SetActive(false);
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

