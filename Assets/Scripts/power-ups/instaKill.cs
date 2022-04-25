using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instaKill : MonoBehaviour
{
    
    public GameObject instaKillItem;
    public GameObject playerCharacter;
    public int contador = 0;
    public bool pickedUp = false;
    public aliencontrol alienigena;
    public GameObject calaveraFuera;

 

    // Start is called before the first frame update
    private void Awake()
    {

        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        instaKillItem = GameObject.FindGameObjectWithTag("InstaKill");
        
        contador = 0; 

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Light light = GetComponentInParent<Light>();
            light.enabled = false;         
            pickedUp = true;
            
            aliencontrol.instaKillActivated = true;
            calaveraFuera.SetActive(false);
            this.gameObject.GetComponent<Renderer>().enabled = false;
           


        }
    }
    // Update is called once per frame
    void Update()
    {
        print("lo que queda" + contador * Time.deltaTime);
       
        deactivateInstaKill();
        suma();
      

    }
 
    void deactivateInstaKill()
    {

        if (contador * Time.deltaTime >= 25)
        {
            aliencontrol.instaKillActivated = false;

            pickedUp = false;
            Destroy(gameObject);
        }
    }
    void suma()
    {
        if (pickedUp)
        {
            
            contador++;
        }
    }

}
