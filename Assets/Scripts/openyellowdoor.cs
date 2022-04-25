using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openyellowdoor : MonoBehaviour
{

    [SerializeField] private Animator anim;
    public GameObject destruiCollider;
    public turnLightsOn lucesEncendidas;
   
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
       
       
        buyDoor();

        //TurnOFF();
    }

    void buyDoor()
    {


        if (lucesEncendidas.isTriggered)
        {
            
            anim.SetBool("openDoors", true);
            destruiCollider.SetActive(false);
            
        }



    }
}
