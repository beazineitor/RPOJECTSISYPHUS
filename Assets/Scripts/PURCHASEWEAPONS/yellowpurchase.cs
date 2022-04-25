using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yellowpurchase : MonoBehaviour
{
    public GameObject yellowPurchase;
    public GameObject playerCharacter;
    public GameObject UI;
    public GameObject rifleAmarillo;
    public weaponmanager llamadaAlManager;
    public float distance_;
    public bool isBought = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance_ = Vector3.Distance(yellowPurchase.transform.position, playerCharacter.transform.position);
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
            llamadaAlManager.addWeapon(rifleAmarillo);
            GAMEMANAGEMENT.playerScore -= 2500;
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
