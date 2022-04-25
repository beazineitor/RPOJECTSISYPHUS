using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doblePoints : MonoBehaviour
{
    
    public GameObject gameManagerThing;
    public GameObject doblePointsItem;
    public GameObject playerCharacter;
    public int contador = 0;
    public bool pickedUp = false;
    public MeshRenderer dobleMesh;
    public GameObject textDisapear;
    

    
    
    // Start is called before the first frame update
    private void Awake()
    {
        
        playerCharacter = GameObject.FindGameObjectWithTag("Player");
        doblePointsItem = GameObject.FindGameObjectWithTag("DoblePoints");
        gameManagerThing = GameObject.FindGameObjectWithTag("God");
        
        contador = 0;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Light light = GetComponentInParent<Light>();
            light.enabled = false;
            print("HAS COGIDO LOS DOBLES PUNTOS");
            pickedUp = true;
            textDisapear.SetActive(false);
           
            GAMEMANAGEMENT.doublePointACtivated = true;
            this.gameObject.GetComponent<Renderer>().enabled = false;
            //gameObject.GetComponent<Renderer>().enabled = false;
           
          
        }
    }
    // Update is called once per frame
    void Update()
    {
        print("lo que queda" + contador*Time.deltaTime);
        
        suma();
        doubleThePoints();
        
    }
    void doubleThePoints()
    {
        
        if (contador * Time.deltaTime >= 25)
        {
            GAMEMANAGEMENT.doublePointACtivated = false;
            Destroy(gameObject);
        }
    }
    void suma()
    {
        if(pickedUp)
        {
            contador++;
        }
    }
}
