using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointspowerup : MonoBehaviour
{
    public GameObject gameManagerThing;
    public GameObject pointsPowerUp;
    public GameObject playerCharacter;
    
    
    public MeshRenderer dobleMesh;
    public GameObject textDisapear;

    // Start is called before the first frame update
    private void Awake()
    {

        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        pointsPowerUp= GameObject.FindGameObjectWithTag("PointsPowerUp");
        gameManagerThing = GameObject.FindGameObjectWithTag("God");
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Light light = GetComponentInParent<Light>();
            light.enabled = false;
            GAMEMANAGEMENT.AddPoints(500);
            
            textDisapear.SetActive(false);
            
            this.gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.GetComponent<Renderer>().enabled = false;


        }
    }
    // Update is called once per frame
 
   
    
}
