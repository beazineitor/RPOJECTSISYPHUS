using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Utility;
public class prupleperk : MonoBehaviour
{
    public GameObject pruplePerk;
    public GameObject playerCharacter;
    public GameObject UI;
    public GameObject prupleDot;
    public float distance_;
    public UnityStandardAssets.Characters.FirstPerson.FirstPersonController controller;
    public bool isBought = false;
    public GameObject destroyObjects;



    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        distance_ = Vector3.Distance(pruplePerk.transform.position, playerCharacter.transform.position);
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
            prupleDot.SetActive(true);
            GAMEMANAGEMENT.playerScore -= 3500;
            destroyObjects.SetActive(false);
            controller.m_WalkSpeed = 8;
            controller.m_RunSpeed = 18;
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
