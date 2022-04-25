using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class abrirPuertas : MonoBehaviour
{
    public GameObject playerCharacter;
    public GameObject puerta;
    public float distance_;
    public Text UIFORTHEDOOR;
    public int doorPrize;
    [SerializeField] private Animator anim;
    public bool isTriggered;
    public bool isCLose;
    public GameObject destruiCollider;
    public bool hasBeenOpened;
    public showprice doorPrice;
    // Start is called before the first frame update

    private void Awake()
    {
        UIFORTHEDOOR = GameObject.Find("doorUI").GetComponent<Text>();
        doorPrice = GameObject.Find("PERKSCANVAS").GetComponent<showprice>();
    }
    // Update is called once per frame
    void Update()
    {
        distance_ = Vector3.Distance(puerta.transform.position, playerCharacter.transform.position);
        SHOWUI();
        buyDoor();
        
        //TurnOFF();
    }
    public void SHOWUI()
    {
        if (distance_ <= 5.0f)
        {
            doorPrice.codigoDeLasPuertas = this;
            isCLose = true;

        }
        else
        {
            
            isCLose = false;
        }
    }
    void buyDoor()
    {
     
          
            if (distance_ <= 5.0f && GAMEMANAGEMENT.playerScore >= doorPrize && Input.GetKeyDown(KeyCode.E))
            {
                GAMEMANAGEMENT.playerScore -= doorPrize;
                anim.SetBool("openDoors", true);
            destruiCollider.SetActive(false);
                isTriggered = true;
            hasBeenOpened = true;
            }
       


    }

   /* public void TurnOFF()
    {
        if (isTriggered == true)
        {
            
            this.enabled = false;
        }
    }
   */
}


