using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redPerk : MonoBehaviour
{
    public GameObject REDpERK;
    public GameObject playerCharacter;
    public GameObject UI;
    public GameObject redDot;
    public float distance_;
    public bool isBought = false;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance_ = Vector3.Distance(REDpERK.transform.position, playerCharacter.transform.position);
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
        if(distance_ <= 3.0f && GAMEMANAGEMENT.playerScore>=4500 && Input.GetKeyDown(KeyCode.E))
        {
            redDot.SetActive(true);
            GAMEMANAGEMENT.playerScore -= 4500;
            playerhealth.maxHealth = 200;
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
